using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq.Expressions;

public class MenuButtonControl : MonoBehaviour
{
    [SerializeField] private GameObject ResourcesMenu;
    [SerializeField] private GameObject GachaMenu;

    [SerializeField]
    private Button ResourcesMenuButton;
    private Image ResourcesMenuBackground;
    private TextMeshProUGUI ResourcesMenuText;

    [SerializeField]
    private Button GachaMenuButton;
    private Image GachaMenuBackground;
    private TextMeshProUGUI GachaMenuText;

    private Color SelectedColor;

    [SerializeField] private bool b_ResourcesMenuSelected = false;
    [SerializeField] private bool b_GachaMenuSelected = false;

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
    }

    public void OnClickGachaMenuButton()
    {
        GachaMenu.SetActive(true);
        ResourcesMenu.SetActive(false);

        GachaMenuBackground.color = SelectedColor;
        GachaMenuText.color = Color.white;

        ResourcesMenuBackground.color = Color.white;
        ResourcesMenuText.color = Color.black;
    }
}
