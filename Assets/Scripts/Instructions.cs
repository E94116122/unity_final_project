using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public Button okButton;
    public GameObject instructScreen;

    void Start()
    {
        //okButton= GetComponent<Button>(); 
        okButton.onClick.AddListener(okButtonOnClick);
        //instructScreen= GetComponent<GameObject>();
    }

    void okButtonOnClick()
    {
        instructScreen.SetActive(false);
    }
}
