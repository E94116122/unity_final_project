using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour
{
    public GameObject instructScreen;

    void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            instructScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
