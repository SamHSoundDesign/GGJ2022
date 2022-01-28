using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clues : MonoBehaviour
{
    public List<Clue> clues;
    public List<Clue> cluesB;

    private void Start()
    {
        for (int i = 0; i < clues.Count; i++)
        {
            cluesB.Add(clues[i]);
        }
        
    }


    public Clue GetNewClue(bool isA)
    {
        Clue clue;

        if(isA)
        {
            clue = GetNewClueA();
        }
        else
        {
            clue = GetNewClueB();
        }

        return clue;
        
    }

    private Clue GetNewClueA()
    {
        int n;

        bool clueFound = false;
        Clue clue = null;

        while(clueFound == false)
        {
            n = Random.Range(0, clues.Count - 1);

            if(clues[n] != null)
            {
                clueFound = true;
                clue = clues[n];
            }
        }

        clues.Remove(clue);

        return clue;
    }
    private Clue GetNewClueB()
    {
        int n;

        bool clueFound = false;
        Clue clue = null;

        while (clueFound == false)
        {
            n = Random.Range(0, cluesB.Count - 1);

            if (cluesB[n] != null)
            {
                clueFound = true;
                clue = cluesB[n];
            }
        }

        cluesB.Remove(clue);


        return clue;
    }
}
