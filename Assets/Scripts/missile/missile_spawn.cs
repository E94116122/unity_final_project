using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile_spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject missile;
    public int xPos;
    public int zPos;
    static public int missileCount;
    public float currentime = 1;
    void Start()
    {
        missileCount = 0;
        currentime = 1;
        StartCoroutine(MissileDrop());
    }
    IEnumerator MissileDrop()
    {
        while(missileCount < 5*currentime++ )
        {
            xPos = Random.Range(-8,8);
            zPos = Random.Range(-4,7);
            Instantiate(missile).transform.position = new  Vector3(xPos, 22, zPos);
            yield return new WaitForSeconds(0.2f);
            missileCount++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        currentime += Time.deltaTime;
    }
}
