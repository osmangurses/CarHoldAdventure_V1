using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataHandler : MonoBehaviour
{
    [SerializeField] 
    Levels levels;
    [HideInInspector] 
    public LevelData levelData;

    public SplineComputer[] levelPaths;
    public int currentLevelIndex = 0;
    private void Awake()
    {
        levelData = levels.allLevels[currentLevelIndex];
        levelPaths=Instantiate(levelData.LvObjects).transform.GetComponentsInChildren<SplineComputer>();
    }
}
