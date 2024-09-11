using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    // 자원 데이터
    [SerializeField] private int n_CurrentResources = 500;  // 보유한 자원량
    [SerializeField] private int n_Maximum = 100000;        // 최대 보유량

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
