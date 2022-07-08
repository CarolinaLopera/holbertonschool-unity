using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float mlSeconds;
    private float seconds;
    private int minutes;

    // Start is called before the first frame update
    void Start() {}

    void Update() {
        TimerUI();
    }

    public void TimerUI() {
        mlSeconds += Time.deltaTime * 1000;
        // TimerText.text = minutes + ":" + seconds.ToString("00") + "." + mlSeconds.ToString("00");
        TimerText.text = String.Format("{0:0}:{1:00}.{2:00}", minutes, seconds, mlSeconds);

        if (mlSeconds >= 1000) {
            seconds++;
            mlSeconds = 0;
        }
        if (seconds >= 60) {
            minutes++;
            seconds = 0;
        }
    }
}
