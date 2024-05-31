using _Game;
using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CarAudioManagement : MonoBehaviour
{
    public float volume;
    CarMove carMove;
    AudioSource audioSource;
    private void Awake()
    {
        carMove=transform.parent.parent.GetComponent<CarMove>();
        audioSource = GetComponent<AudioSource>();
        
    }
    private void Start()
    {
        audioSource.volume = volume*PlayerPrefs.GetInt("IsSoundOn");
    }
    private void OnEnable()
    {
        LevelEventManager.LevelEnded += OnLevelEnded_;
        LevelEventManager.LevelFailed += OnLevelFailed_;
    }
    private void OnDisable()
    {
        LevelEventManager.LevelEnded -= OnLevelEnded_;
        LevelEventManager.LevelFailed -= OnLevelFailed_;
    }
    void OnLevelEnded_(LevelData data,int index)
    {
        audioSource.Stop();
    }
    void OnLevelFailed_(int index)
    {
        audioSource.Stop();
    }
    private void Update()
    {
        audioSource.pitch = 0.6f + (carMove.carSplineFollower.followSpeed / carMove.selectedCar.speed) * 8 / 10;
    }
}
