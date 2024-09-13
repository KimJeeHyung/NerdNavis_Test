using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class GachaManager : MonoBehaviour
{
    // 등급별 뽑기 확률
    const int n_NormalGachaRate = 52;
    const int n_RareGachaRate = 33;
    const int n_EpicGachaRate = 15;
    private int[] GradePercentages= new int[3] { n_NormalGachaRate, n_RareGachaRate, n_EpicGachaRate };

    // 결과값 확인용 배열
    int[] gachaResult = new int[3] { 0, 0, 0 };

    // 뽑을 아이템 타입
    // 100: 무기
    // 200: 방어구
    // 300: 장신구
    [SerializeField] private int n_ItemType = 100;
    public int ItemType { get { return n_ItemType; } set { n_ItemType = value; } }

    // 뽑아서 나온 아이템의 ID의 끝자리
    [SerializeField] private int n_EndItemID = 0;

    [SerializeField] private List<GameObject> WeaponList;
    [SerializeField] private List<GameObject> ArmorList;
    [SerializeField] private List<GameObject> ShieldList;

    // Start is called before the first frame update
    void Start()
    {
        //Gacha(100000000);
        DisableAllItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Gacha(int count)
    {
        // 보유 자원이 뽑기에 필요한 자원보다 적으면 리턴
        if (Player.Instance.GetResources() < count * 100)
        {
            return;
        }

        // 뽑기에 필요한 자원만큼 차감 후 텍스트 갱신
        Consume(count * 100);

        // 결과값 배열 초기화
        System.Array.Clear(gachaResult, 0, gachaResult.Length);

        // count만큼 뽑기 시행
        for (int i = 0; i < count; i++)
        {
            GachaOneTime();
        }

        // 결과값 확인용 함수
        ShowGachaResult(count);
    }

    void GachaOneTime()
    {
        n_EndItemID = 0;

        // 난수를 이용해 랜덤한 아이템 ID 선택
        // SelectGrade함수에서 리턴한 ID 끝자리를 통해
        // 3종류(무기, 방어구, 장신구) 중 하나의 아이템이 목록에서 활성화됨
        n_EndItemID = SelectGrade();
        ActivateItem();
    }

    int SelectGrade()
    {
        // 정수형 난수 생성
        int randomInt = Random.Range(0, 100) + 1;

        // 생성한 난수로 확률 범위에 일치하게 등급 판정
        int percentage = 0;
        int grade = -1;
        for (int i = 0; i < GradePercentages.Length; i++)
        {
            percentage += GradePercentages[i];
            if (randomInt <= percentage)
            {
                grade = i;
                gachaResult[i]++;
                break;
            }
        }

        // 선택된 등급 내 아이템 중 하나의 ID 끝자리를 리턴
        return SelectItem(grade);
    }

    int SelectItem(int grade)
    {
        if(-1 == grade)
        {
            Debug.Log("잘못된 등급 입력");
            return -1;
        }

        // 리턴할 아이템 ID 끝자리
        int result = -1;

        // Normal 등급
        if (0 == grade)
        {
            result = Random.Range(0, 5) + 1;
        }
        // Rare 등급
        else if (1 == grade)
        {
            result = Random.Range(0, 3) + 6;
        }
        // Epic 등급
        else
        {
            result = Random.Range(0, 2) + 9;
        }

        return result;
    }

    void ShowGachaResult(int count)
    {
        // 뽑기 결과를 백분율로 출력
        float[] percentage = new float[3];
        percentage[0] = gachaResult[0] * 100f / count;
        percentage[1] = gachaResult[1] * 100f / count;
        percentage[2] = gachaResult[2] * 100f / count;

        Debug.Log($"Normal: {percentage[0]}     Rare: {percentage[1]}     Epic: {percentage[2]}");
    }

    void Consume(int resources)
    {
        Player.Instance.SubtractResources(resources);
        MenuManager.UpdateResourcesText();
    }

    void DisableAllItems()
    {
        foreach (GameObject item in WeaponList)
        {
            item.SetActive(false);
        }
        foreach (GameObject item in ArmorList)
        {
            item.SetActive(false);
        }
        foreach (GameObject item in ShieldList)
        {
            item.SetActive(false);
        }
    }

    void ActivateItem()
    {
        switch (n_ItemType)
        {
            case 100:
                WeaponList[n_EndItemID - 1].SetActive(true);
                break;
            case 200:
                ArmorList[n_EndItemID - 1].SetActive(true);
                break;
            case 300:
                ShieldList[n_EndItemID - 1].SetActive(true);
                break;
        }
    }
}
