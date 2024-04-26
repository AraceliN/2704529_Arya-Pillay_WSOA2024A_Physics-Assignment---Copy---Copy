using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject ReStartCanvas;
    public GameObject GameCanvas;
    public GameObject TimerCanvas;
    public GameObject PortalCanvas;

    [Header("ReStartCanvas")]
    public GameObject WinText;
    public GameObject LoseText;

    [Header("Miscellaneous")]
    public ScoreScript scoreScript;
    public PuckScript puckScript;
    public PlayerRedMovement playerRedMovement;
    public PlayerBlue playerBlue;
    public TimerScript timerScript;

    public void ShowReStartCanvas(bool DidBlueWin)
    {
        Time.timeScale = 0;

        GameCanvas.SetActive(false);
        ReStartCanvas.SetActive(true);

        if (DidBlueWin)
        {
            WinText.SetActive(false);
            LoseText.SetActive(true);
        }
        else
        {
            WinText.SetActive(true);
            LoseText.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        GameCanvas.SetActive(true);
        TimerCanvas.SetActive(true);
        ReStartCanvas.SetActive(false);

        timerScript.Start();
        timerScript.Update();
        scoreScript.ResetScore();
        puckScript.CentrePuck();
        playerRedMovement.ResetPosition();
        playerBlue.ResetPosition();
    }
}
