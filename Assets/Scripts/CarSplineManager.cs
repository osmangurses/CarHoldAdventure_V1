using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game
{
    public class CarSplineManager : MonoBehaviour
    {
        [SerializeField] LevelDataHandler levelDataHandler;

        private TrailRenderer trailRenderer;
        private SplineFollower carSplineFollower;
        private int totalSpline, currentSpline;
        private bool isSplineFinished;


        private void Awake()
        {
            carSplineFollower = GetComponent<SplineFollower>();
            trailRenderer = GetComponentInChildren<TrailRenderer>();
        }
        private void Start()
        {
            totalSpline = levelDataHandler.levelPaths.Length - 1;
            carSplineFollower.spline = levelDataHandler.levelPaths[currentSpline];
        }

        private void Update()
        {


            if (!isSplineFinished&& carSplineFollower.result.percent >= 0.99f)
            {
                if (currentSpline < totalSpline)
                {
                    if (trailRenderer.emitting == false)
                    {
                        currentSpline++;
                        carSplineFollower.spline = levelDataHandler.levelPaths[currentSpline];
                        carSplineFollower.followSpeed = 0;
                        carSplineFollower.SetDistance(0);

                    }

                    trailRenderer.emitting = false;
                }
                else
                {
                    isSplineFinished = true;
                    LevelEventManager.OnLevelEnded(levelDataHandler.levelData, levelDataHandler.currentLevelIndex);
                }
            }
            else if (carSplineFollower.result.percent > 0f)
            {
                trailRenderer.emitting = true;
            }

        }
    }
}
