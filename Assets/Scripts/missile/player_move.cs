using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class player_move : MonoBehaviour
{
    [SerializeField] float speed;
    public float jumpforce;
    public bool onGround = false;
    Rigidbody rb;
    Animator an;
    public int maxhealth = 6;
    static public int health;
    public float ctime = 0;
    public AudioSource aud;
    static public bool hit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
        an = GetComponent<Animator>();
        health = maxhealth;
        //GameObject.DontDestroyOnLoad(this.gameObject);
        ctime = 0;
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ctime += Time.deltaTime;
        float y = Input.GetAxis("Mouse X") * 2;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + y, 0);
        speed += ctime ;

        //forward
        if (Input.GetKey(KeyCode.W))
        {
            speed = 5;
            transform.position += transform.forward * Time.deltaTime * speed;
            an.SetTrigger("run");
        }
        //back
        if (Input.GetKey(KeyCode.S))
        {
            speed = 5;
            transform.position += transform.rotation * Vector3.back * Time.deltaTime * speed;
            an.SetTrigger("run");
        }
        //left
        if (Input.GetKey(KeyCode.A))
        {
            speed = 5;
            transform.position += transform.rotation * Vector3.left * Time.deltaTime * speed;
            an.SetTrigger("run");
        }
        //right
        if (Input.GetKey(KeyCode.D))
        {
            speed = 5;
            transform.position += transform.rotation * Vector3.right * Time.deltaTime * speed;
            an.SetTrigger("run");
        }
        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpforce * Vector3.up);
            an.SetTrigger("jump");
           
        }
        Adu();


    }
    void Adu()
    {
        if (hit)
        {
            Invoke("playmusic",0.2f);
            hit = false;
        }
    }
    void playmusic()
    {
        aud.Play();
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
