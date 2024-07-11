using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombing : MonoBehaviour
{
    public Material mat;
    public GameObject ground;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Material[] materials = GetComponent<MeshRenderer>().materials;
            materials[1] = new Material(Shader.Find("Standard"));
            materials[1].color = new Color(1, 1, 1, 0);
            GetComponent<Renderer>().materials = materials;
        }
    }
    public void ChangeShader()
    {
        ground.GetComponent<MeshRenderer>().material = mat;
    }
}
