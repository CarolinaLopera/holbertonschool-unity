using System.Collections;
using System.Collections.Generic;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController player;
    public float speed = 25f;
    public float horizontal;
    public float vertical;
    public float jump = 10f;
    public float gravity = 30f; // 9.8f;
    public float fallVelocity;
    private Vector3 movePlayer;
    private Vector3 playerInput;
    private Vector3 camForward;
    private Vector3 camRight;
    public Camera mainCamera;
    public Transform emptyObject;
    public GameObject playerEjes;

    // Start is called before the first frame update
    void Start() {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontal, 0, vertical);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        CamDirecction();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        // movePlayer.x = horizontal;
        // movePlayer.z = vertical;
        movePlayer = movePlayer * speed;
        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();
        PlayerJump();
        player.Move(movePlayer * Time.deltaTime);

        if (movePlayer.y < -60) {
            // playerEjes.transform.position = emptyObject.transform.position;
            // movePlayer.y = 20;
            // LoadScene();
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    void SetGravity() {
        // player.Move(new Vector3(0, -gravity, 0));
        if (player.isGrounded) {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        } else {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
    }

    public void PlayerJump() {
        /* player.isGrounded && */
        if ((transform.position.y <= 1.58 && transform.position.y > 0)
                && Input.GetButtonDown("Jump")) {
            fallVelocity = jump;
            movePlayer.y = fallVelocity;
        }
    }

    void CamDirecction() {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}
