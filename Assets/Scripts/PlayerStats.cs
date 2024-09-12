using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // ���ݷ�
    [SerializeField] private int n_Attack;
    public int Attack { get { return n_Attack; } }
    // ����
    [SerializeField] private int n_Defense;
    public int Defense { get { return n_Defense; } }
    // ü��
    [SerializeField] private int n_Hp;
    public int Hp { get { return n_Hp; } }
    // ������(���ݷ� + ���� + HP)
    [SerializeField] private int n_CombatPower;
    public int CombatPower { get { return n_CombatPower; } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddAttack(int value)
    {
        n_Attack += value;
        UpdateCombatPower();
    }

    public void AddDefense(int value)
    {
        n_Defense += value;
        UpdateCombatPower();
    }

    public void AddHp(int value)
    {
        n_Hp += value;
        UpdateCombatPower();
    }

    void UpdateCombatPower()
    {
        n_CombatPower = n_Attack + n_Defense + n_Hp;
    }
}
