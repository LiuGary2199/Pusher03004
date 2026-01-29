// Project: Plinko
// FileName: BellKingDelectable.cs
// Author: AX
// CreateDate: 20230526
// CreateTime: 15:19
// Description:

using System;
using DG.Tweening;
using UnityEngine;

    public class BellKingDelectable : MonoBehaviour
    {
[UnityEngine.Serialization.FormerlySerializedAs("handImg")]        public GameObject HeelRed;

        private void Start()
        {
            AloneFair();
        }

        private void AloneFair()
        {
           Sequence  handSeq = DOTween.Sequence();
           handSeq.Append(HeelRed.transform.DOLocalMoveY(25f, 0.3f)).SetEase(Ease.InSine);;
           handSeq.Append(HeelRed.transform.DOLocalMoveY(0f, 0.3f)).SetEase(Ease.InSine);;
           handSeq.SetLoops(-1);
           handSeq.Play();
        }

    }
