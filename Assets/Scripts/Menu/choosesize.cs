using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class choosesize : MonoBehaviour
{
    // Start is called before the first frame update
    public Button small;
    public Button medium;
    public Button large;
    public Button isstart;
    public bool Ismap;
    public Button choosemap;
    [SerializeField] GameObject EventSystem;
    void Start()
    {


        Ismap = false;
        small.onClick.AddListener(Issmall);
        medium.onClick.AddListener(Ismedium);
        large.onClick.AddListener(Ishuge);
        choosemap.onClick.AddListener(choosemaps);
        //isstart.enabled = false;
        small.gameObject.SetActive(false);
        medium.gameObject.SetActive(false);
        large.gameObject.SetActive(false);
    }
    public void choosemaps()
    {
        bntshow();
    }
    private void Issmall()
    {
        //傳回start
        EventSystem.SendMessage("SizeInfo", "small");
        bntclear();
    }
    private void Ismedium()
    {
        //傳回start
        EventSystem.SendMessage("SizeInfo", "medium");
        bntclear();
    }
    private void Ishuge()
    {
        //傳回start
        EventSystem.SendMessage("SizeInfo", "large");
        bntclear();
    }
   public void bntclear()
    {
        small.gameObject.SetActive(false);
        medium.gameObject.SetActive(false);
        large.gameObject.SetActive(false);
        isstart.gameObject.SetActive(true);
        Ismap = false;
    }
    private void bntshow()
    {
        small.gameObject.SetActive(true);
        medium.gameObject.SetActive(true);
        large.gameObject.SetActive(true);
    }
}
