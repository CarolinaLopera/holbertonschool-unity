using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    public void PlayMaze() {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (colorblindMode.isOn == true) {
            trapMat.color = new Color32(255, 112, 0, 1);
            goalMat.color = Color.blue;
        } else {
            trapMat.color = Color.red;
            goalMat.color = Color.green;
        }
        SceneManager.LoadScene("maze");
    }

    public void QuitMaze() {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
