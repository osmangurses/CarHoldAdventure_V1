using System;

namespace _Game
{
    public static class LevelEventManager
    {
        public static event Action<LevelData, int> LevelLoaded;
        public static event Action<LevelData, int> LevelStarted;
        public static event Action<int> LevelFailed;
        public static event Action<LevelData, int> LevelEnded;
        public static event Action<bool> QuestionAnswered;
        public static event Action<int, int> LevelCompleted;



        public static void OnLevelLoaded(LevelData levelData, int levelIndex)
        {
            LevelLoaded?.Invoke(levelData, levelIndex);
            CarStatEnum.stat = Stats.Waiting;
        }
        public static void OnLevelStarted(LevelData levelData, int levelIndex)
        {
            LevelStarted?.Invoke(levelData, levelIndex);
            CarStatEnum.stat = Stats.Playing;
        }

        public static void OnLevelEnded(LevelData levelData, int levelIndex)
        {
            LevelEnded?.Invoke(levelData, levelIndex);
            CarStatEnum.stat = Stats.Ended;
            AudioPlayer.instance.PlayAudio(AudioName.QuestionTime);
        }

        public static void OnLevelFailed(int levelIndex)
        {
            LevelFailed?.Invoke(levelIndex);
            CarStatEnum.stat = Stats.Failed;
            AudioPlayer.instance.PlayAudio(AudioName.Crash);
        }

        public static void OnQuestionAnswered(bool isTrue)
        {
            if (isTrue)
            {
                AudioPlayer.instance.PlayAudio(AudioName.CorrectAnswer);
            }
            else
            {
                AudioPlayer.instance.PlayAudio(AudioName.IncorrectAnswer);
            }
            QuestionAnswered?.Invoke(isTrue);
        }

        public static void OnLevelCompleted(int lvIndex, int lvStars)
        {
            LevelCompleted?.Invoke(lvIndex, lvStars);
        }
    }
}
