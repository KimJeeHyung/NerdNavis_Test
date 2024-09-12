using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Menu Objects")]
    [SerializeField] private GameObject ResourcesMenu;  // 자원 메뉴
    [SerializeField] private GameObject GachaMenu;      // 뽑기 메뉴

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI MenuText;              // 현재 메뉴를 표시하는 텍스트
    [SerializeField] private TextMeshProUGUI ResourcesText;         // 현재 보유 중인 자원량 텍스트
    [SerializeField] private TextMeshProUGUI PlayerAttackText;      // 플레이어 공격력 텍스트
    [SerializeField] private TextMeshProUGUI PlayerDefenseText;     // 플레이어 방어력 텍스트
    [SerializeField] private TextMeshProUGUI PlayerHpText;          // 플레이어 체력 텍스트
    [SerializeField] private TextMeshProUGUI PlayerCombatPowerText; // 플레이어 전투력 텍스트

    // 자원 메뉴 전환 버튼
    [Header("Menu Buttons")]
    [SerializeField] private Button ResourcesMenuButton;
    private Image ResourcesMenuBackground;
    private TextMeshProUGUI ResourcesMenuText;

    // 뽑기 메뉴 전환 버튼
    [SerializeField] private Button GachaMenuButton;
    private Image GachaMenuBackground;
    private TextMeshProUGUI GachaMenuText;

    private Color SelectedColor;    // 버튼이 선택 중일 때 색깔

    public static Action UpdateResourcesText;   // 보유 중인 자원량 텍스트를 갱신하는 이벤트
    public static Action UpdateStatTexts;       // 플레이어 스탯 텍스트들을 갱신하는 이벤트

    // Start is called before the first frame update
    void Start()
    {
        // 초기 설정
        Initialize();

        // 이벤트 함수 할당
        UpdateResourcesText += SetResourcesText;

        UpdateStatTexts += SetAttackText;
        UpdateStatTexts += SetDefenseText;
        UpdateStatTexts += SetHpText;
        UpdateStatTexts += SetCombatPowerText;

        // 텍스트 초기화
        UpdateResourcesText();
        UpdateStatTexts();
    }

    void Initialize()
    {
        SelectedColor = new Color32(0, 83, 166, 255);

        ResourcesMenuBackground = ResourcesMenuButton.GetComponent<Image>();
        ResourcesMenuText = ResourcesMenuButton.GetComponentInChildren<TextMeshProUGUI>();

        GachaMenuBackground = GachaMenuButton.GetComponent<Image>();
        GachaMenuText = GachaMenuButton.GetComponentInChildren<TextMeshProUGUI>();

        ResourcesMenuBackground.color = SelectedColor;
        ResourcesMenuText.color = Color.white;

        GachaMenu.SetActive(false);
    }

    public void OnClickResourcesMenuButton()
    {
        ResourcesMenu.SetActive(true);
        GachaMenu.SetActive(false);

        ChangeButtonColor(0);
        SetMenuText("자원");
    }

    public void OnClickGachaMenuButton()
    {
        GachaMenu.SetActive(true);
        ResourcesMenu.SetActive(false);

        ChangeButtonColor(1);
        SetMenuText("뽑기");
    }

    void ChangeButtonColor(int menuNum)
    {
        // 0일 경우 자원 메뉴 버튼을 선택 중으로 변경
        if (0 == menuNum)
        {
            ResourcesMenuBackground.color = SelectedColor;
            ResourcesMenuText.color = Color.white;

            GachaMenuBackground.color = Color.white;
            GachaMenuText.color = Color.black;
        }
        // 1일 경우 뽑기 메뉴 버튼을 선택 중으로 변경
        else if (1 == menuNum)
        {
            GachaMenuBackground.color = SelectedColor;
            GachaMenuText.color = Color.white;

            ResourcesMenuBackground.color = Color.white;
            ResourcesMenuText.color = Color.black;
        }
    }

    void SetMenuText(string name)
    {
        MenuText.text = name;
    }

    void SetResourcesText()
    {
        int currentResources = Player.Instance.GetResources();

        ResourcesText.text = NumberControl.FormatWithUnit(currentResources);
    }

    void SetAttackText()
    {
        int playerAttack = Player.Instance.GetAttack();

        PlayerAttackText.text=NumberControl.FormatWithUnit(playerAttack);
    }

    void SetDefenseText()
    {
        int playerDefense = Player.Instance.GetDefense();

        PlayerDefenseText.text = NumberControl.FormatWithUnit(playerDefense);
    }

    void SetHpText()
    {
        int playerHp = Player.Instance.GetHp();

        PlayerHpText.text = NumberControl.FormatWithUnit(playerHp);
    }

    void SetCombatPowerText()
    {
        int playerCombatPower = Player.Instance.GetCombatPower();

        PlayerCombatPowerText.text = NumberControl.FormatWithUnit(playerCombatPower);
    }
}
