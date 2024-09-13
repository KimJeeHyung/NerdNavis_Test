using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemData itemData;

    [SerializeField] private int n_ItemLevel = 1;
    [SerializeField] private TextMeshProUGUI ItemLevelText;

    // Start is called before the first frame update
    void Start()
    {
        ItemLevelText = GetComponentInChildren<TextMeshProUGUI>();
        ItemLevelText.text = "Lv. " + n_ItemLevel;

        //InitializePlayerStat();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializePlayerStat()
    {
        switch (itemData.e_ItemOptionType)
        {
            case ItemOptionType.AttackIncrease:
                Player.Instance.AddAttack(itemData.n_DefaultValue);
                break;
            case ItemOptionType.DefenseIncrease:
                Player.Instance.AddDefense(itemData.n_DefaultValue);
                break;
            case ItemOptionType.HpIncrease:
                Player.Instance.AddHp(itemData.n_DefaultValue);
                break;
        }
    }
}
