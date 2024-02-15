using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    Transform clamp1;
    public float upSpeed, fallSpeed,falledDuration,uppedDuration;
    private void Awake()
    {
        clamp1 = transform.GetChild(0);
        Up();

    }
    void Up()
    {
        clamp1.DOLocalMoveY(10, 10 / upSpeed);
        Invoke("Down", (10 / upSpeed)+uppedDuration);
    }
    void Down()
    {
        clamp1.DOLocalMoveY(2, 10 / fallSpeed);
        Invoke("Up", (10 / fallSpeed)+falledDuration);
    }
}
