using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CarStatEnum
{
    public static Stats stat;
}
public enum Stats
{
    Waiting,
    Playing,
    Failed,
    Ended
}
