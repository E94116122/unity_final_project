using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverScreen;
    public Button backButton;
    [SerializeField] GameObject bgm;
    GameObject EventSystem;

    void Start()
    {
        if (backButton != null)
            backButton.onClick.AddListener(OnBackButtonClick);
    }
    public void OnBackButtonClick()
    {
        bgm.SetActive(false);
        EventSystem = GameObject.Find("EventSystem");
        EventSystem.SendMessage("IsPass", false);
        SceneManager.LoadScene("MainGame");
    }
}
