using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace _Game
{
    public class LevelDataHandler : MonoBehaviour
    {
        public static LevelDataHandler Instance;

        public Levels levels;
        [HideInInspector]
        public LevelData levelData;
        [HideInInspector]
        public SplineComputer[] levelPaths;
        [HideInInspector]
        public int currentLevelIndex ;
        private void Awake()
        {
            currentLevelIndex = PlayerPrefs.GetInt("SelectedLevelIndex");
            levelData = levels.allLevels[currentLevelIndex];
            Instantiate(levelData.LvObjects);
            levelPaths = levelData.LvObjects.transform.GetComponentsInChildren<SplineComputer>();
        }
        private void Start()
        {
            Instance = this;
            LevelEventManager.OnLevelLoaded(levelData,currentLevelIndex);
        }
    }
}
