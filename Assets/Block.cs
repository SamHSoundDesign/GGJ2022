using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    public string clue;
    public string answer;
    public bool grounded;

    public Vector2Int pos;

    public bool isA;

    public bool clueSolved = false;

    private SpriteRenderer spriteRender;

    public Color solvedColor;

    private TextMeshPro tmp;


    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        tmp = GetComponentInChildren<TextMeshPro>();
        tmp.text = clue;
    }
    public void BlockSolved()
    {
        clueSolved = true;
        spriteRender.color = solvedColor;

    }
    
}
