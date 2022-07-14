using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Rigidbody rb;
   public float speed = 500f;
   private int score = 0;
   public int health = 5;
   public Text scoreText;
   public Text healthText;
   public GameObject winLose;
   public Image winLoseI;
   public Text winLoseT;

   // Update is called once per frame
   void Update() {
      if (Input.GetKey(KeyCode.Escape)) {
         SceneManager.LoadScene("menu");
      }

      if (health == 0) {
         // Debug.Log("Game Over!");
         winLose.SetActive(true);
         winLoseI.color = new Color(255, 0, 0);
         winLoseT.color = new Color(255, 255, 255);
         winLoseT.text = "Game Over!";
         score = 0;
         health = 5;

         StartCoroutine(LoadScene(3));
      }
   }

   void FixedUpdate()
   {
      if (Input.GetKey("w")) {
         rb.AddForce(0, 0, speed * Time.deltaTime);
      }
      if (Input.GetKey("a")) {
         rb.AddForce(-speed * Time.deltaTime, 0, 0);
      }
      if (Input.GetKey("s")) {
         rb.AddForce(0, 0, -speed * Time.deltaTime);
      }
      if (Input.GetKey("d")) {
         rb.AddForce(speed * Time.deltaTime, 0, 0);
      }
   }

   void OnTriggerEnter(Collider other) {
      if (other.gameObject.tag == "Pickup") {
         score += 1;
         SetScoreText();
         // Debug.Log($"Score: {score}");
         Destroy(other.gameObject);
      }
      if (other.gameObject.tag == "Trap") {
         health -= 1;
         SetHealthText();
         // Debug.Log($"Health: {health}");
      }
      if (other.gameObject.tag == "Goal") {
         winLose.SetActive(true);
         winLoseI.color = new Color(0, 255, 0);
         winLoseT.color = new Color(0, 0, 0);
         winLoseT.text = "You win!";

         StartCoroutine(LoadScene(3));
         // winLoseI = GameObject.Find("WinLoseBG").GetComponent<Image>();
         // Debug.Log("You win!");
      }
   }

   void SetScoreText() {
      scoreText.text = $"Score: {score}";
   }

   void SetHealthText() {
      healthText.text = $"Health: {health}";
   }

   IEnumerator LoadScene(float seconds) {
      yield return new WaitForSeconds(seconds);
      Scene scene = SceneManager.GetActiveScene();
      SceneManager.LoadScene(scene.name);
   }
}
