using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    [SerializeField] GameObject BGM;
    [SerializeField] GameObject Player;

    // Start is called before the first frame update
    public void StartGame()
    {
        Destroy(Player);
        Destroy(BGM);
        SceneManager.LoadScene("MainGame");
    }

    private void Start()
    {
        Time.timeScale = 1;
        Player = GameObject.Find("PlayerInfo");
        Player.SendMessage("TransInfo");
    }
}
