using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public static LevelEnd instance;

    private Animator anim;

    public void Setup()
    {

        anim = GetComponent<Animator>();
        gameObject.SetActive(false);
        //gameObject.SetActive(false);
    }

    //Pause Menu animation
    public void OpenMenu()
    {
        gameObject.SetActive(true);
        anim.SetTrigger("Open");
        

    }

    public void ClosePauseMenu()
    {
        anim.SetTrigger("Open");
    }

    public void ReadyToClose()
    {
        Debug.Log("CLOSED");
        gameObject.SetActive(false);
    }

    public void ReplayLevel()
    {
        LevelLoader.instance.ReplayScene();
    }

    public void NextLevel()
    {
        LevelLoader.instance.NextScene();
    }


}
