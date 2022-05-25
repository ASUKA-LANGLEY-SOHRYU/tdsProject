using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text textScore;
    public int score = 0;
    public int maxScore = 10;
    public GameObject WinGameScreen;
    public Transform pl;

    private void Update()
    {
        textScore.text = $"Infected files destroyed: {score} / {maxScore}";
        if (score == maxScore)
        {
            Instantiate(WinGameScreen, pl.position, Quaternion.identity);
            pl.GetComponent<PlayerMovement>().speed = 0;
        }
    }
}
