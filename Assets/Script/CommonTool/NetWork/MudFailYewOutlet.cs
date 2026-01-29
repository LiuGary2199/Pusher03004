/***
 * 
 * 网络请求的get对象
 * 
 * **/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class MudFailYewOutlet 
{
    //get的url
    public string Sum;
    //get成功的回调
    public Action<UnityWebRequest> YewSlander;
    //get失败的回调
    public Action YewChip;
    public MudFailYewOutlet(string url,Action<UnityWebRequest> success,Action fail)
    {
        Sum = url;
        YewSlander = success;
        YewChip = fail;
    }
   
}
