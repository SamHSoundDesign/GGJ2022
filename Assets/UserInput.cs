using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private Vector2Int movement;

    [SerializeField] private float pauseBetweenDrops = 1;
    private float timeForNextDrop;

    public BlockController blockController;

    private void Start()
    {
        UpdateNextDropTime();
    }

    private void Update()
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
            blockController.MoveBlock(movement);
        }

    }

    private void UpdateNextDropTime()
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
