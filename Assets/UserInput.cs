using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private Vector2Int movement;

    public float pauseBetweenDrops;
    private float timeForNextDrop;

    public GridController blockController;

    public void Updates()
    {
        movement = Vector2Int.zero;

        if(Input.GetKeyDown(KeyCode.A))
        {
            movement.x -= 1;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            movement.x += 1;
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            movement.y = -1;
            UpdateNextDropTime();
        }

        if(Time.time >= timeForNextDrop)
        {
            movement.y = -1;
            UpdateNextDropTime();
        }


        if(movement != Vector2Int.zero)
        {
            blockController.UserMoveBlock(movement);
        }

    }

    public void UpdateNextDropTime()
    {
        timeForNextDrop = Time.time + pauseBetweenDrops;
    }

    private void HorizontalMovement()
    {
        
    }

    private void VerticalMovement()
    {
        
    }
}
