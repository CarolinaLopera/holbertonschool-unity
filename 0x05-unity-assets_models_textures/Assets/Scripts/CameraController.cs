using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // public GameObject player;
    public Vector3 offset;
    private Transform target;
    public float lerp = 1;
    public float sensibility = 1;

    // Start is called before the first frame update
    void Start() {
        target = GameObject.Find("Player").transform;
    }

    // LateUpdate is called once per frame
    void LateUpdate() {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerp);
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibility, Vector3.up) * offset;

        transform.LookAt(target);

        // Vector3 camera = gameObject.transform.position;
        // Vector3 ball = player.transform.position;
        // camera.x = ball.x;
        // camera.z = ball.z;
        // gameObject.transform.position = camera;
    }
}
