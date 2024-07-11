using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show : MonoBehaviour
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
