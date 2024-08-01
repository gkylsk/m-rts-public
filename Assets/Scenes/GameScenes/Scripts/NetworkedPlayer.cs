using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkedPlayer : NetworkBehaviour
{
    [Networked] public Vector3 Position { get; set; }

    private void Update()
    {
        if (HasStateAuthority)
        {
            Position = transform.position;
            HandleInput();
        }
        else
        {
            transform.position = Position;
        }
    }

    private void HandleInput()
    {
        // Handle player input and movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * Time.deltaTime);
    }
}
