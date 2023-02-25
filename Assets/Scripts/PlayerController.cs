using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int playerId = 1;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Transform ThrowPoint;
    Vector2 movement;

    bool isAiming = false;
    bool directionSet = false;

    private string playerState;

    public GameObject prefab;
    public float thrust = 20;

    void Start()    
    {
        if (playerId == 1) playerState = "human";
        else playerState = "ghost";
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Player" + playerId + "Horizontal");
        
        if(playerState == "ghost")
        {
            movement.y = Input.GetAxisRaw("Player" + playerId + "Vertical");
        }

        if(Input.GetButtonDown("Fire" + playerId) && playerState == "human")
        {
            Throw();
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Throw()
    {
        GameObject heart = Instantiate(prefab, ThrowPoint.position, Quaternion.identity);
        Rigidbody2D heartRb = heart.AddComponent<Rigidbody2D>();
        heartRb.AddForce(transform.right * thrust, ForceMode2D.Impulse);
    }
}
