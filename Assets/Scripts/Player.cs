using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player _instance = null;


    // 플레이어 데이터
    [SerializeField] private int n_CurrentResources = 500;  // 보유한 자원량
    [SerializeField] private int n_Maximum = 100000;        // 최대 보유량

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
        n_CurrentResources += value;
    }

    public int GetResources()
    {
        return n_CurrentResources;
    }

    public bool IsMaximum()
    {
        return n_CurrentResources >= n_Maximum;
    }
}
