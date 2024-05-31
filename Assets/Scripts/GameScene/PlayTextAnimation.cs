using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTextAnimation : MonoBehaviour
{

    [SerializeField] float blinkSpeed;
    private void Start()
    {
        Blink();
    }
    void Blink()
    {
        transform.DOScale(0.6f*Vector3.one,blinkSpeed/2).OnComplete(()=> transform.DOScale(1f * Vector3.one, blinkSpeed / 2).SetEase(Ease.Linear)).SetEase(Ease.Linear);
        Invoke(nameof(Blink),blinkSpeed);
    }
}
