using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update() {
        Vector3 camera = gameObject.transform.position;
        Vector3 ball = player.transform.position;
        camera.x = ball.x;
        camera.z = ball.z;
        gameObject.transform.position = camera;
    }
}
// 26.99147