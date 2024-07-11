using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainControl : MonoBehaviour
{
    [SerializeField] GameObject MainCamera;
    [SerializeField] GameObject BrickSpwaner;
    [SerializeField] GameObject EventSystem;
    GameObject Player;
    private Vector3 pos;
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;
    [SerializeField] GameObject Player3;
    [SerializeField] GameObject Player4;
    [SerializeField] GameObject Player5;
    [SerializeField] GameObject Player6;
    [SerializeField] GameObject Player7;
    [SerializeField] GameObject Player8;
    [SerializeField] GameObject Player9;
    private bool canFlag = true;
    private bool isEnd = false;
    private bool canMove = true;
    [SerializeField] GameObject TextRound;
    [SerializeField] GameObject Pause_pic;
    [SerializeField] GameObject Pause_text;
    int round;

    // Start is called before the first frame update
    void Start()
    {
        isEnd = false;
        Pause_pic.SetActive(false);
        EventSystem = GameObject.Find("EventSystem");
        EventSystem.SendMessage("InfoOutput");
        Time.timeScale = 1;
        TextRound.SetActive(true);
        round = 5;
        TextRound.GetComponent<TMP_Text>().text = "Round : " + round.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        MainCamera.gameObject.SendMessage("TransPos", Player.transform.localPosition);
        Player.gameObject.SendMessage("TransCam", MainCamera.transform);
        if(Time.timeScale == 1 && canMove)
        {
            if (Input.GetMouseButtonDown(0))
            {
                BrickSpwaner.SendMessage("BrickCheck", Player.transform.localPosition);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                BrickSpwaner.SendMessage("FlagRecycle", Player.transform.localPosition);
                pos = Player.transform.position;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                BrickSpwaner.SendMessage("FRunShow");
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Mathf.FloorToInt((pos.x + 1.2f) / 2.4f) != Mathf.FloorToInt((Player.transform.position.x + 1.2f) / 2.4f)
                    || Mathf.FloorToInt((pos.z + 1.2f) / 2.4f) != Mathf.FloorToInt((Player.transform.position.z + 1.2f) / 2.4f))
                {
                    BrickSpwaner.SendMessage("FRunShow");
                    BrickSpwaner.SendMessage("FlagRecycle", Player.transform.localPosition);
                    pos = Player.transform.position;
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(1) && canFlag)
                {
                    canFlag = false;
                    Invoke("FlagCD", .5f);
                    BrickSpwaner.SendMessage("FlagSet", Player.transform.localPosition);
                }
            }
            if (round == 0 && isEnd == false)
            {
                Pause_pic.SetActive(true);
                Pause_text.GetComponent<TMP_Text>().text = "Laoding...";
                Pause_text.GetComponent<TMP_Text>().color = Color.blue;
                canMove = false;
                Player.SendMessage("Freeze");
                Invoke("GameChanger", 1f);
            }
        }
        if (isEnd && Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(EventSystem);
            Destroy(BrickSpwaner);
            Destroy(this);
            SceneManager.LoadScene("Menu");
        }
    }

    public void RoundPlus()
    {
        round--;
        if (round > 0) TextRound.GetComponent<TMP_Text>().text = "Round : " + round.ToString();
        if (round == 1) TextRound.GetComponent<TMP_Text>().text = "Game Comming";
    }

    void FlagCD()
    {
        canFlag = true;
    }

    public void PlayerSelect(string player)
    {
        switch (player)
        {
            case "player1":
                Player = Instantiate(Player1);
                break;
            case "player2":
                Player = Instantiate(Player2);
                break;
            case "player3":
                Player = Instantiate(Player3);
                break;
            case "player4":
                Player = Instantiate(Player4);
                break;
            case "player5":
                Player = Instantiate(Player5);
                break;
            case "player6":
                Player = Instantiate(Player6);
                break;
            case "player7":
                Player = Instantiate(Player7);
                break;
            case "player8":
                Player = Instantiate(Player8);
                break;
            case "player9":
                Player = Instantiate(Player9);
                break;
            default:
                Player = Instantiate(Player1);
                break;
        }
        if(Player == null) Player = Instantiate(Player1);
        Player.transform.tag = "player";
        Player.SetActive(true);
        Player.transform.position = new Vector3(0, 1, 0);
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        Pause_pic.SetActive(true);
        Pause_text.GetComponent<TMP_Text>().text = "GameOver\n<size=60>press ESC to return to menu";
        Pause_text.GetComponent<TMP_Text>().color = Color.red;
        TextRound.SetActive(false);
        EventSystem.SendMessage("ResetTimer");
        isEnd = true;
    }

    public void Win()
    {
        Time.timeScale = 0;
        Pause_pic.SetActive(true);
        Pause_text.GetComponent<TMP_Text>().text = "You Win\n<size=60>press ESC to return to menu";
        Pause_text.GetComponent<TMP_Text>().color = Color.yellow;
        TextRound.SetActive(false);
        EventSystem.SendMessage("ResetTimer");
        isEnd = true;
    }

    void GameChanger()
    {
        if(!isEnd)
        {
            BrickSpwaner.SendMessage("SaveBrick");
            BrickSpwaner.SendMessage("SaveFlag");
            int rnd = Random.Range(0, 3);
            switch (rnd)
            {
                case 0:
                    SceneManager.LoadScene("Zombie");
                    break;
                case 1:
                    SceneManager.LoadScene("FallGuys");
                    break;
                case 2:
                    SceneManager.LoadScene("missile");
                    break;
                default:
                    SceneManager.LoadScene("MainGame");
                    break;
            }
        }
    }

    public void IsPass(bool pass)
    {
        if (pass) Player.SendMessage("Buff");
        else Player.SendMessage("DeBuff");
    }
}
