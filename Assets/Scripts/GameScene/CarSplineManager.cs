using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace _Game
{
    public class CarSplineManager : MonoBehaviour
    {
        [SerializeField] LevelDataHandler levelDataHandler;
        [SerializeField] TextMeshProUGUI timerOfLevelText;

        private TrailRenderer trailRenderer;
        private SplineFollower carSplineFollower;
        private int totalSpline, currentSpline;
        private bool isSplineFinished,isFirstMove;
        float timerOfLevel;


        private void Awake()
        {
        }
        private void Start()
        {
            carSplineFollower = GetComponent<SplineFollower>();
            trailRenderer = GetComponentInChildren<TrailRenderer>();
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
                    if (timerOfLevel>LevelDataHandler.Instance.levelData.levelCompleteTimeForStar)
                    {
                        EndPanelManager.Instance.FailedChallange(0);
                    }
                    LevelEventManager.OnLevelEnded(levelDataHandler.levelData, levelDataHandler.currentLevelIndex);
                }
            }
            else if (carSplineFollower.result.percent > 0f)
            {
                trailRenderer.emitting = true;
                isFirstMove = true;
            }
            if (isFirstMove&&!isSplineFinished)
            {
                timerOfLevel += Time.deltaTime;
                timerOfLevelText.text = timerOfLevel.ToString("F1");
            }

        }
    }
}
