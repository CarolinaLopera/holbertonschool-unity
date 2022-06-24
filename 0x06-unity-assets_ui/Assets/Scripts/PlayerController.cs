using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public Rigidbody rb;
    public float speed = 25f;
    public float horizontal;
    public float vertical;
    public float jump;
    public float gravity = 9.8f;
    public CharacterController player;
    private Vector3 movePlayer;
    private Vector3 playerInput;

    // Start is called before the first frame update
    void Start() {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // playerInput = new Vector3(horizontal, 0, vertical);
        // movePlayer = playerInput.x + playerInput.z;
        // SetGravity();

        // player.Move(new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime);
    }

    void FixedUpdate() {
        player.Move(new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime);
    }

    // void SetGravity() {
        // movePlayer.y = -gravity * Time.deltaTime;
        // player.Move(new Vector3(0, -gravity, 0) * Time.deltaTime);
    // }
}
