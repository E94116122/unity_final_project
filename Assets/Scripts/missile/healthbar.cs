using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    private int maxhealth;
    public int curhealth;
    private int healthperheart = 2;
    public Image[] healthImages;
    public Sprite[] healthSprites;
    private void Start()
    {
        maxhealth = 10;
        curhealth = maxhealth;
    }
    void UpdateHearts()
    {
        curhealth =player_move.health;
        bool empty = false;
        int i = 0;
        foreach(Image im in healthImages)
        {
            if(empty)
            {
                im.sprite = healthSprites[0];
            }
            else
            {
                i++;
                if(curhealth >= i * healthperheart)
                {
                    im.sprite = healthSprites[healthSprites.Length - 1];
                }
                else
                {
                    int currentHeartHealth = (int)(healthperheart - (healthperheart * i - curhealth));
                    int healthperimage = healthperheart / (healthSprites.Length - 1);
                    int imageidx = currentHeartHealth / healthperimage;
                    im.sprite = healthSprites[imageidx];
                    empty = true;
                }
            }
        }
    }
    public void Update()
    {
        UpdateHearts();
    }
}
