using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VR;
using UnityEngine;

namespace _Game
{
    public static class LevelEventManager
    {
        public static event Action<LevelData, int> LevelLoaded;
        public static event Action<LevelData, int> LevelStarted;
        public static event Action<int> LevelFailed;
        public static event Action<LevelData, int> LevelEnded;
        public static event Action<bool> QuestionAnswered;
        public static event Action<int,int> LevelCompleted;
        public static void OnLevelStarted(LevelData levelData, int levelIndex)
        {
            LevelStarted?.Invoke(levelData, levelIndex);
        }

        public static void OnLevelEnded(LevelData levelData, int levelIndex)
        {
            LevelEnded?.Invoke(levelData, levelIndex);
        }

        public static void OnLevelLoaded(LevelData levelData, int levelIndex)
        {
            LevelLoaded?.Invoke(levelData, levelIndex);
        }
        public static void OnLevelFailed(int levelIndex)
        {
            LevelFailed?.Invoke(levelIndex);
        }
        public static void OnQuestionAnswered(bool isTrue)
        {
            QuestionAnswered?.Invoke(isTrue);
        }
        public static void OnLevelCompleted(int lvIndex,int lvStars)
        {
            LevelCompleted?.Invoke(lvIndex,lvStars);
        }
    }
}
