/**
 * 
 * 网络请求的post对象
 * 
 * ***/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class MudFailDaleOutlet 
{
    //post请求地址
    public string URL;
    //post的数据表单
    public WWWForm Arid;
    //post成功回调
    public Action<UnityWebRequest> DaleSlander;
    //post失败回调
    public Action DaleChip;
    public MudFailDaleOutlet(string url,WWWForm  form,Action<UnityWebRequest> success,Action fail)
    {
        URL = url;
        Arid = form;
        DaleSlander = success;
        DaleChip = fail;
    }
}
