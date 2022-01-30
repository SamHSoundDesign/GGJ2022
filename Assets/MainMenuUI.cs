using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void LoadScene(int index)
    {

        if(MenuSceneFades.instanace != null)
        {
            MenuSceneFades.instanace.screenFade.FadeIn();
        }

        LevelLoader.instance.LoadScene(index);
    }

    public void SFXMouseHover()
    {
        AudioManager.instance.PlayAudioClip("MouseHover");
    }

    public void SFXUISelect()
    {
        AudioManager.instance.PlayAudioClip("UIClick");
    }
}
