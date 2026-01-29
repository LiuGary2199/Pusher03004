using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CedarWrapper : MonoWeightily<CedarWrapper>
{
    public string Hour;

    public void SinkCedar(string info)
    {
        Hour = info;
        UIManager.YewVocation().SinkUITruck(nameof(Cedar));
    }
}
