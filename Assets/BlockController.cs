using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private Block currentBlock;
    public PlayGrid playGrid;
    private List<Block> blocks = new List<Block>();
    public GameObject blockPrefab;
    private Clues clues;
    private bool isA = false;


    private void Start()
    {
        clues = GetComponent<Clues>();
        NewBlock();
    }

    public void NewBlock()
    {
        isA = !isA;
        GameObject newBlockGO = Instantiate(blockPrefab, ConvertGridRefToPosition(new Vector2Int(3, 10)), Quaternion.identity, gameObject.transform);
        Block newBlock = newBlockGO.GetComponent<Block>();
        currentBlock = newBlock;
        blocks.Add(newBlock);
        currentBlock.pos = ConvertPositionToGridRef(currentBlock.gameObject.transform.position);

        Clue newClue = clues.GetNewClue(isA);

        if(isA)
        {
            currentBlock.clue = newClue.a;
            currentBlock.answer = newClue.b;
        }
        else
        {
            currentBlock.clue = newClue.b;
            currentBlock.answer = newClue.a;
        }
    }

    public Vector3 ConvertGridRefToPosition(Vector2Int gridRef)
    {
        return new Vector3(gridRef.x, gridRef.y, 0);
    }

    public Vector2Int ConvertPositionToGridRef(Vector3 position)
    {
        return new Vector2Int((int)position.x, (int)position.y);
    }

    public void MoveBlock(Vector2Int movement)
    {
        Vector2Int newPos = currentBlock.pos + movement;

        if (CheckForBlockAdjacent(newPos, movement.x))
        {
            newPos.x = currentBlock.pos.x;
        }

        if (newPos.x < 1 || newPos.x > playGrid.gridWidth)
        {
            newPos.x = currentBlock.pos.x;
        }


        //Mark block as grounded if it is about to hit the ground
        if(newPos.y == 1)
        {
            currentBlock.grounded = true;
            currentBlock.pos = newPos;
            currentBlock.transform.position = ConvertGridRefToPosition(currentBlock.pos);
            SetAsGrounded();
            return;
        }

        //If block is NOT about to hit the ground, mark it as grounded IF is about to land on another block
        if (CheckForBlockBelow(newPos))
        {
            //if(CheckForBlockAdjacent(newPos , movement.x))
            //{
            //    newPos.x = currentBlock.pos.y;
            //}

            currentBlock.grounded = true;
            currentBlock.pos = newPos;
            currentBlock.transform.position = ConvertGridRefToPosition(currentBlock.pos);
            SetAsGrounded();

            return;
        }
        else
        {
            if (CheckForBlockAdjacent(newPos, movement.x))
            {
                newPos.x = currentBlock.pos.x;
            }
        }

        CheckMovement(newPos);
        currentBlock.pos = newPos;
        currentBlock.transform.position = ConvertGridRefToPosition(newPos);
    }

    private bool CheckForBlockAdjacent(Vector2Int newPos , int xMoveDirection)
    {
        Block blockAdjacent = null;
        for (int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i].pos == newPos)
            {
                blockAdjacent = blocks[i];
                break;
            }
        }

        if (blockAdjacent == null)
        {
            return false;
        }
        else
        {
            return true;
        }

    }
    private Vector2Int CheckMovement(Vector2Int newPos)
    {
        if (CheckForBlockBelow(newPos))
        {
            currentBlock.grounded = true;
            NewBlock();
        }
        

        return newPos;
    }
    private bool CheckForBlockBelow(Vector2Int newPos)
    {
        Block blockBelow = null;

        for (int i = 0; i < blocks.Count; i++)
        {
            if(blocks[i].pos == new Vector2Int(newPos.x , newPos.y -1))
            {
                blockBelow = blocks[i];
                break;
            }
        }

        if(blockBelow == null)
        {
            return false;
        }
       else
        { 
            return true;
        }
    }

    private void SetAsGrounded()
    {
        bool clueMatched = CheckCluesForMatching();
        NewBlock();
    }

    private bool CheckCluesForMatching()
    {
        bool matchFound = false;
        //CheckBelow
        for (int i = 0; i < blocks.Count; i++)
        {
            if(blocks[i].pos == new Vector2Int(currentBlock.pos.x , currentBlock.pos.y - 1))
            {
                if(blocks[i].clue == currentBlock.answer)
                {
                    matchFound = true;
                    currentBlock.BlockSolved();
                    blocks[i].BlockSolved();
                }
            }
        }

        if(matchFound)
        {
            return matchFound;
        }

        //Check Left
        for (int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i].pos == new Vector2Int(currentBlock.pos.x - 1, currentBlock.pos.y))
            {
                if (blocks[i].clue == currentBlock.answer)
                {
                    matchFound = true;
                    currentBlock.BlockSolved();
                    blocks[i].BlockSolved();
                }
            }
        }

        if (matchFound)
        {
            return matchFound;
        }

        //Check Right
        for (int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i].pos == new Vector2Int(currentBlock.pos.x + 1, currentBlock.pos.y))
            {
                if (blocks[i].clue == currentBlock.answer)
                {
                    matchFound = true;
                    currentBlock.BlockSolved();
                    blocks[i].BlockSolved();
                }
            }
        }

        return matchFound;
    }
}
