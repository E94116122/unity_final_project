using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchmissile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
       
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "floor")
        {
            Destroy(gameObject);
            missile_spawn.missileCount--;
        }
        if (other.transform.tag == "Player")
        {

            player_move.health -= 1;
            Destroy(gameObject);
            Debug.Log("uh");
            player_move.hit = true;
        }
        
    }
    
}
