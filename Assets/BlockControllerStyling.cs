using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControllerStyling : MonoBehaviour
{
    public Color colorA;
    public Color colorB;

    public void SetColors(bool isColorA , List<Block> blocks)
    {
        if(isColorA)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].spriteRender.color = colorA;
                blocks[i].tmp.color = colorB;
            }
        }
        else
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                blocks[i].spriteRender.color = colorB;
                blocks[i].tmp.color = colorA;
            }
        }

        
    }
}
