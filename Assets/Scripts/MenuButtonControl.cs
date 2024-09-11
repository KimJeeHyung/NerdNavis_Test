using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq.Expressions;

public class MenuButtonControl : MonoBehaviour
{
    [Header("Menu Objects")]
    [SerializeField] private GameObject ResourcesMenu;  // 자원 메뉴
    [SerializeField] private GameObject GachaMenu;      // 뽑기 메뉴
    [SerializeField] private TextMeshProUGUI MenuText;  // 현재 메뉴를 표시하는 텍스트

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

    //[SerializeField] private bool b_ResourcesMenuSelected = false;
    //[SerializeField] private bool b_GachaMenuSelected = false;

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickResourcesMenuButton()
    {
        ResourcesMenu.SetActive(true);
        GachaMenu.SetActive(false);

        ResourcesMenuBackground.color = SelectedColor;
        ResourcesMenuText.color = Color.white;

        GachaMenuBackground.color = Color.white;
        GachaMenuText.color = Color.black;

        MenuText.text = "자원";
    }

    public void OnClickGachaMenuButton()
    {
        GachaMenu.SetActive(true);
        ResourcesMenu.SetActive(false);

        GachaMenuBackground.color = SelectedColor;
        GachaMenuText.color = Color.white;

        ResourcesMenuBackground.color = Color.white;
        ResourcesMenuText.color = Color.black;

        MenuText.text = "뽑기";
    }
}
