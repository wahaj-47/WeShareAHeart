using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int playerId = 1;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    private string playerState;

    void Start()    
    {
        playerId == 1 ? playerState = "human" : " ghost";
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Player" + playerId + "Horizontal");
        
        if(playerState = ghost)
            movement.y = Input.GetAxisRaw("Player" + playerId + "Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
