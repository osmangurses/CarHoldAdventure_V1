using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp : MonoBehaviour
{
    Transform clamp1,clamp2;
    public float closeSpeed, openSpeed,closedDuration,openDuration;
    private void Awake()
    {
        clamp1 = transform.GetChild(0);
        clamp2 = transform.GetChild(1);
        Open();

    }
    void Open()
    {
        clamp1.DOLocalMoveZ(9, 10 / openSpeed);
        clamp2.DOLocalMoveZ(-9, 10 / openSpeed);
        Invoke("Close",(10/openSpeed)+openDuration);
    }
    void Close()
    {
        clamp1.DOLocalMoveZ(3, 10 / closeSpeed);
        clamp2.DOLocalMoveZ(-3, 10 / closeSpeed);
        Invoke("Open", (10 / closeSpeed)+closedDuration);
    }
}
