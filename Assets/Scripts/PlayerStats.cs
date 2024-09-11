using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int n_Attack;          // 공격력
    [SerializeField] private int n_Defense;         // 방어력
    [SerializeField] private int n_HP;              // 체력
    [SerializeField] private int n_CombatPower;     // 전투력(공격력 + 방어력 + HP)

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

    public int GetAttack()
    {
        return n_Attack;
    }

    public void AddDefense(int value)
    {
        n_Defense += value;
    }

    public int GetDefense()
    {
        return n_Defense;
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
