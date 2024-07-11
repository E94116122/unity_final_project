using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Tomenu : MonoBehaviour, IPointerClickHandler
{
    GameObject EventSystem;
    GameObject BGM;
    // Start is called before the first frame update
    void Start()
    {
        EventSystem = GameObject.Find("EventSystem");
        BGM = GameObject.Find("bgm");
        Destroy(BGM);
    }
    public void OnPointerClick(PointerEventData e)
    {
        Destroy(EventSystem);
        SceneManager.LoadScene("Menu");
    }
}
