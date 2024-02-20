using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Game
{
    public class SaveManager : MonoBehaviour
    {
        string lvStarsSaveKey;
        private void OnEnable()
        {
            LevelEventManager.LevelLoaded += LoadVariables;
            LevelEventManager.LevelCompleted += SaveVariables;
        }
        private void OnDisable()
        {
            LevelEventManager.LevelLoaded -= LoadVariables;
            LevelEventManager.LevelCompleted -= SaveVariables;
        }





        void LoadVariables(LevelData lvData,int lvIndex)
        {
            lvStarsSaveKey = "Lv" + lvIndex.ToString() + "Stars";
            if (PlayerPrefs.HasKey(lvStarsSaveKey))
            {
                PlayerPrefs.SetInt("TotalStar", PlayerPrefs.GetInt("TotalStar") - PlayerPrefs.GetInt(lvStarsSaveKey));
                PlayerPrefs.SetInt(lvStarsSaveKey, 0);
            }

        }



        void SaveVariables(int lvIndex, int lvStars)
        {
            lvStarsSaveKey = "Lv" + lvIndex.ToString() + "Stars";
            PlayerPrefs.SetInt(lvStarsSaveKey, lvStars);
            PlayerPrefs.SetInt("TotalStar", PlayerPrefs.GetInt("TotalStar") + lvStars);
        }
    }
}
