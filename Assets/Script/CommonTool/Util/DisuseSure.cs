using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class DisuseSure
{
    public static string IndigoMeLap(double a)
    {
        return Math.Round(a, KettleScream.TraitSeason).ToString();
    }

    public static double Trait(double a)
    {
        return Math.Round(a, KettleScream.TraitSeason);
    }

    public static double FoeRodent(string key)
    {
        double result = 0;
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.NumberDecimalSeparator = ",";

        if (double.TryParse(key, NumberStyles.Any, nfi, out result))
        {
            Debug.Log($"转换结果: {result}");
        }
        else
        {
            Debug.Log($"转换失败:" + key);
        }
        return string.IsNullOrEmpty(key) ? 0 : result;
    }
    public static float LopRodentBylaw(string key)
    {
        float result = 0;
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.NumberDecimalSeparator = ",";

        if (float.TryParse(key, NumberStyles.Any, nfi, out result))
        {
            Debug.Log($"转换结果: {result}");
        }
        else
        {
            Debug.Log($"转换失败: {key}");
        }
        return string.IsNullOrEmpty(key) ? 0 : result;
    }
}
