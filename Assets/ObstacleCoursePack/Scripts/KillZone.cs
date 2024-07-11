using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{

    public GameObject heartstate3;
    public GameObject heartstate2;
    public GameObject heartstate1;
    //public GameObject heartstate0;
    public GameObject GameOverScreen;
    GameObject EventSystem;
    bool isOver = false;
    int health = 3;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
			col.gameObject.GetComponent<CharacterControls>().LoadCheckPoint();
            health--;
		}
	}
    private void Update()
    {
        if (health == 2)
        {
            heartstate3.SetActive(false);
            heartstate2.SetActive(true);
        }
        else if (health == 1)
        {
            heartstate2.SetActive(false);
            heartstate1.SetActive(true);
        }
        else if(health == 0)
        {
            heartstate1.SetActive(false);
            //heartstate0.SetActive(true);
            GameOverScreen.SetActive(true);
            EventSystem = GameObject.Find("EventSystem");
            EventSystem.SendMessage("IsPass", false);
            isOver = true;
        }
        if (isOver && Input.anyKeyDown) SceneManager.LoadScene("MainGame");
    }
    public void Hide()
    {
        
        //heartstate0.SetActive(false);
        heartstate1.SetActive(false);
        heartstate2.SetActive(false);
        heartstate3.SetActive(false);
        //Time.timeScale = 0f;
    }
}
