using DG.Tweening;
using EasyTransition;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Game
{
    public class EndPanelManager : MonoBehaviour
    {
        public static EndPanelManager Instance;


        [SerializeField] Image[] _stars;
        [SerializeField] Image[] challangeResults;
        [SerializeField] Image _referanceStar;
        [SerializeField] Sprite challangeCompletedIcon;
        [SerializeField] float _starAnimationTime;
        [SerializeField] GameObject _endPanel;
        [SerializeField] TransitionSettings transition;

        int _starCount=0;

        private void Start()
        {
            Instance = this;
        }

        public void CompletedChallange(int challangeIndex)
        {
            challangeResults[challangeIndex].sprite = challangeCompletedIcon;
            challangeResults[challangeIndex].color=Color.green;
            _starCount++;
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
        public void LoadGame(int addIndexToLevel)
        {
            PlayerPrefs.SetInt("SelectedLevelIndex",PlayerPrefs.GetInt("SelectedLevelIndex")+addIndexToLevel);
            TransitionManager.Instance().Transition("GameScene", transition, 0.5f);
        }
        public void GoHome()
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}