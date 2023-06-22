using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player: MonoBehaviour
{
    public bool isGrounded = true;
    public float speed;
    public int jumpforce;
    public int rotationSpeed;
    public Transform TransformCam;
    public float speedmultiplier;
    public bool isSpinting = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpforce, 0));
            isGrounded = false;
        }

        if (!isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, -10, 0));
        }

        Vector3 dir = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.D))
            dir.x = 1;
        if (Input.GetKey(KeyCode.Q))
            dir.x = -1;
        if (Input.GetKey(KeyCode.Z))
            dir.z = 1;
        if (Input.GetKey(KeyCode.S))
            dir.z = -1;

        dir = dir.x * transform.right + dir.z * transform.forward;
        GetComponent<Rigidbody>().velocity = new Vector3(dir.x * speed, GetComponent<Rigidbody>().velocity.y, dir.z * speed);

        float currentSpeed = GetComponent<Rigidbody>().velocity.magnitude;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
