using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    private Block currentBlock;
    public PlayGrid playGrid;
    private List<Block> blocks = new List<Block>();
    public GameObject blockPrefab;
    private Clues clues;
    private bool isA = false;

    public bool blockControllerA;
    private BlockControllerStyling styling;

    public Vector3 offset;

    public Board boardA;
    public Board boardB;

    public Vector2Int startingGridRef;

    
    private void Start()
    {
        clues = GetComponent<Clues>();
        styling = GetComponent<BlockControllerStyling>();
        NewBlock();
    }
    public void NewBlock()
    {
        isA = !isA;
        Clue newClue = clues.GetNewClue(isA);
        Block newBlock = new Block(isA , startingGridRef , blockPrefab , boardA , boardB , newClue);

        currentBlock = newBlock;
        blocks.Add(newBlock);

    }

    public void UserMoveBlock(Vector2Int movement)
    {
        MoveBlock(currentBlock, movement);
    }

    public Vector3 ConvertGridRefToPosition(Vector2Int gridRef)
    {
        return new Vector3(gridRef.x, gridRef.y, 0);
    }
    public Vector2Int ConvertPositionToGridRef(Vector3 position)
    {
        return new Vector2Int((int)position.x, (int)position.y);
    }
    private void MoveBlock(Block block , Vector2Int movement)
    {
        Vector2Int newPos = block.pos + movement;

        newPos = ConfirmNewPosition(newPos , movement , block);

        block.pos = newPos;
        block.UpdateBlockObjectPositions(newPos);

        if(CheckIfGrounded(block))
        {
            block.grounded = true;
            CheckCluesForMatching(block);

            if(block == currentBlock)
            {
                NewBlock();
            }
        }

       
    }
    private bool CheckIfGrounded(Block block)
    {
        bool isGrounded = false;

        if(block.pos.y == 1)
        {
            isGrounded = true;
            return isGrounded;
        }

        for (int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i].pos == new Vector2Int(block.pos.x, block.pos.y - 1))
            {
                isGrounded = true;
                return isGrounded;
            }
        }

        return isGrounded;
    }
    private Vector2Int ConfirmNewPosition(Vector2Int newPos, Vector2Int movement , Block block)
    {
        //Check newPos is within bounds of grid
        if (newPos.x < 1 || newPos.x > playGrid.gridWidth)
        {
            newPos.x = currentBlock.pos.x;
        }

        //Check for a block in the way of the newPos

        Block blockInWay = CheckIfMovementBlocked(newPos);

        if (blockInWay != null)
        {
            if(blockInWay.pos.x == newPos.x)
            {
                newPos.x = block.pos.x;
            }

            if(blockInWay.pos.y == newPos.y)
            {
                newPos.y = block.pos.y;
            }
        }

        return newPos;
    }
    private Block CheckIfMovementBlocked(Vector2Int newPos)
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

        return blockAdjacent;
        

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
    private void CheckCluesForMatching(Block block)
    {
        bool matchFound = false;

        //CheckBelow
        for (int i = 0; i < blocks.Count; i++)
        {
            if(blocks[i].pos == new Vector2Int(block.pos.x , block.pos.y - 1))
            {
                if(blocks[i].clue == block.answer)
                {
                    matchFound = true;
                   
                    ClearSolvedBlocks(block, blocks[i]);
                    return;
                }
            }
        }

        //Check Left
        for (int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i].pos == new Vector2Int(block.pos.x - 1, block.pos.y))
            {
                if (blocks[i].clue == block.answer)
                {
                    matchFound = true;
                  
                    ClearSolvedBlocks(block, blocks[i]);
                    return;
                }
            }
        }

        //Check Right
        for (int i = 0; i < blocks.Count; i++)
        {
            if (blocks[i].pos == new Vector2Int(block.pos.x + 1, block.pos.y))
            {
                if (blocks[i].clue == currentBlock.answer)
                {
                    matchFound = true;

                    ClearSolvedBlocks(blocks[i], block);
                    return;

                }
            }
        }

       

    }
    private void ClearSolvedBlocks(Block blockA, Block blockB)
    {
        blockA.BlockSolved();
        blockB.BlockSolved();

        DestroyBlock(blockA);
        blocks.Remove(blockA);


        DestroyBlock(blockB);
        blocks.Remove(blockB);

        UpdatePositionOfAllAboveBlocks(blockA.pos);
        UpdatePositionOfAllAboveBlocks(blockB.pos);
    }
    private void UpdatePositionOfAllAboveBlocks(Vector2Int pos)
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            if(blocks[i].pos == new Vector2Int(pos.x , pos.y + 1))
            {
                //currentBlock = blocks[i];
                blocks[i].grounded = false;
                MoveBlock(blocks[i] , new Vector2Int(0, -1));

                UpdatePositionOfAllAboveBlocks(new Vector2Int(blocks[i].pos.x , blocks[i].pos.y + 1));
            }
        }
    }
    private void DestroyBlock(Block block)
    {
        block.DestroyBlocks();
    }
    public void BlockSolved()
    {
        GameManager.instance.UpdateScore(1);
        //Destroy(tmp.gameObject);
        //Destroy(gameObject);
    }
    public void UpdateBlockPositions()
    {

    }
}
