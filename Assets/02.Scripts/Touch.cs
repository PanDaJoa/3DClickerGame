using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Touch : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public float CurrentScore;
    public float HitPower;
    public float ScoreIncreasesPerSecond;
    public float PerSecondPlus;
   
    public void Start()
    {

    }
    public void Update()
    {
        ScoreText.text = "Score: $ " + (int)CurrentScore;
        ScoreIncreasesPerSecond = PerSecondPlus * Time.deltaTime;
        CurrentScore = CurrentScore + ScoreIncreasesPerSecond;
    }


}
