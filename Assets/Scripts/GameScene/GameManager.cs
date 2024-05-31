using _Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Start()
    {
        instance = this;
    }

    public void StartGame()
    {
        if (CarStatEnum.stat==Stats.Waiting)
        {
            LevelEventManager.OnLevelStarted(LevelDataHandler.Instance.levelData, LevelDataHandler.Instance.currentLevelIndex);
        }
    }
}
