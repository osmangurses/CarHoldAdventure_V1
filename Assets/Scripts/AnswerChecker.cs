using _Game;
using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerChecker : MonoBehaviour
{
    [SerializeField] Button[] _answerButtons;
    [SerializeField] GameObject questionPanel;




    private LevelDataHandler _levelDataHandler;
    private bool _isAnswerCorrect,isAnswerChecked;
    private int answerIndex;
    private void Start()
    {
        _levelDataHandler = GetComponent<LevelDataHandler>();
    }
    public void CheckAnswer(int clickedButtonIndex)
    {

        if (!isAnswerChecked)
        {

            answerIndex = clickedButtonIndex;
            if (answerIndex == _levelDataHandler.levelData.correctAnswerNumber)
            {
                _isAnswerCorrect = true;
            }
            else
            {
                _isAnswerCorrect = false;
            }
            PaintAnswerButton();
            isAnswerChecked = true;
        }
    }
    void PaintAnswerButton()
    {
        _answerButtons[answerIndex].GetComponent<Image>().color = Color.yellow;
        Invoke(nameof(PaintCorrectButton), 2f);

    }
    void PaintCorrectButton()
    {
        if (_isAnswerCorrect)
        {
            _answerButtons[answerIndex].GetComponent<Image>().color = Color.green;
            GetComponent<ParticlePlayer>().PlayParticles("CorrectAnswer");
            LevelEventManager.OnQuestionAnswered(true);
        }
        else
        {

            _answerButtons[answerIndex].GetComponent<Image>().color = Color.red;
            GetComponent<ParticlePlayer>().PlayParticles("IncorrectAnswer");
            LevelEventManager.OnQuestionAnswered(false);
        }
        Invoke(nameof(CloseQuestionPanel),0.5f);
    }
    void CloseQuestionPanel()
    {
        questionPanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.Linear).OnComplete(()=>
        questionPanel.SetActive(false));
    }
}
