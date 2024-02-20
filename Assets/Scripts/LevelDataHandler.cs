using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace _Game
{
    public class LevelDataHandler : MonoBehaviour
    {
        public static LevelDataHandler Instance;
        [SerializeField]
        Levels levels;
        [HideInInspector]
        public LevelData levelData;
        [HideInInspector]
        public SplineComputer[] levelPaths;
        [HideInInspector]
        public int currentLevelIndex = 0;
        private void Awake()
        {
            levelData = levels.allLevels[currentLevelIndex];
            levelPaths = Instantiate(levelData.LvObjects).transform.GetComponentsInChildren<SplineComputer>();
        }
        private void Start()
        {
            Instance = this;
            LevelEventManager.OnLevelLoaded(levelData,currentLevelIndex);
        }
    }
}
