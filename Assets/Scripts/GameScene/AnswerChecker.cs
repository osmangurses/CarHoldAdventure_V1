using _Game;
using DG.Tweening;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerChecker : MonoBehaviour
{
    public static AnswerChecker Instance;

    public float _questionPanelCloseTime=1f;


    [SerializeField] Button[] _answerButtons;
    [SerializeField] GameObject questionPanel;
    [SerializeField] Image coin;

    



    private LevelDataHandler _levelDataHandler;
    private bool _isAnswerCorrect,isAnswerChecked;
    private int answerIndex;
    private void Start()
    {
        Instance = this;
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
            ParticlePlayer.Instance.PlayParticles("CorrectAnswer");
            LevelEventManager.OnQuestionAnswered(true);
            coin.transform.DOScale(Vector3.one, _questionPanelCloseTime / 4).SetEase(Ease.OutBounce).OnComplete(() => coin.transform.DOLocalMoveY(1000, _questionPanelCloseTime / 4).SetEase(Ease.InBounce));
            coin.DOFade(0, _questionPanelCloseTime / 4).SetDelay(_questionPanelCloseTime/4);
            PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin")+1);
        }
        else
        {
            EndPanelManager.Instance.FailedChallange(2);
            _answerButtons[answerIndex].GetComponent<Image>().color = Color.red;
            _answerButtons[_levelDataHandler.levelData.correctAnswerNumber].GetComponent<Image>().color = Color.green;
            ParticlePlayer.Instance.PlayParticles("IncorrectAnswer");
            LevelEventManager.OnQuestionAnswered(false);
        }
        Invoke(nameof(CloseQuestionPanel), _questionPanelCloseTime / 2);
    }
    void CloseQuestionPanel()
    {
        questionPanel.transform.DOScale(Vector3.zero, _questionPanelCloseTime/2).SetEase(Ease.Linear).OnComplete(()=>
        questionPanel.SetActive(false));
    }
}
