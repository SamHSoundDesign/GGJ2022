using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new level" , menuName = "level")]
public class LevelSO : ScriptableObject
{
    public int levelID;
    public List<ClueSO> clues;
    
    public float levelSpeed;
    public int gridWidth;
    public int failHeight;

    public int targetScore;


}
