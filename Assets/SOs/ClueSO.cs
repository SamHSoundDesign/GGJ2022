using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new clue", menuName = "clues")]
public class ClueSO : ScriptableObject
{
    public string a;
    public string b;

    public string GetClue(bool isA)
    {
        if(isA)
        { 
            return a;
        }
        else
        {
            return b;
        }
    }

}
