using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public int currentLevel;

    public List<LevelSO> levels;


    public LevelSO GetLevelSO()
    {
        return levels[currentLevel - 1];
    }


}


