using _Game;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollideDetect : MonoBehaviour
{
    [SerializeField] GameObject levelFailedPanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Obstacle")
        {
            LevelEventManager.OnLevelFailed(LevelDataHandler.Instance.currentLevelIndex);
            levelFailedPanel.transform.DOScale(Vector3.one,0.7f).SetEase(Ease.OutBounce).SetDelay(0.7f);
            GetComponent<CarMove>().isCrashed = true;
            ParticlePlayer.Instance.PlayParticles("CrashSmoke");
            ParticlePlayer.Instance.PlayParticles("BreakdownSmoke");
            GetComponent<BoxCollider>().enabled = false;
        }
        else if (other.tag=="Star")
        {
            AudioPlayer.instance.PlayAudio(AudioName.StarCollect);
            other.GetComponent<ParticleSystem>().Play();
            other.gameObject.GetComponent<MeshRenderer>().enabled=false;
            other.gameObject.GetComponent<SphereCollider>().enabled=false;
            Destroy(other.gameObject,1);
            EndPanelManager.Instance.CompletedChallange(1);
        }
        Debug.Log(other.tag);
    }
}
