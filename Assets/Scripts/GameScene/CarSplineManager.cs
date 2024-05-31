using DG.Tweening;
using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Game
{
    public class CarSplineManager : MonoBehaviour
    {
        public static CarSplineManager instance;
        [SerializeField] LevelDataHandler levelDataHandler;
        [SerializeField] Image timerFill;

        private TrailRenderer trailRenderer;
        private SplineFollower carSplineFollower;
        private int totalSpline, currentSpline;
        private bool isTimerShaked;
        float timerOfLevel;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            carSplineFollower = GetComponent<SplineFollower>();
            trailRenderer = GetComponentInChildren<TrailRenderer>();
            totalSpline = levelDataHandler.levelPaths.Length - 1;
            carSplineFollower.spline = levelDataHandler.levelPaths[currentSpline];
        }

        void SetTimer()
        {
            if (CarStatEnum.stat == Stats.Playing)
            {
                timerOfLevel += Time.deltaTime;
                timerFill.fillAmount = (LevelDataHandler.Instance.levelData.levelCompleteTimeForStar - timerOfLevel) / LevelDataHandler.Instance.levelData.levelCompleteTimeForStar;
                timerFill.color = new Color(Mathf.Abs(timerFill.fillAmount - 1), timerFill.fillAmount, 0);
                if (timerFill.fillAmount < 0.1f && timerFill.fillAmount > 0 && !isTimerShaked)
                {
                    timerFill.transform.parent.transform.DOShakePosition(10, 2, 5, 90);
                    isTimerShaked = true;
                    AudioPlayer.instance.PlayAudio(AudioName.CompleteTimeError);
                }
            }
        }
        void ManageSplineAndTrail()
        {
            if (CarStatEnum.stat == Stats.Playing)
            {
                if (carSplineFollower.result.percent >= 0.99f)
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
                        if (timerOfLevel <= LevelDataHandler.Instance.levelData.levelCompleteTimeForStar)
                        {
                            EndPanelManager.Instance.CompletedChallange(0);
                        }
                        LevelEventManager.OnLevelEnded(levelDataHandler.levelData, levelDataHandler.currentLevelIndex);
                    }
                    CarStatEnum.stat = Stats.Ended;
                    
                }
                else if (carSplineFollower.result.percent > 0f)
                {
                    trailRenderer.emitting = true;
                }
            }
            
        }
        private void Update()
        {
            ManageSplineAndTrail();
            SetTimer();
        }
    }
}
