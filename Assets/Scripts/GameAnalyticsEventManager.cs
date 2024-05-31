using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK; // GameAnalytics SDK'sini ekleyin

public class GameAnalyticsEventManager : MonoBehaviour
{
    private static GameAnalyticsEventManager _instance;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        _Game.LevelEventManager.LevelLoaded += OnLevelLoaded;
        _Game.LevelEventManager.LevelStarted += OnLevelStarted;
        _Game.LevelEventManager.LevelEnded += OnLevelEnded;
        _Game.LevelEventManager.LevelFailed += OnLevelFailed;
        _Game.LevelEventManager.QuestionAnswered += OnQuestionAnswered;
        _Game.LevelEventManager.LevelCompleted += OnLevelCompleted;
    }

    void OnDisable()
    {
        _Game.LevelEventManager.LevelLoaded -= OnLevelLoaded;
        _Game.LevelEventManager.LevelStarted -= OnLevelStarted;
        _Game.LevelEventManager.LevelEnded -= OnLevelEnded;
        _Game.LevelEventManager.LevelFailed -= OnLevelFailed;
        _Game.LevelEventManager.QuestionAnswered -= OnQuestionAnswered;
        _Game.LevelEventManager.LevelCompleted -= OnLevelCompleted;
    }

    private void OnLevelLoaded(LevelData levelData, int levelIndex)
    {
        GameAnalytics.NewDesignEvent($"level:{levelIndex}:loaded");
    }

    private void OnLevelStarted(LevelData levelData, int levelIndex)
    {
        GameAnalytics.NewDesignEvent($"level:{levelIndex}:started");
    }

    private void OnLevelEnded(LevelData levelData, int levelIndex)
    {
        GameAnalytics.NewDesignEvent($"level:{levelIndex}:ended");
    }

    private void OnLevelFailed(int levelIndex)
    {
        GameAnalytics.NewDesignEvent($"level:{levelIndex}:failed");
    }

    private void OnQuestionAnswered(bool isTrue)
    {
        GameAnalytics.NewDesignEvent($"question:answered", isTrue ? 1 : 0);
    }

    private void OnLevelCompleted(int levelIndex, int stars)
    {
        GameAnalytics.NewDesignEvent($"level:{levelIndex}:completed", stars);
    }
}
