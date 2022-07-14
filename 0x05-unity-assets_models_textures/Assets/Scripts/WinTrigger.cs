using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public Text TimerText;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    void OnTriggerEnter(Collider other) {
        TimerText.color = Color.green;
        TimerText.fontSize = 60;
        Time.timeScale = 0;

        // yield return new WaitForSeconds(5.0F);
        // Application.Quit();
    }
}
