using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public KillScore killScore;
    public GameObject window;

    public void ShowWindow()
    {
        if (killScore.MissionObjectiveCheck())
        {
            window.SetActive(true);
        }

    }
    public void GoToMenu ()
    {
        SceneManager.LoadScene(0);
        Debug.Log("gotomenu");
    }
}
