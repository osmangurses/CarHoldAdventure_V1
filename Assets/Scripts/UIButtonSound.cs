using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonSound : MonoBehaviour
{
    private Button button;

    void Awake()
    {
        // Button bileþenini al
        button = GetComponent<Button>();

        // Button bileþeni mevcutsa, onClick olayýna listener ekle
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Button component not found on this GameObject.");
        }
    }

    void OnButtonClick()
    {
        AudioPlayer.instance.PlayAudio(AudioName.UIClick);
    }
}
