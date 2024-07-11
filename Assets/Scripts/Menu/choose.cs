using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class choose : MonoBehaviour
{
    GameObject PlayerInfo;
    GameObject EventSystem;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInfo = GameObject.Find("PlayerInfo");
        EventSystem = GameObject.Find("EventSystem");
    }

    // Update is called once per frame
    void Update()
    {
        if (check.Ischeck == true && 21 < transform.position.x && transform.position.x <= 25)
        {
            PlayerInfo.SendMessage("PlayerSelect", "player1");
            Destroy(EventSystem);
            SceneManager.LoadScene("Menu");
        }
        if (check.Ischeck == true && 16 < transform.position.x && transform.position.x <= 21)
        {
            PlayerInfo.SendMessage("PlayerSelect", "player7");
            Destroy(EventSystem);
            SceneManager.LoadScene("Menu");
        }
        if (check.Ischeck == true && 11 < transform.position.x && transform.position.x <= 16)
        {
            PlayerInfo.SendMessage("PlayerSelect", "player6");
            Destroy(EventSystem);
            SceneManager.LoadScene("Menu");
        }
        if(check.Ischeck == true && 6 < transform.position.x && transform.position.x <= 11)
        {
            PlayerInfo.SendMessage("PlayerSelect", "player5");
            Destroy(EventSystem);
            SceneManager.LoadScene("Menu");
        }
        if (check.Ischeck == true && 1 < transform.position.x && transform.position.x <= 6)
        {
            PlayerInfo.SendMessage("PlayerSelect", "player4");
            Debug.Log("5");
            Destroy(EventSystem);
            SceneManager.LoadScene("Menu");
        }
        if (check.Ischeck == true && -4 < transform.position.x && transform.position.x <= 1)
        {
            PlayerInfo.SendMessage("PlayerSelect", "player3");
            Destroy(EventSystem);
            SceneManager.LoadScene("Menu");
        }
        if (check.Ischeck == true && -9 < transform.position.x && transform.position.x <= -4)
        {
            PlayerInfo.SendMessage("PlayerSelect", "player2");
            Destroy(EventSystem);
            SceneManager.LoadScene("Menu");
        }
        if (check.Ischeck == true && -14 < transform.position.x && transform.position.x <= -9)
        {
            PlayerInfo.SendMessage("PlayerSelect", "player9");
            Debug.Log("8");
            Destroy(EventSystem);
            SceneManager.LoadScene("Menu");
        }
        if (check.Ischeck == true && -17 < transform.position.x && transform.position.x <= -14)
        {
            PlayerInfo.SendMessage("PlayerSelect", "player8");
            Debug.Log("9");
            Destroy(EventSystem);
            SceneManager.LoadScene("Menu");
        }
    }
}
