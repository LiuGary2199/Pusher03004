using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 消息传递的参数
/// </summary>
public class CorrectHall
{
    /*
     *  1.创建独立的消息传递数据结构，而不使用object，是为了避免数据传递时的类型强转
     *  2.制作过程中遇到实际需要传递的数据类型，在这里定义即可
     *  3.实际项目中需要传递参数的类型其实并没有很多种，这种方式基本可以满足需求
     */
    public bool ClothShop;
    public bool ClothShop2;
    public int ClothSow;
    public int ClothSow2;
    public int ClothSow3;
    public float ClothBylaw;
    public float ClothBylaw2;
    public double ClothIndigo;
    public double ClothIndigo2;
    public string ClothCarpet;
    public string ClothCarpet2;
    public GameObject ClothUtahOutlet;
    public GameObject ClothUtahOutlet2;
    public GameObject ClothUtahOutlet3;
    public GameObject ClothUtahOutlet4;
    public Transform ClothPolitical;
    public List<string> ClothCarpetGerm;
    public List<Vector2> ClothNss2Germ;
    public List<int> ClothSowGerm;
    public System.Action ConciseKierRear;
    public Vector2 Cue2_1;
    public Vector2 Cue2_2;
    public CorrectHall()
    {
    }
    public CorrectHall(Vector2 v2_1)
    {
        Cue2_1 = v2_1;
    }
    public CorrectHall(Vector2 v2_1, Vector2 v2_2)
    {
        Cue2_1 = v2_1;
        Cue2_2 = v2_2;
    }
    /// <summary>
    /// 创建一个带bool类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public CorrectHall(bool value)
    {
        ClothShop = value;
    }
    public CorrectHall(bool value, bool value2)
    {
        ClothShop = value;
        ClothShop2 = value2;
    }
    /// <summary>
    /// 创建一个带int类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public CorrectHall(int value)
    {
        ClothSow = value;
    }
    public CorrectHall(int value, int value2)
    {
        ClothSow = value;
        ClothSow2 = value2;
    }
    public CorrectHall(int value, int value2, int value3)
    {
        ClothSow = value;
        ClothSow2 = value2;
        ClothSow3 = value3;
    }
    public CorrectHall(List<int> value,List<Vector2> value2)
    {
        ClothSowGerm = value;
        ClothNss2Germ = value2;
    }
    /// <summary>
    /// 创建一个带float类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public CorrectHall(float value)
    {
        ClothBylaw = value;
    }
    public CorrectHall(float value,float value2)
    {
        ClothBylaw = value;
        ClothBylaw = value2;
    }
    /// <summary>
    /// 创建一个带double类型的数据
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public CorrectHall(double value)
    {
        ClothIndigo = value;
    }
    public CorrectHall(double value, double value2)
    {
        ClothIndigo = value;
        ClothIndigo = value2;
    }
    /// <summary>
    /// 创建一个带string类型的数据
    /// </summary>
    /// <param name="value"></param>
    public CorrectHall(string value)
    {
        ClothCarpet = value;
    }
    /// <summary>
    /// 创建两个带string类型的数据
    /// </summary>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    public CorrectHall(string value1,string value2)
    {
        ClothCarpet = value1;
        ClothCarpet2 = value2;
    }
    public CorrectHall(GameObject value1)
    {
        ClothUtahOutlet = value1;
    }

    public CorrectHall(Transform transform)
    {
        ClothPolitical = transform;
    }
}

