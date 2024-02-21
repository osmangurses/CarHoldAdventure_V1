using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollideDetect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Obstacle")
        {
            Time.timeScale = 0;
        }
        Debug.Log(other.tag);
    }
}
