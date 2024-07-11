using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DontDestroy : MonoBehaviour
{
    GameObject MainControl;
    GameObject BrickSpwaner;
    [SerializeField] GameObject TextTimer;
    int[,] ListBrick = new int[22, 22];
    int[,] ListFlag = new int[22, 22];
    int count = 0;

    string size = "small";
    string player = "player1";
    float MovingSpeed = 15f;

    int timer = 0;
    bool pass;

    private void Start()
    {
        DontDestroyOnLoad(this);
        size = "small";
        player = "player1";
    }

    public void SizeInfo(string input)
    {
        size = input;
    }

    public void PlayerInfo(string input)
    {
        player = input;
    }

    public void InfoOutput()
    {
        MainControl = GameObject.Find("MainControl");
        BrickSpwaner = GameObject.Find("BrickSpwaner");
        TextTimer = GameObject.Find("Timer");
        TextTimer.GetComponent<TMP_Text>().text = timer.ToString();
        TextTimer.SetActive(true);
        MainControl.SendMessage("PlayerSelect", player);
        if (timer == 0)
        {
            InvokeRepeating("Timer", 1f, 1f);
            BrickSpwaner.SendMessage("SizeSelect", size);
        }
        else
        {
            BrickSpwaner.SendMessage("ReSpwaner", ListBrick);
            BrickSpwaner.SendMessage("ReFlagger", ListFlag);
            BrickSpwaner.SendMessage("ReCounter", count);
            Buffer();
        }
    }

    void Buffer()
    {
        if(pass)
        {
            if (MovingSpeed < 15f)
            {
                MainControl.SendMessage("IsPass", pass);
                MovingSpeed *= 2;
            }
            else BrickSpwaner.SendMessage("Buff");
        }
        else
        {
            if (MovingSpeed < 3) MainControl.SendMessage("EndGame");
            else
            {
                MainControl.SendMessage("IsPass", pass);
                MovingSpeed /= 2f;
            }
        }
    }

    public void IsPass(bool input)
    {
        pass = input;
    }

    void Timer()
    {
        timer++;
        if(TextTimer != null) TextTimer.GetComponent<TMP_Text>().text = timer.ToString();
    }

    public void BrickSaver(int[,] save)
    {
        ListBrick = save;
    }

    public void CountSaver(int save)
    {
        count = save;
    }

    public void FlagSaver(int[,] save)
    {
        ListFlag = save;
    }

    public void ResetTimer()
    {
        timer = 0;
        Destroy(TextTimer);
    }
}
