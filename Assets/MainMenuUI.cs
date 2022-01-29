using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void LoadScene(int index)
    {
        LevelLoader.instance.LoadScene(index);
    }
}
