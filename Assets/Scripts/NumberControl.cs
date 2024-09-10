public static class NumberControl
{
    public static string FormatWithUnit(float value)
    {
        string formattedValue;

        // ���� 100�� �̻��� ��� m������ ��ȯ
        if (value >= 1000000f)
        {
            formattedValue = (value / 1000000f).ToString("F2");
            formattedValue = RemoveTrailingZeros(formattedValue) + "m";
        }
        // ���� 1000 �̻��� ��� k������ ��ȯ
        else if (value >= 1000f)
        {
            formattedValue = (value / 1000f).ToString("F2");
            formattedValue = RemoveTrailingZeros(formattedValue) + "k";
        }
        // 1000�̸��� ���
        else
        {
            formattedValue = value.ToString("F2");
            formattedValue = RemoveTrailingZeros(formattedValue);
        }

        return formattedValue;
    }

    // �Ҽ��� ���ڸ��� �ִ� 0�� �����ϴ� �Լ�
    public static string RemoveTrailingZeros(string str)
    {
        // �Ҽ����� �ڸ����� �ִ� ��쿡�� ó��
        if (str.Contains("."))
        {
            str = str.TrimEnd('0').TrimEnd('.');
        }

        return str;
    }
}
