using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemGrade { Normal, Rare, Epic };
public enum ItemOptionType { AttackIncrease, DefenseIncrease, HpIncrease };

public class ItemData : ScriptableObject
{
    public int n_ItemID;                    // ������ ���� ID
    public ItemGrade e_ItemGrade;           // ������ ���
    public ItemOptionType e_ItemOptionType; // ������ �ɼ�
    public int n_DefaultValue;              // 1���� �⺻ �ɷ�ġ ��
    public string s_IconPath;               // ������ ���
}
