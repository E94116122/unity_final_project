using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{
    static public bool Ischeck = false;
    // Start is called before the first frame update
    public void checkprofit()
    {
        Ischeck = true;
    }
    private void Start()
    {
        Ischeck = false;
    }
}
