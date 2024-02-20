using DG.Tweening;
using UnityEngine;

namespace _Game
{
    public class GiveGift : MonoBehaviour
    {
        public GameObject giftParent,giftBoxHeader,giftBoxBody;
        public static GiveGift Instance;
        public GameObject[] gifts;



        private GameObject givenGift1, givenGift2;

        public void Start()
        {
            Instance = this;
        }

        private void OnEnable()
        {
            LevelEventManager.QuestionAnswered += OpenGift;
        }
        private void OnDisable()
        {
            LevelEventManager.QuestionAnswered -= OpenGift;
        }
        public void OpenGift(bool isAnswerTrue)
        {
            if (isAnswerTrue)
            {
                giftParent.SetActive(true);
                giftParent.transform.localScale = Vector3.zero;
                givenGift1 = gifts[0];
                givenGift2 = givenGift1;
                while (givenGift2 == givenGift1)
                {
                    givenGift2 = gifts[(int)Random.Range(0, gifts.Length)];
                }
                givenGift1.SetActive(true);
                givenGift2.SetActive(true);
                giftParent.transform.DOScale(Vector3.one * 2.81f, 1f).SetEase(Ease.OutBounce).OnComplete(() =>
                giftParent.transform.DOScaleY(1, 0.7f).OnComplete(() =>
                giftParent.transform.DOScaleY(2.81f,0.2f).SetEase(Ease.OutBounce).OnComplete(()=>
                giftBoxHeader.transform.DOLocalMoveY(500,0.5f).OnComplete(()=>
                givenGift1.transform.DOLocalMove(new Vector3(100, 150, 0), 1).OnComplete(()=>
                givenGift2.transform.DOLocalMove(new Vector3(-100, 150, 0), 1)
                )
                )
                )
                )
                ) ;
                
            }
        }
    }
}