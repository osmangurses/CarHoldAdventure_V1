using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftBoxFill : MonoBehaviour
{

    [SerializeField] Image coloredGiftBox;


    public void FillGiftBox(float fillAmount)
    {
        float lastFill = coloredGiftBox.fillAmount + fillAmount;
        DOTween.To(() => coloredGiftBox.fillAmount, x => coloredGiftBox.fillAmount = x, lastFill, 1)
       .SetEase(Ease.InExpo).SetDelay(0.9f).OnComplete(() =>
       transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce).SetDelay(0.5f)
       ) ;
    }
    public void ShowGiftBox()
    {
        transform.DOScale(Vector3.one*1,0.5f).SetEase(Ease.Flash);
    }
}
