using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CSVtoScriptableObject
{
    private static string ItemListCSVPath = "/CSV/ItemList.csv";

    [MenuItem("Custom Utilities/Generate ItemDatas")]
    public static void GenerateItemDatas()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + ItemListCSVPath);

        foreach (string allLine in allLines)
        {
            string[] splitData = allLine.Split(',');

            // ItemList.csv������ ó�� �� ���� �ǳʶڴ�
            int result = 0; // ����� �Ҵ�� ����(��� X)
            if (false == int.TryParse(splitData[0], out result))
            {
                continue;
            }

            if (splitData.Length != 5)
            {
                Debug.Log(allLine + "Does not have 5 values");
            }

            ItemData itemData = ScriptableObject.CreateInstance<ItemData>();
            itemData.n_ItemID = int.Parse(splitData[0]);
            itemData.e_ItemGrade = (ItemGrade)System.Enum.Parse(typeof(ItemGrade), splitData[1]);   // string���� enum������ ��ȯ
            itemData.e_ItemOptionType = (ItemOptionType)System.Enum.Parse(typeof(ItemOptionType), splitData[2]);
            itemData.n_DefaultValue = int.Parse(splitData[3]);
            itemData.s_IconPath = splitData[4];

            AssetDatabase.CreateAsset(itemData, $"Assets/ItemDatas/{itemData.n_ItemID}.asset");
        }

        AssetDatabase.SaveAssets();
    }
}
