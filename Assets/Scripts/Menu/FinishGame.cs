using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    public GameObject CongratScreen;
    GameObject EventSystem;
    bool isOver = false;
    gameBGM bgm = FindObjectOfType<gameBGM>();
    public GameObject heartstate3;
    public GameObject heartstate2;
    public GameObject heartstate1;
    //KillZone killzone = FindObjectOfType<KillZone>();


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            CongratScreen.SetActive(true);
            heartstate1.SetActive(false);
            heartstate2.SetActive(false);
            heartstate3.SetActive(false);
            EventSystem = GameObject.Find("EventSystem");
            EventSystem.SendMessage("IsPass", true);
            isOver = true;
            if (bgm != null)
            {
               bgm.StopBGM();
            }
        }
    }

    private void Update()
    {
        if(isOver && Input.anyKeyDown) SceneManager.LoadScene("MainGame");
    }

}
