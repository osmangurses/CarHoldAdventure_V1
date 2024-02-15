using DG.Tweening;
using UnityEngine;

namespace _Game
{
    public class GiveGift : MonoBehaviour
    {
        public GameObject giftParent;
        private static GiveGift _instance;

        public static GiveGift Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Find existing instance in the scene
                    _instance = FindObjectOfType<GiveGift>();

                    // If no instance exists, create a new one
                    if (_instance == null)
                    {
                        GameObject singletonObject = new GameObject(typeof(GiveGift).Name);
                        _instance = singletonObject.AddComponent<GiveGift>();
                    }
                }

                return _instance;
            }
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
                giftParent.GetComponent<Animator>().enabled = false;
                giftParent.SetActive(true);
                giftParent.transform.localScale = Vector3.zero;
                giftParent.transform.DOScale(Vector3.one*2.81f, 1f).SetEase(Ease.OutBounce).OnComplete(() =>
                giftParent.GetComponent<Animator>().enabled = true);
            }
        }
    }
}