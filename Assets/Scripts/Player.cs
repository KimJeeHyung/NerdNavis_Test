using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player _instance = null;

    // 플레이어 데이터
    [SerializeField] private float f_CurrentResources = 500f;   // 보유한 자원량

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
        f_CurrentResources += value;
    }
}
