using UnityEngine;

public class CarSwipeController : MonoBehaviour
{
    [SerializeField] private GameObject[] cars; // Arabalarýnýzý buraya sürükleyip býrakýn

    private Vector3 startTouchPosition, currentTouchPosition;


    public void PointerDown()
    {
        startTouchPosition = Input.mousePosition;
    }
    public void PointerUp()
    {
        currentTouchPosition = Input.mousePosition;
        if (startTouchPosition.x+10<currentTouchPosition.x)
        {
            CarChooser.Instance.ChangeCar(-1);
        }
        else if(startTouchPosition.x - 10 > currentTouchPosition.x)
        {
            CarChooser.Instance.ChangeCar(1);
        }
    }
    
    private void Update()
    {
     
    }

}
