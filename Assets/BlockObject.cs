using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockObject : MonoBehaviour
{
    private Board board;
    private TextMeshPro tmp;
    private SpriteRenderer rend;

    public void Setup(Vector2Int gridRef , string clue, Board board , Color colorA , Color colorB)
    {
        tmp = GetComponentInChildren<TextMeshPro>();
        rend = GetComponent<SpriteRenderer>();

        this.board = board;
        SetPosition(gridRef);
        tmp.text = clue;

        SetStyling(colorA , colorB);
    }

    private void SetStyling(Color colorA , Color colorB)
    {
        if(board.isBoardA)
        {
            rend.color = colorA;
            tmp.color = colorB;
        }
        else
        {
            rend.color = colorB;
            tmp.color = colorA;
        }
    }

    public void SetPosition(Vector2Int gridRef)
    {
        transform.position = ConvertGridRefToPosition(gridRef) + board.transform.position;
    }

    public Vector3 ConvertGridRefToPosition(Vector2Int gridRef)
    {
        return new Vector3(gridRef.x, gridRef.y, 0);
    }

}
