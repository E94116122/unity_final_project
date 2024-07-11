using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    string Player;
    GameObject EventSystem;
    GameObject BGM;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        BGM = GameObject.Find("bgm");
    }

    public void PlayerSelect(string input)
    {
        Player = input;
    }

    public void TransInfo()
    {
        EventSystem = GameObject.Find("EventSystem");
        EventSystem.SendMessage("PlayerInfo", Player);
        Destroy(BGM);
    }

}
