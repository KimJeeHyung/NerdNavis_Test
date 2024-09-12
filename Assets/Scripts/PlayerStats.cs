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
    [SerializeField] private int n_HP;
    public int HP { get { return n_HP; } }
    // ������(���ݷ� + ���� + HP)
    [SerializeField] private int n_CombatPower;

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
    }

    public void AddDefense(int value)
    {
        n_Defense += value;
    }

    public void AddHP(int value)
    {
        n_HP += value;
    }

    public int GetHP()
    {
        return n_HP;
    }

    public int GetCombatPower()
    {
        n_CombatPower = n_Attack + n_Defense + n_HP;

        return n_CombatPower;
    }
}
