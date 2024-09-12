using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemGrade { Normal, Rare, Epic };
public enum ItemOptionType { AttackIncrease, DefenseIncrease, HpIncrease };

public class ItemData : ScriptableObject
{
    public int n_ItemID;                    // 아이템 고유 ID
    public ItemGrade e_ItemGrade;           // 아이템 등급
    public ItemOptionType e_ItemOptionType; // 아이템 옵션
    public int n_DefaultValue;              // 1레벨 기본 능력치 값
    public string s_IconPath;               // 아이콘 경로
}
