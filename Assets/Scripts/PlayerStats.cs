using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // 공격력
    [SerializeField] private int n_Attack;
    public int Attack { get { return n_Attack; } }
    // 방어력
    [SerializeField] private int n_Defense;
    public int Defense { get { return n_Defense; } }
    // 체력
    [SerializeField] private int n_HP;
    public int HP { get { return n_HP; } }
    // 전투력(공격력 + 방어력 + HP)
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
