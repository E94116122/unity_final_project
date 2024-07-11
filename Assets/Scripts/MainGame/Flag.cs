using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    GameObject BrickSpwaner;
    // Start is called before the first frame update
    void Start()
    {
        BrickSpwaner = GameObject.Find("BrickSpwaner");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -.5f)
        {
            gameObject.SetActive(false);
            BrickSpwaner.SendMessage("FlagDelete");
        }
    }

        private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "hell")
        {
            gameObject.layer = 7;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "hell")
        {
            gameObject.layer = 6;
        }
    }
}
