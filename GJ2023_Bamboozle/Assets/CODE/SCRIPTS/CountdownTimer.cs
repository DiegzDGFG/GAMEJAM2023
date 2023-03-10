using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{

    public float timeRemaining;
    bool timerIsRunning;
    public float maxTime;
    [SerializeField]
    private Image uprootingBar;


    // Update is called once per frame

    private void Start()
    {
        timerIsRunning=true;
    }
    void Update()
    {
        if (timerIsRunning)
            timeRemaining -= Time.deltaTime;
        
        if(timeRemaining<0)
        {
            timeRemaining = 0;
            timerIsRunning = false;
            SceneManager.LoadScene("LoseScreen");
        }

        if (timeRemaining >= maxTime)
            SceneManager.LoadScene("WinScreen");

        UprootBarFill();
    }

    void UprootBarFill()
    {
        uprootingBar.fillAmount = timeRemaining / maxTime;
    }
}
