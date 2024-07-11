using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Info : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator transition;
    public float transitionTime = 2f;
    public void In()
    {
        StartCoroutine( Loadnextlevel());
    }
    IEnumerator Loadnextlevel()
    {
        transition.SetTrigger("Start1");
        yield return new WaitForSeconds(transitionTime);
        transition.SetTrigger("Start2");
        SceneManager.LoadScene("Information");
    }
}
