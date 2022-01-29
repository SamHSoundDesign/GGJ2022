using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public bool isBoardA;
    public List<BlockObject> blockObjects;

    public Color colorA;
    public Color colorB;

    public BlockObject NewBlockGO(Vector2Int gridRef , GameObject blockPrefab , Block block)
    {
        GameObject newBlockGO = Instantiate(blockPrefab, transform.position, Quaternion.identity, gameObject.transform);
        BlockObject blockObject = newBlockGO.GetComponent<BlockObject>();
        blockObject.Setup(gridRef, block.clue , this , colorA , colorB);
        blockObjects.Add(blockObject);
        
        return blockObject;
    }

   

    public void SetPosition()
    {

    }

       
}
