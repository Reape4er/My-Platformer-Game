using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class KillScore : MonoBehaviour
{
    public TMP_Text Score;
    public int EnemiesCount;
    private int score = 0;
    private void Start()
    {
        EnemiesCount = GameObject.FindGameObjectsWithTag("Enemies").Length;
        score = EnemiesCount;
        Score.text = score.ToString();
    }
    public void addScore()
    {
        score--;
        Score.text = score.ToString();
    }
    public bool MissionObjectiveCheck()
    {
        return score == 0;
    }
}
