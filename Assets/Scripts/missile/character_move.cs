using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_move : MonoBehaviour
{
    [SerializeField] float speed;
    public float jumpforce;
    public bool onGround = false;
    Rigidbody rb;
    Animator an;
    public int maxhealth = 6;
    static public int health;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
        an = GetComponent<Animator>();
        health = maxhealth;
        //GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.rotation * Vector3.left * Time.deltaTime * speed;
            an.SetTrigger("run");
        }
        //right
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.rotation * Vector3.right * Time.deltaTime * speed;
            an.SetTrigger("run");
        }
        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpforce * Vector3.up);
            an.SetTrigger("jump");
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "floor")
        {
            onGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "floor")
        {
            onGround = false;
        }

    }
}
