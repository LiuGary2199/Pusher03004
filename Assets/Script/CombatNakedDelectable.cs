using System;
using DG.Tweening;
using UnityEngine;

public class CombatNakedDelectable : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("posY")]    public float FarY;
[UnityEngine.Serialization.FormerlySerializedAs("stoneRadius")]    public float RadarAttack;
[UnityEngine.Serialization.FormerlySerializedAs("delayTime")]    public float TingeFast;
[UnityEngine.Serialization.FormerlySerializedAs("moveTime")]    public float TintFast;
[UnityEngine.Serialization.FormerlySerializedAs("movingFlog")]
    public bool IncomeRuin;

    private Sequence IncomeFin;

    private void Awake()
    {
        //delayTime = 2f;
    }

    private void Start()
    {
        transform.localPosition = new Vector3(-RadarAttack, FarY, -1.314f);
        CombatAil();
    }

    public void PlowCombat()
    {
        IncomeRuin = false;
        IncomeFin.Pause();
    }

    public void ReAloneCombat()
    {
        IncomeRuin = true;
        IncomeFin.Play();
    }

    private void CombatAil()
    {
        IncomeFin = DOTween.Sequence();
        IncomeFin.Append(transform.DOLocalMoveX(RadarAttack, TintFast).SetEase(Ease.InOutCubic));
        IncomeFin.AppendInterval(TingeFast);
        IncomeFin.Append(transform.DOLocalMoveX(-RadarAttack, TintFast).SetEase(Ease.InOutCubic));
        IncomeFin.AppendInterval(TingeFast);
        IncomeFin.SetLoops(-1);
        IncomeFin.Play();
    }



}