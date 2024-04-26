using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 3f;
    public TextMeshProUGUI TimerText;
    public GameObject timerCanvas;

    public GameObject GameCanvas;
    public GameObject playerRed;
    public GameObject playerBlue;
    public PlayerRedMovement PlayerRedMovement;

    public void Start()
    {
        currentTime = startingTime;
    }

    public void Update()
    {
        currentTime -= Time.deltaTime;
        TimerText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            timerCanvas.SetActive(false);
            GameCanvas.SetActive(true);
            playerBlue.SetActive(true);
            playerRed.SetActive(true);
            PlayerRedMovement.ResetPosition();
        }
        else
        {
            timerCanvas.SetActive(true);
            GameCanvas.SetActive(false);
            playerBlue.SetActive(false);
            playerRed.SetActive(false);
        }
    }
}

