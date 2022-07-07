using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float seconds;
    private float mlSeconds;
    private int minute;
    private int hour;

    // Start is called before the first frame update
    void Start() {}

    void Update() {
        UpdateTimerUI();
    }

    public void UpdateTimerUI() {
        seconds += Time.deltaTime;
        mlSeconds += Time.deltaTime * 1000;
        TimerText.text = minute + ":" + (int)seconds + "." + (int)mlSeconds;
        
        // if (mlSeconds >= 1000) {
        //     seconds++;
        //     mlSeconds = 0;
        // } else 
        if (seconds >= 60) {
            minute++;
            seconds = 0;
        } /* else if(minute >= 60){
            hour++;
            minute = 0;
        }*/ 
    }
}
