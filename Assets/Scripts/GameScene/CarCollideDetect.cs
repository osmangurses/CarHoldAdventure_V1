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
            levelFailedPanel.transform.DOScale(Vector3.one,0.7f).SetEase(Ease.OutBounce);
            GetComponent<CarMove>().isCrashed = true;
        }
        else if (other.tag=="Star")
        {
            other.GetComponent<ParticleSystem>().Play();
            other.gameObject.GetComponent<MeshRenderer>().enabled=false;
            other.gameObject.GetComponent<SphereCollider>().enabled=false;
            Destroy(other.gameObject,1);
            EndPanelManager.Instance.CompletedChallange(1);
        }
        Debug.Log(other.tag);
    }
}
