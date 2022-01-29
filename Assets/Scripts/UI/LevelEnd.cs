using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public static LevelEnd instance;

    private Animator anim;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        gameObject.SetActive(false);

        anim = GetComponent<Animator>();
    }

    //Pause Menu animation
    public void OpenMenu()
    {
        gameObject.SetActive(true);
        anim.SetTrigger("Open");
        GameManager.instance.SetGameState(GameStates.PauseMenu);

    }

    public void ClosePauseMenu()
    {
        anim.SetTrigger("Open");
    }

    public void ReadyToClose()
    {
        Debug.Log("CLOSED");
        GameManager.instance.SetGameState(GameStates.InGame);
        gameObject.SetActive(false);
    }

    
}
