using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player _instance = null;

    // �÷��̾� �ڿ� ���� Ŭ����
    [SerializeField]
    private PlayerResources playerResources;

    // �÷��̾� ���� ���� Ŭ����
    [SerializeField]
    private PlayerStats playerStats;


    public static Player Instance
    {
        get
        {
            if (null == _instance)
            {
                SetUpInstance();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (null == _instance)
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void SetUpInstance()
    {
        _instance = FindObjectOfType<Player>();

        if (null == _instance)
        {
            GameObject player = new GameObject();
            player.name = "Player";
            _instance = player.AddComponent<Player>();
        }
    }

    public void AddResources(int value)
    {
        playerResources.AddResources(value);
    }

    public int GetResources()
    {
        return playerResources.CurrentResources;
    }

    public bool IsMaximum()
    {
        return playerResources.IsMaximum();
    }

    public int GetAttack()
    {
        return playerStats.Attack;
    }

    public int GetDefense()
    {
        return playerStats.Defense;
    }

    public int GetHp()
    {
        return playerStats.Hp;
    }

    public int GetCombatPower()
    {
        return playerStats.CombatPower;
    }
}
