using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMovement : MonoBehaviour
{
    [SerializeField] Transform[] PathPoints;
    [SerializeField] float speed;

    int pointIndex;
    private void Start()
    {
        Move();
    }
    void Move()
    {
        if (pointIndex < PathPoints.Length)
        {
            transform.DOMove(PathPoints[pointIndex].position, 100 / speed).SetEase(Ease.Linear).OnComplete(() => Move());
            transform.DOLocalRotate(transform.rotation.eulerAngles+(Vector3.up*180),100/speed).SetEase(Ease.Linear);
            pointIndex++;
        }
        else
        {
            pointIndex = 0;
            Move();
        }
    }
}
