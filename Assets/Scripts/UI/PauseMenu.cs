using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    private Animator anim;

    public void Setup()
    {

        anim = GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    //Pause Menu animation
    public void OpenPauseMenu()
    {
        GameManager.instance.screenFade.FadeOut();

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
        GameManager.instance.screenFade.FadeIn();

        Debug.Log("CLOSED");
        GameManager.instance.SetGameState(GameStates.InGame);
        gameObject.SetActive(false);
    }

    //Menu Buttons
    public void ResumeGame()
    {
        ClosePauseMenu();
    }

    public void ExitGame()
    {

    }

    public void ExitToMainMenu()
    {
        LevelLoader.instance.GoToMenu();
    }
}
