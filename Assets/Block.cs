using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block
{
    public string clue;
    public string answer;
    public bool grounded;

    public Vector2Int pos;

    public bool clueSolved = false;

    public SpriteRenderer spriteRender;

    public TextMeshPro tmp;

    public BlockObject blockObjectA;
    public BlockObject blockObjectB;

    public bool isA;
   
    public Block(bool isA , Vector2Int startingGridRef, GameObject blockPrefab , Board boardA , Board boardB , Clue clue)
    {
        pos = startingGridRef;
        this.isA = isA;
        if (isA)
        {
            this.clue = clue.a;
            answer = clue.b;
        }
        else
        {
            this.clue = clue.b;
            answer = clue.a;
        }

        blockObjectA = boardA.NewBlockGO(startingGridRef, blockPrefab, this , isA);
        blockObjectB = boardB.NewBlockGO(startingGridRef, blockPrefab, this , isA);

    }

    public void BlockSolved()
    {
        clueSolved = true;
    }

    public void UpdateBlockObjectPositions(Vector2Int pos)
    {
        blockObjectA.SetPosition(pos);
        blockObjectB.SetPosition(pos);
    }

    public void DestroyBlocks()
    {
        blockObjectA.DestroyBlock();
        blockObjectB.DestroyBlock();

        GameManager.instance.UpdateScore(1);

    }
}   
