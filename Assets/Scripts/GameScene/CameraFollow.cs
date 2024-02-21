using DG.Tweening;
using UnityEditor;
using UnityEngine;

namespace _Game
{
    public class CameraFollow : MonoBehaviour
    {
        public GameObject GameplayCam, QuestionCam, StartCam;
        private void Start()
        {
            Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;
            StartCam.SetActive(false);
        }
        void OnEnable()
        {
            LevelEventManager.LevelEnded += SetBirdEye;
        }
        private void OnDisable()
        {
            LevelEventManager.LevelEnded -= SetBirdEye;
        }
        void SetBirdEye(LevelData lvData, int lvIndex)
        {
            QuestionCam.SetActive(true);
        }
    }
}

