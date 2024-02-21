using _Game;
using EasyTransition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] TransitionSettings transition;
    public Cars cars;
    public Levels levels;
    public GameObject mainPanel, selectCarPanel, carPodium;
    private void Awake()
    {
        PlayerPrefsCreator();
    }
    private void Start()
    {
        Instance=this;
    }
    void PlayerPrefsCreator()
    {
        if (!PlayerPrefs.HasKey("SelectedLevelIndex"))
        {
            PlayerPrefs.SetInt("SelectedLevelIndex", 0);
        }
        if (!PlayerPrefs.HasKey("SelectedCarIndex"))
        {
            PlayerPrefs.SetInt("SelectedCarIndex", 0);
        }
        if (!PlayerPrefs.HasKey("TotalStar"))
        {
            PlayerPrefs.SetInt("Total", 0);
        }
        if (!PlayerPrefs.HasKey("TotalCoin"))
        {
            PlayerPrefs.SetInt("TotalCoin", 0);
        }
        if (!PlayerPrefs.HasKey("Lv0Stars"))
        {
            for (int i = 0; i < levels.allLevels.Length; i++)
            {
                PlayerPrefs.SetInt("Lv" + i.ToString() + "Stars", 0);
            }
        }
        if (!PlayerPrefs.HasKey("isCar0Open"))
        {
            for (int i = 0; i < cars.CarTypes.Length; i++)
            {
                PlayerPrefs.SetInt("isCar" + i.ToString() + "Open", 0);
            }

            PlayerPrefs.SetInt("isCar0Open", 1);
        }
    }
    public void LoadGame()
    {
        TransitionManager.Instance().Transition("GameScene",transition,0.5f);
    }
    public void GoToCarSelect()
    {

        mainPanel.SetActive(false);
        selectCarPanel.SetActive(true);
        carPodium.SetActive(true);
    }
}
