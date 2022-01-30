using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLine : MonoBehaviour
{
    [SerializeField] GameObject blackLine;
    [SerializeField] GameObject whiteLine;

    public void SetDeathLine(int deathLine)
    {
        float deathLinePos = deathLine + 3.5f;

        blackLine.transform.position = new Vector3( blackLine.transform.position.x , deathLinePos, 0);
        whiteLine.transform.position = new Vector3( whiteLine.transform.position.x , deathLinePos, 0);
    }
}
