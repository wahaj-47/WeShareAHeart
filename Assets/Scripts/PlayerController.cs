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
    Vector2 direction;

    private string playerState;

    public GameObject heartPrefab;
    public float thrust = 20;

    public Transform arrow;
    public float rotationSpeed = 0.5f;
    public float RotAngleZ = 60;


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

        if (Input.GetButtonDown("Fire" + playerId) && playerState == "human" && !isAiming)
        {
            Aim();
        } else if (Input.GetButtonDown("Fire" + playerId) && playerState == "human" && isAiming)
        {
            Throw();
        }

        if (isAiming)
        {
            float rZ = Mathf.SmoothStep(-RotAngleZ, RotAngleZ, Mathf.PingPong(Time.time * rotationSpeed, 1));
            arrow.rotation = Quaternion.Euler(0, 0, rZ);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Aim()
    {
        isAiming = true;
        arrow.gameObject.SetActive(true);
    }

    void Throw()
    {
        isAiming = false;
        arrow.gameObject.SetActive(false);

        SwitchState("ghost");
        GameObject heart = Instantiate(heartPrefab, ThrowPoint.position, Quaternion.identity);
        Rigidbody2D heartRb = heart.AddComponent<Rigidbody2D>();
        heartRb.AddForce(arrow.right * thrust, ForceMode2D.Impulse);
    }

    void SwitchState(string state)
    {
        playerState = state;
        if(state == "human")
        {
            //Enable collision
        }
        else
        {
            //Disable collision
        }
    }
}
