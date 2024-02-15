using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck;
using Dreamteck.Splines;
using UnityEngine.SceneManagement;

public class CarMove : MonoBehaviour
{
    [SerializeField] SplineFollower carSplineFollower;
    [SerializeField] CarType selectedCar;
    bool _isMoving;

    private void Update()
    {
        if (_isMoving)
        {
            UpSpeed();
        }
        else
        {
            DownSpeed();
        }
    }
    public void SetIsMoving(bool isMoving)
    {
        _isMoving = isMoving;
    }
    void UpSpeed()
    {
        if (carSplineFollower.followSpeed <= selectedCar.speed)
        {
            carSplineFollower.followSpeed += (selectedCar.speed / selectedCar.speedUpDuration) * Time.deltaTime;
        }
    }
    void DownSpeed()
    {
        if (carSplineFollower.followSpeed > 0)
        {
            carSplineFollower.followSpeed -= (selectedCar.speed / selectedCar.stopDuration) * Time.deltaTime;
            if (carSplineFollower.followSpeed < 0)
            {
                carSplineFollower.followSpeed = 0.1f;
                carSplineFollower.followSpeed = 0;

            }
        }
    }
}
