using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    public GameObject gameoverUI;
    public GameObject gamecompeletUI;
    public Button winbnt;
    public Text timetxt;
    public bool a;
    public float starttime = 20;
    public float currentime;
    public GameObject auu;
    public GameObject bau;
    bool isWin;
    [SerializeField] GameObject EventSystem;
    // Start is called before the first frame update
    void Start()
    {
        gameoverUI.SetActive(false);
        gamecompeletUI.SetActive(false);
        a = true;
        currentime  = starttime;
        winbnt.onClick.AddListener(OnWinbntClick);
        EventSystem = GameObject.Find("EventSystem");
    }

    // Update is called once per frame
    void Update()
    {
        currentime -= 1*Time.deltaTime;
        if (player_move.health <= 0 && a )
        {
            timetxt.text = "0";
            gameoverUI.SetActive(true);
            isWin = false;
            a = false;
            bau.SetActive(true);
            Time.timeScale = 0;
        }
        if(currentime <= 0 && player_move.health > 0 && a)
        {
            timetxt.text = "0";
            gamecompeletUI.SetActive(true);
            isWin = false;
            a = false;
            auu.SetActive(true);
            Time.timeScale = 0;
        }
        timetxt.text = currentime.ToString();
        if(isWin && a == false)
        {
            if (Input.anyKeyDown) backtoGame();
        }
        else if(isWin == false && a == false)
        {
            if(Input.anyKeyDown) OnWinbntClick();
        }
    }
    public void backtoGame()
    {
        EventSystem.SendMessage("IsPass", false);
        SceneManager.LoadScene("MainGame");
    }
    public void OnWinbntClick()
    {
        EventSystem.SendMessage("IsPass", true);
        SceneManager.LoadScene("MainGame");
    }
}
