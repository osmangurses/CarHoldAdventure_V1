using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace _Game
{
    public class EndPanelManager : MonoBehaviour
    {
        public static EndPanelManager Instance;


        [SerializeField] Image[] _stars;
        [SerializeField] Image[] challangeResults;
        [SerializeField] Image _referanceStar;
        [SerializeField] Sprite challangeFailedIcon;
        [SerializeField] float _starAnimationTime;
        [SerializeField] GameObject _endPanel;

        int _starCount;
        private void Awake()
        {
            _starCount=_stars.Length;
        }
        private void Start()
        {
            Instance = this;
        }

        public void FailedChallange(int challangeIndex)
        {
            challangeResults[challangeIndex].sprite = challangeFailedIcon;
            challangeResults[challangeIndex].color=Color.red;
            _starCount--;
        }
        void AnimateStar(int index, float delay)
        {

            _stars[index].transform.DOScale(_referanceStar.transform.localScale * 10f, 0).SetDelay(delay);
            _stars[index].DOFade(0, 0);
            _stars[index].DOFade(1, _starAnimationTime).SetDelay(delay);
            _stars[index].transform.DOScale(_referanceStar.transform.localScale, _starAnimationTime).SetDelay(delay);
        }
        private void OnEnable()
        {
            LevelEventManager.QuestionAnswered += ShowEndPanel;
        }
        private void OnDisable()
        {

            LevelEventManager.QuestionAnswered -= ShowEndPanel;
        }
        void ShowEndPanel(bool isCorrect)
        {
            _endPanel.transform.localScale= Vector3.zero;
            _endPanel.SetActive(true);
            _endPanel.transform.DOScale(Vector3.one, 0.2f).SetDelay(AnswerChecker.Instance._questionPanelCloseTime).OnComplete(() => AnimateAllStars());


        }

        void AnimateAllStars()
        {
            
                for (int i = 0; i < _starCount; i++)
                {
                    AnimateStar(i, i * _starAnimationTime);
                }
            LevelEventManager.OnLevelCompleted(LevelDataHandler.Instance.currentLevelIndex,_starCount);
        }
    }
}