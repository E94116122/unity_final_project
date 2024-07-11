using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    float MovingSpeed = 15f;
    private float face;
    GameObject MainControl;
    GameObject BrickSpwaner;
    private bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        MainControl = GameObject.Find("MainGame");
        BrickSpwaner = GameObject.Find("BrickSpwaner");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Boundary_x(float x)
    {
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public void Boundary_z(float z)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }

    void Move()
    {
        if(canMove)
        {
            if (Input.GetKey(KeyCode.W) && Time.timeScale == 1)
            {
                transform.localRotation = Quaternion.Euler(0, face * 180 / Mathf.PI, 0);
                transform.localPosition += MovingSpeed * Time.deltaTime * new Vector3(Mathf.Sin(face), 0, Mathf.Cos(face));
            }
            else if (Input.GetKey(KeyCode.A) && Time.timeScale == 1)
            {
                transform.localRotation = Quaternion.Euler(0, face * 180 / Mathf.PI - 90, 0);
                transform.localPosition += MovingSpeed * Time.deltaTime * new Vector3(-1 * Mathf.Cos(face), 0, Mathf.Sin(face));
            }
            else if (Input.GetKey(KeyCode.S) && Time.timeScale == 1)
            {
                transform.localRotation = Quaternion.Euler(0, face * 180 / Mathf.PI + 180, 0);
                transform.localPosition += MovingSpeed * Time.deltaTime * new Vector3(-1 * Mathf.Sin(face), 0, -1 * Mathf.Cos(face));
            }
            else if (Input.GetKey(KeyCode.D) && Time.timeScale == 1)
            {
                transform.localRotation = Quaternion.Euler(0, face * 180 / Mathf.PI + 90, 0);
                transform.localPosition += MovingSpeed * Time.deltaTime * new Vector3(Mathf.Cos(face), 0, -1 * Mathf.Sin(face));
            }
        }
    }

    public void Freeze()
    {
        canMove = false;
    }

    [System.Obsolete]
    public void TransCam(Transform Cam)
    {
        face = Cam.transform.eulerAngles.y * Mathf.PI / 180;
    }

    public void Buff()
    {
        MovingSpeed *= 2;
    }

    public void DeBuff()
    {
        MovingSpeed /= 2;
    }
}
