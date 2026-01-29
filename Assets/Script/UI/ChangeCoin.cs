using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCoin : LastUITruck
{
    public Button ChangeBtn;
    public Button CanNotBtn;
    public Button CloseBtn;
    public Text CashText;
    public Text CoinText;
    public Transform FlapRed;
    private void Start()
    {
        CanNotBtn.onClick.AddListener(() =>
        {
            CedarWrapper.YewVocation().SinkCedar("Not enough gold coins");
        });
        ChangeBtn.onClick.AddListener(() =>
        {
            ChangeBtn.enabled = false;
            double haveCoin = UtahHallWrapper.YewVocation().YewNeon();
            double coinNeed = MudHourJaw.instance.Exchange[0];
            double cashNeed = MudHourJaw.instance.Exchange[1];
            if (haveCoin >= coinNeed)
            {
                UtahHallWrapper.YewVocation().YewNeon(- coinNeed);
               // UtahHallWrapper.YewVocation().YewSuch( cashNeed);
                CedarWrapper.YewVocation().SinkCedar("Exchange successful");
                UtahScore.Instance.GeneticEncase();
                UtahScore.Instance.YewSuch(cashNeed, FlapRed.transform);
                PianoUIArid(GetType().Name);
            }
            else
            {
                
                CedarWrapper.YewVocation().SinkCedar("Not enough gold coins");
            }
            RefUI();
        });
        CloseBtn.onClick.AddListener(() =>
        {
            PianoUIArid(GetType().Name);
        });

    }
    public override void Display()
    {
        base.Display();
        BeauWrapper.Instance.UtahPlow();
        RefUI();
    }

    public void RefUI()
    {
        ChangeBtn.enabled = true;
        double haveCoin = UtahHallWrapper.YewVocation().YewNeon();
        double coinNeed = MudHourJaw.instance.Exchange[0];
        double cashNeed = MudHourJaw.instance.Exchange[1];
        CashText.text = cashNeed.ToString();
        CoinText.text = coinNeed.ToString();
        if (haveCoin >= coinNeed)
        {
            CanNotBtn.gameObject.SetActive(false);
        }
        else
        {
            CanNotBtn.gameObject.SetActive(true);
        }
    }

    public override void Hidding()
    {
        base.Hidding();
        BeauWrapper.Instance.UtahRestart();
    }
}
