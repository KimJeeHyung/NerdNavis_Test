using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class GachaManager : MonoBehaviour
{
    // ��޺� �̱� Ȯ��
    const int n_NormalGachaRate = 52;
    const int n_RareGachaRate = 33;
    const int n_EpicGachaRate = 15;
    private int[] GradePercentages= new int[3] { n_NormalGachaRate, n_RareGachaRate, n_EpicGachaRate };

    // ����� Ȯ�ο� �迭
    int[] gachaResult = new int[3] { 0, 0, 0 };

    // ���� ������ Ÿ��
    // 100: ����
    // 200: ��
    // 300: ��ű�
    [SerializeField] private int n_ItemType = 100;
    public int ItemType { get { return n_ItemType; } set { n_ItemType = value; } }

    // �̾Ƽ� ���� �������� ID�� ���ڸ�
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
        // ���� �ڿ��� �̱⿡ �ʿ��� �ڿ����� ������ ����
        if (Player.Instance.GetResources() < count * 100)
        {
            return;
        }

        // �̱⿡ �ʿ��� �ڿ���ŭ ���� �� �ؽ�Ʈ ����
        Consume(count * 100);

        // ����� �迭 �ʱ�ȭ
        System.Array.Clear(gachaResult, 0, gachaResult.Length);

        // count��ŭ �̱� ����
        for (int i = 0; i < count; i++)
        {
            GachaOneTime();
        }

        // ����� Ȯ�ο� �Լ�
        ShowGachaResult(count);
    }

    void GachaOneTime()
    {
        n_EndItemID = 0;

        // ������ �̿��� ������ ������ ID ����
        // SelectGrade�Լ����� ������ ID ���ڸ��� ����
        // 3����(����, ��, ��ű�) �� �ϳ��� �������� ��Ͽ��� Ȱ��ȭ��
        n_EndItemID = SelectGrade();
        ActivateItem();
    }

    int SelectGrade()
    {
        // ������ ���� ����
        int randomInt = Random.Range(0, 100) + 1;

        // ������ ������ Ȯ�� ������ ��ġ�ϰ� ��� ����
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

        // ���õ� ��� �� ������ �� �ϳ��� ID ���ڸ��� ����
        return SelectItem(grade);
    }

    int SelectItem(int grade)
    {
        if(-1 == grade)
        {
            Debug.Log("�߸��� ��� �Է�");
            return -1;
        }

        // ������ ������ ID ���ڸ�
        int result = -1;

        // Normal ���
        if (0 == grade)
        {
            result = Random.Range(0, 5) + 1;
        }
        // Rare ���
        else if (1 == grade)
        {
            result = Random.Range(0, 3) + 6;
        }
        // Epic ���
        else
        {
            result = Random.Range(0, 2) + 9;
        }

        return result;
    }

    void ShowGachaResult(int count)
    {
        // �̱� ����� ������� ���
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
