using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelChooser : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelNameText,levelNeedStarText;
    [SerializeField] Image[] stars;
    [SerializeField] GameObject unlockedLevelPanel, lockedLevelPanel;

    Levels levels;
    private void Start()
    {
        levels=MenuManager.Instance.levels;
        CheckLevel();

    }
    public void CheckLevel()
    {
        int currentLevelIndex = PlayerPrefs.GetInt("SelectedLevelIndex");
        if (levels.allLevels[currentLevelIndex].needStar > PlayerPrefs.GetInt("TotalStar"))
        {
            unlockedLevelPanel.SetActive(false);
            lockedLevelPanel.SetActive(true);
            levelNeedStarText.text = levels.allLevels[currentLevelIndex].needStar.ToString();
        }
        else
        {
            lockedLevelPanel.SetActive(false);
            unlockedLevelPanel.SetActive(true);
            levelNameText.text = "LEVEL" + (currentLevelIndex+1).ToString();
            PlayerPrefs.SetInt("SelectedLevelIndex",currentLevelIndex);
            Debug.Log(currentLevelIndex);
            for (int i = 0; i < stars.Length; i++)
            {
                    if (PlayerPrefs.GetInt("Lv" + currentLevelIndex + "Stars") > i)
                    {
                        stars[i].color = Color.white;
                    }
                    else
                    {
                        stars[i].color = Color.black;
                    }
            }
        }
    }
    public void ChangeLevelButton(int addValueToLevelIndex)
    {
        PlayerPrefs.SetInt("SelectedLevelIndex", PlayerPrefs.GetInt("SelectedLevelIndex") + addValueToLevelIndex);
        int currentLevelIndex = PlayerPrefs.GetInt("SelectedLevelIndex");
        if (currentLevelIndex < 0){currentLevelIndex = levels.allLevels.Length - 1;}
        else if (currentLevelIndex>levels.allLevels.Length-1){currentLevelIndex = 0;}
        PlayerPrefs.SetInt("SelectedLevelIndex", currentLevelIndex);
        if (levels.allLevels[currentLevelIndex].needStar>PlayerPrefs.GetInt("TotalStar"))
        {
            unlockedLevelPanel.SetActive(false);
            lockedLevelPanel.SetActive(true);
            levelNeedStarText.text= levels.allLevels[currentLevelIndex].needStar.ToString();
        }
        else
        {
            lockedLevelPanel.SetActive(false);
            unlockedLevelPanel.SetActive(true);
            levelNameText.text="LEVEL"+(currentLevelIndex+1).ToString();
            PlayerPrefs.SetInt("SelectedLevelIndex", currentLevelIndex);

            Debug.Log(currentLevelIndex);
            for (int i = 0; i < stars.Length; i++)
            {
                if (PlayerPrefs.GetInt("Lv"+currentLevelIndex+"Stars")>i)
                {
                    stars[i].color = Color.white;
                }
                else
                {
                    stars[i].color= Color.black;
                }

            }
        }

    }
    
}
