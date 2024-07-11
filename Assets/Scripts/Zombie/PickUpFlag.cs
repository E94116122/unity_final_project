using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUpFlag : MonoBehaviour
{
    public GameObject GetFlagScreen;
    [SerializeField] GameObject bgm;
    [SerializeField] GameObject wbgm;
    [SerializeField] GameObject EventSystem;
    bool isOver = false;
    [SerializeField] GameObject Player;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetFlagScreen.SetActive(true);
            bgm.SetActive(false);
            wbgm.SetActive(true);
            EventSystem = GameObject.Find("EventSystem");
            EventSystem.SendMessage("IsPass", true);
            Player.SetActive(false);
            isOver = true;
        }
    }

    private void Update()
    {
        if (isOver && Input.anyKeyDown)
        {
            SceneManager.LoadScene("MainGame");
        }
    }
}
