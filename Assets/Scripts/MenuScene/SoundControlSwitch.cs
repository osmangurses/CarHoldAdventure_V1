using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundControlSwitch : MonoBehaviour
{

    public void Mute()
    {
        AudioPlayer.instance.SetVolume(false);
    }
    public void Unmute()
    {
        AudioPlayer.instance.SetVolume(true);
    }
}
