using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePos2 : MonoBehaviour
{
    public Transform checkPoint;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<CharacterControls>().checkPoint = new Vector3(-1.5f, checkPoint.position.y, -3.0f);
        }
    }
}
