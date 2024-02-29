using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarChooser : MonoBehaviour
{
    [SerializeField] Cars cars;
    [SerializeField] Button selectButton;
    [SerializeField] ParticleSystem confetti;
    [SerializeField] TextMeshProUGUI buttonText, totalCoinText, carName;

    int currentCarIndex;

    private void Start()
    {
        totalCoinText.text = PlayerPrefs.GetInt("TotalCoin").ToString();
        currentCarIndex = PlayerPrefs.GetInt("SelectedCarIndex");
        ChangeCar(0);
    }

    public void ChangeCar(int changeIndex)
    {
        GameObject carPodium = MenuManager.Instance.carPodium;
        if ((currentCarIndex + changeIndex) < carPodium.transform.childCount && (currentCarIndex + changeIndex) > -1)
        {
            currentCarIndex += changeIndex;

            for (int i = 0; i < carPodium.transform.childCount; i++)
            {
                carPodium.transform.GetChild(i).transform.DOComplete();
                if (i == currentCarIndex)
                {
                    carPodium.transform.GetChild(i).transform.DOLocalMove(Vector3.zero, 0.5f);
                }
                else if (i == currentCarIndex + 1)
                {
                    carPodium.transform.GetChild(i).transform.DOLocalMove((Vector3.right * -8) + (Vector3.forward * 4), 0.5f);
                }
                else if (i == currentCarIndex - 1)
                {
                    carPodium.transform.GetChild(i).transform.DOLocalMove((Vector3.right * -8) + (Vector3.forward * -4), 0.5f);
                }
                else
                {
                    carPodium.transform.GetChild(i).transform.DOLocalMove(Vector3.one * -500, 0.5f);
                }
            }
        }
        carName.text = cars.CarTypes[currentCarIndex].carName;
        SelectButtonModifier();
    }
    void SelectButtonModifier()
    {
        if (currentCarIndex == PlayerPrefs.GetInt("SelectedCarIndex"))
        {
            selectButton.image.color = Color.green;
            buttonText.text = "SELECTED";
        }
        else if (PlayerPrefs.GetInt("isCar" + currentCarIndex.ToString() + "Open") == 1)
        {
            selectButton.image.color = Color.white;
            buttonText.text = "SELECT";
        }
        else
        {
            selectButton.image.color = Color.red;
            buttonText.text = cars.CarTypes[currentCarIndex].price.ToString();
        }
    }
    public void SelectOrBuy()
    {
        if (PlayerPrefs.GetInt("isCar" + currentCarIndex.ToString() + "Open") == 1)
        {
            PlayerPrefs.SetInt("SelectedCarIndex", currentCarIndex);
        }
        else
        {
            if (PlayerPrefs.GetInt("TotalCoin") >= cars.CarTypes[currentCarIndex].price)
            {
                PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin") - cars.CarTypes[currentCarIndex].price);
                PlayerPrefs.SetInt("isCar" + currentCarIndex.ToString() + "Open", 1);
                totalCoinText.text = PlayerPrefs.GetInt("TotalCoin").ToString();
                confetti.Play();

            }
        }
        SelectButtonModifier();
    }
    public void GoBack()
    {
        MenuManager.Instance.mainPanel.SetActive(true);
        MenuManager.Instance.selectCarPanel.SetActive(false);
        MenuManager.Instance.carPodium.SetActive(false);
    }
}