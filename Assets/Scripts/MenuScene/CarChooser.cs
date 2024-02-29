using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarChooser : MonoBehaviour
{
    public static CarChooser Instance;

    [SerializeField] Cars cars;
    [SerializeField] ParticleSystem confetti;
    [SerializeField] TextMeshProUGUI totalCoinText;
    [SerializeField] GameObject carPricePanel,buyCarPanel;
    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] GameObject carPodium;
    int currentCarIndex;

    private void Start()
    {
        Instance = this;
        totalCoinText.text = PlayerPrefs.GetInt("TotalCoin").ToString();
        currentCarIndex = PlayerPrefs.GetInt("SelectedCarIndex");
        SelectCar();
        ChangeCar(0);
    }
 
    public void ChangeCar(int changeIndex)
    {
        Debug.Log("Tried");
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
            SelectCar();
        }
    }

    public void SelectCar()
    {
        if (PlayerPrefs.GetInt("isCar" + currentCarIndex.ToString() + "Open") == 1)
        {
            PlayerPrefs.SetInt("SelectedCarIndex", currentCarIndex);
            carPricePanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce);
        }
        else
        {
            priceText.text = cars.CarTypes[currentCarIndex].price.ToString();
            carPricePanel.transform.DOScale(Vector3.one,0.5f).SetEase(Ease.OutBounce);
        }

    }
    public void OpenCloseBuyCarPanel(bool isOpen)
    {
        if (isOpen)
        {
            buyCarPanel.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce);
        }
        else
        {
            buyCarPanel.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBounce);
        }
        SelectCar();
    }
    public void BuyCar()
    {
               
            if (PlayerPrefs.GetInt("TotalCoin") >= cars.CarTypes[currentCarIndex].price && PlayerPrefs.GetInt("isCar" + currentCarIndex.ToString() + "Open") != 1)
            {
                PlayerPrefs.SetInt("TotalCoin", PlayerPrefs.GetInt("TotalCoin") - cars.CarTypes[currentCarIndex].price);
                PlayerPrefs.SetInt("isCar" + currentCarIndex.ToString() + "Open", 1);
                totalCoinText.text = PlayerPrefs.GetInt("TotalCoin").ToString();
                confetti.Play();
            }
        
    }
    public void GoBack()
    {
        MenuManager.Instance.mainPanel.SetActive(true);
        MenuManager.Instance.selectCarPanel.SetActive(false);
        MenuManager.Instance.carPodium.SetActive(false);
    }
}