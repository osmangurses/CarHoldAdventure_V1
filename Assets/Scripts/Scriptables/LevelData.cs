using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Lv", menuName = "ScriptableObjects/NewLevel", order = 1)]
public class LevelData : ScriptableObject
{
    public string question="Guess The ...";
    public string[] answers = {"Answer0","Answer1","Answer2"};
    public int correctAnswerNumber=0;
    public float answerTime_Second=5;
    public GameObject LvObjects=null;
    public float levelCompleteTimeForStar=60;
    public int needStar;
    
}
