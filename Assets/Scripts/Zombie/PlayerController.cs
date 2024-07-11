using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Ball ball; // Reference to the ball controller.

    private Vector3 move;
    // the world-relative desired move direction, calculated from the camForward and user input.

    private Transform cam; // A reference to the main camera in the scenes transform
    private Vector3 camForward; // The current forward direction of the camera
    private bool jump; // whether the jump button is currently pressed
    float movingSpeed = 5.0f;
    float jumpForce = 10f;
    bool onGround;
    Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {

        ball = GetComponent<Ball>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += movingSpeed * Time.deltaTime * Camera.main.transform.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position -= movingSpeed * Time.deltaTime * Camera.main.transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= movingSpeed * Time.deltaTime * Camera.main.transform.right;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += movingSpeed * Time.deltaTime * Camera.main.transform.right;
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            onGround = true;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            Debug.Log("on ground = " + collision.transform.name);
        }

    }
    void OnCollisionStay(Collision collision)
    {

    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            onGround = false;
            Debug.Log("not on  ground = " + collision.transform.name);
        }
    }
}
