using UnityEngine;

[CreateAssetMenu(fileName = "Car0", menuName = "ScriptableObjects/NewCar", order = 1)]
public class CarType : ScriptableObject
{
    public float speed;
    public int carIndex;
    public float stopDuration,speedUpDuration;
    
}