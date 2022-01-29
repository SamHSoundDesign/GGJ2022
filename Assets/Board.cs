using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public bool isBoardA;
    public List<BlockObject> blockObjects;

    public Color colorA;
    public Color colorB;

    private bool isReveled;

    private void Start()
    {
        isReveled = !isBoardA;
    }
    public BlockObject NewBlockGO(Vector2Int gridRef , GameObject blockPrefab , Block block, bool isA)
    {
        GameObject newBlockGO = Instantiate(blockPrefab, transform.position, Quaternion.identity, gameObject.transform);
        BlockObject blockObject = newBlockGO.GetComponent<BlockObject>();
        blockObject.Setup(gridRef, block.clue , this , colorA , colorB , isA);
        blockObject.tmp.gameObject.SetActive(isReveled);
        blockObjects.Add(blockObject);

        
        
        return blockObject;
    }

   

    public void SetBoardPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    public void RevealBoardDetails()
    {
        isReveled = !isReveled;

        if(isReveled == false)
        {
            for (int i = 0; i < blockObjects.Count; i++)
            {
                blockObjects[i].tmp.gameObject.SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < blockObjects.Count; i++)
            {
                if (blockObjects[i].isA == isBoardA)
                {
                    blockObjects[i].tmp.gameObject.SetActive(true);
                }
            }
        }

        
    }
       
}
