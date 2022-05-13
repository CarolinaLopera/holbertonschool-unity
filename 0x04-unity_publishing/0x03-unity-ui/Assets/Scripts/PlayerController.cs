using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
   public Rigidbody rb;
   public float speed = 500f;
   private int score = 0;
   public int health = 5;

   // Update is called once per frame
   void Update() {
      if (health == 0) {
         Debug.Log("Game Over!");
         score = 0;
         health = 5;
         Scene scene = SceneManager.GetActiveScene();
         SceneManager.LoadScene(scene.name);
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
         Debug.Log($"Score: {score}");
         Destroy(other.gameObject);
      }
      if (other.gameObject.tag == "Trap") {
         health -= 1;
         Debug.Log($"Health: {health}");
      }
      if (other.gameObject.tag == "Goal")
         Debug.Log("You win!");
   }
}
