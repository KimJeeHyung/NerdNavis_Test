public static class NumberControl
{
    public static string FormatWithUnit(float value)
    {
        string formattedValue;

        // 값이 100만 이상일 경우 m단위로 변환
        if (value >= 1000000f)
        {
            formattedValue = (value / 1000000f).ToString("F2");
            formattedValue = RemoveTrailingZeros(formattedValue) + "m";
        }
        // 값이 1000 이상일 경우 k단위로 변환
        else if (value >= 1000f)
        {
            formattedValue = (value / 1000f).ToString("F2");
            formattedValue = RemoveTrailingZeros(formattedValue) + "k";
        }
        // 1000미만일 경우
        else
        {
            formattedValue = value.ToString("F2");
            formattedValue = RemoveTrailingZeros(formattedValue);
        }

        return formattedValue;
    }

    // 소수점 끝자리에 있는 0을 제거하는 함수
    public static string RemoveTrailingZeros(string str)
    {
        // 소수점과 자릿수가 있는 경우에만 처리
        if (str.Contains("."))
        {
            str = str.TrimEnd('0').TrimEnd('.');
        }

        return str;
    }
}
