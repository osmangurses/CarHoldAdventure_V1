using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cars", menuName = "ScriptableObjects/Cars", order = 1)]
public class Cars : ScriptableObject
{
    public CarType[] CarTypes;
}

