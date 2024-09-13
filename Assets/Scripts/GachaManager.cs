using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaManager : MonoBehaviour
{
    // ��޺� �̱� Ȯ��
    const int n_NormalGachaRate = 52;
    const int n_RareGachaRate = 33;
    const int n_EpicGachaRate = 15;

    private int[] GradePercentages= new int[3] { n_NormalGachaRate, n_RareGachaRate, n_EpicGachaRate };

    int[] gachaResult = new int[3] { 0, 0, 0 };

    // Start is called before the first frame update
    void Start()
    {
        Gacha(100000000, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Gacha(int count, int itemType)
    {
        for (int i = 0; i < count; i++)
        {
            GachaOneTime(itemType);
        }

        ShowGachaResult(count);
    }

    void GachaOneTime(int itemType)
    {
        int resultID = 0;

        // ������ �̿��� ������ ������ ID ����
        // SelectGrade�Լ����� ������ ���ڸ��� itemType�� ����
        // 3����(����, ��, ��ű�) �� �ϳ��� ��� �̱⸦ �� �� ����
        resultID = SelectGrade() + itemType;
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
}
