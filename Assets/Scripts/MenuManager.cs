using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Menu Objects")]
    [SerializeField] private GameObject ResourcesMenu;  // �ڿ� �޴�
    [SerializeField] private GameObject GachaMenu;      // �̱� �޴�

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI MenuText;              // ���� �޴��� ǥ���ϴ� �ؽ�Ʈ
    [SerializeField] private TextMeshProUGUI ResourcesText;         // ���� ���� ���� �ڿ��� �ؽ�Ʈ
    [SerializeField] private TextMeshProUGUI PlayerAttackText;      // �÷��̾� ���ݷ� �ؽ�Ʈ
    [SerializeField] private TextMeshProUGUI PlayerDefenseText;     // �÷��̾� ���� �ؽ�Ʈ
    [SerializeField] private TextMeshProUGUI PlayerHpText;          // �÷��̾� ü�� �ؽ�Ʈ
    [SerializeField] private TextMeshProUGUI PlayerCombatPowerText; // �÷��̾� ������ �ؽ�Ʈ

    // �ڿ� �޴� ��ȯ ��ư
    [Header("Menu Buttons")]
    [SerializeField] private Button ResourcesMenuButton;
    private Image ResourcesMenuBackground;
    private TextMeshProUGUI ResourcesMenuText;

    // �̱� �޴� ��ȯ ��ư
    [SerializeField] private Button GachaMenuButton;
    private Image GachaMenuBackground;
    private TextMeshProUGUI GachaMenuText;

    private Color SelectedColor;    // ��ư�� ���� ���� �� ����

    public static Action UpdateResourcesText;   // ���� ���� �ڿ��� �ؽ�Ʈ�� �����ϴ� �̺�Ʈ
    public static Action UpdateStatTexts;       // �÷��̾� ���� �ؽ�Ʈ���� �����ϴ� �̺�Ʈ

    // Start is called before the first frame update
    void Start()
    {
        // �ʱ� ����
        Initialize();

        // �̺�Ʈ �Լ� �Ҵ�
        UpdateResourcesText += SetResourcesText;

        UpdateStatTexts += SetAttackText;
        UpdateStatTexts += SetDefenseText;
        UpdateStatTexts += SetHpText;
        UpdateStatTexts += SetCombatPowerText;

        // �ؽ�Ʈ �ʱ�ȭ
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
        SetMenuText("�ڿ�");
    }

    public void OnClickGachaMenuButton()
    {
        GachaMenu.SetActive(true);
        ResourcesMenu.SetActive(false);

        ChangeButtonColor(1);
        SetMenuText("�̱�");
    }

    void ChangeButtonColor(int menuNum)
    {
        // 0�� ��� �ڿ� �޴� ��ư�� ���� ������ ����
        if (0 == menuNum)
        {
            ResourcesMenuBackground.color = SelectedColor;
            ResourcesMenuText.color = Color.white;

            GachaMenuBackground.color = Color.white;
            GachaMenuText.color = Color.black;
        }
        // 1�� ��� �̱� �޴� ��ư�� ���� ������ ����
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
