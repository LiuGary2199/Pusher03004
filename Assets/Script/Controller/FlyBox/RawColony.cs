using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Random = UnityEngine.Random;

public class RawColony : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("boxImg")]    public GameObject AntRed;
[UnityEngine.Serialization.FormerlySerializedAs("boxBtn")]    public Button AntFew;
[UnityEngine.Serialization.FormerlySerializedAs("bubbleGifImage")]    public GameObject FacadeBitHoney;
    private Sequence _Boy1;
    private Sequence _Boy2;


    void Start()
    {
        RawHerbEnough();

        AntFew.onClick.AddListener(() =>
        {
            PayEnough();
            RawPegDelectable.Instance.SinkKrillScore();
        });
    }


    public void RawDecay()
    {
        HubFewKinglet();
        transform.DOPause();
        _Boy1.Pause();
        _Boy2.Pause();
    }

    public void RawInvent()
    {
        HubFewCausal();
        transform.DOPlay();
        _Boy1.Play();
        _Boy2.Play();
    }

    public void HubFewCausal()
    {
        AntFew.enabled = true;
    }

    public void HubFewKinglet()
    {
        AntFew.enabled = false;
    }

    private void PayEnough()
    {
        AntRed.SetActive(false);
        AntFew.gameObject.SetActive(false);
        FacadeBitHoney.SetActive(true);
    }


    private void RawHerbEnough()
    {
        _Boy1 = DOTween.Sequence();
        _Boy2 = DOTween.Sequence();
        int leftOrRight = Random.Range(0, 2);
        if (leftOrRight == 0)
        {
            transform.localPosition = new Vector3(-450f, 0, 0);
            _Boy1.Append(transform.DOLocalMoveY(150f + Random.Range(-50f, 50f), 2.5f).SetEase(Ease.InSine));
            _Boy1.Append(transform.DOLocalMoveY(0, 2.5f).SetEase(Ease.InSine));
            _Boy1.SetLoops(-1);
            _Boy1.Play();

            _Boy2.Append(transform.DOScale(1.4f, 0.5f).SetEase(Ease.Linear));
            _Boy2.Append(transform.DOScale(1.3f, 0.5f).SetEase(Ease.Linear));
            _Boy2.SetLoops(-1);
            _Boy2.Play();
            transform.DOLocalMoveX(450, 10f).SetEase(Ease.Linear).OnComplete(() =>
            {
                _Boy1.Kill();
                _Boy2.Kill();
                transform.DOKill();
                GetComponent<RectTransform>().DOKill();
                Destroy(gameObject);
            });
        }
        else
        {
            transform.localPosition = new Vector3(450, 0, 0);
            _Boy1.Append(transform.DOLocalMoveY(150f + Random.Range(-50f, 50f), 2.5f).SetEase(Ease.InSine));
            _Boy1.Append(transform.DOLocalMoveY(0, 2.5f).SetEase(Ease.InSine));
            _Boy1.SetLoops(-1);
            _Boy1.Play();

            _Boy2.Append(transform.DOScale(1.4f, 0.5f).SetEase(Ease.Linear));
            _Boy2.Append(transform.DOScale(1.3f, 0.5f).SetEase(Ease.Linear));
            _Boy2.SetLoops(-1);
            _Boy2.Play();
            transform.DOLocalMoveX(-450, 10f).SetEase(Ease.Linear).OnComplete(() =>
            {
                _Boy1.Kill();
                _Boy2.Kill();
                transform.DOKill();
                GetComponent<RectTransform>().DOKill();
                Destroy(gameObject);
            });
        }
    }
}