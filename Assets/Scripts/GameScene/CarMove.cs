using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck;
using Dreamteck.Splines;
using UnityEngine.SceneManagement;

public class CarMove : MonoBehaviour
{
    public bool isCrashed;

    [SerializeField] SplineFollower carSplineFollower;
    [SerializeField] Cars cars;
    [SerializeField] Transform cases;
    CarType selectedCar;
    bool _isMoving;

    private void Start()
    {
        SetSelectedCar();
    }
    void SetSelectedCar()
    {
        selectedCar = cars.CarTypes[PlayerPrefs.GetInt("SelectedCarIndex")];
        for (int i = 0; i < cars.CarTypes.Length; i++)
        {
            if (PlayerPrefs.GetInt("SelectedCarIndex") != i)
            {
                cases.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                cases.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
    private void Update()
    {
        if (!isCrashed)

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
        else
        {
            carSplineFollower.followSpeed = 0;
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
