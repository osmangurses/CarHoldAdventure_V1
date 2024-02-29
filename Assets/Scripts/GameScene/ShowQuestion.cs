using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Game
{
    public class ShowQuestion : MonoBehaviour
{
        [SerializeField] GameObject questionPanel;
        [SerializeField] TextMeshProUGUI[] answerTexts;
        [SerializeField] TextMeshProUGUI questionText;
        [SerializeField] Slider questionTimer;

        LevelData levelData;
        bool isAnswered,isQuestionReady;

        private void OnEnable()
        {
            LevelEventManager.LevelEnded += ShowCurrentQuestion;
        }
        private void OnDisable()
        {
            LevelEventManager.LevelEnded -= ShowCurrentQuestion;
        }
        public void ShowCurrentQuestion(LevelData lvData,int lvIndex)
        {

            for (int i = 0; i < lvData.answers.Length; i++)
            {
                if (answerTexts[i]!=null)
                {
                answerTexts[i].text = lvData.answers[i];
                }
            }
            levelData = lvData;
            questionText.text =lvData.question;
            questionPanel.SetActive(true);
            questionPanel.transform.DOScale(Vector3.one, 0.5f).OnComplete(()=>
            isQuestionReady=true);
        

        }
        public void StopTimer()
        {
            isAnswered = true;
        }
        private void Update()
        {
            if (!isAnswered && isQuestionReady)
            {
                questionTimer.value -= Time.deltaTime/levelData.answerTime_Second;
                if (questionTimer.value<=0)
                {
                    AnswerChecker.Instance.TimeOver();
                    isAnswered=true;
                }
            }
        }
    }
    
}
