using UnityEngine;

[CreateAssetMenu(fileName = "Car0", menuName = "ScriptableObjects/NewCar", order = 1)]
public class CarType : ScriptableObject
{
    public string carName;
    public float speed;
    public int carIndex,price;
    public float stopDuration,speedUpDuration;
    
}