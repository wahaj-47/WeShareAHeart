using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Animations;

public class PlayerController : MonoBehaviour
{

    public int playerId = 1;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Transform ThrowPoint;
    Vector2 movement;

    bool isAiming = false;
    Vector2 direction;

    public GameObject heartPrefab;
    public float thrust = 30;

    public Transform arrow;
    public float rotationSpeed = 0.5f;
    public float RotAngleZ = 75;

    public float dDayTimer = 10.0f;
    private float timeRemaining = 10;
    public bool timerIsRunning = false;

    public Text timer;

    private bool isMoving = false;

    public Animator animator;

    public AnimatorController playerOneHumanAnimationController;
    public AnimatorController playerOneGhostAnimationController;

    public AnimatorController playerTwoHumanAnimationController;
    public AnimatorController playerTwoGhostAnimationController;

    void Start()    
    {
        timerIsRunning = true;
        if (playerId == 1)
        {
            gameObject.tag = "Human";
            rb.gravityScale = 9.8f;
            //gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            Invoke("Throw", dDayTimer);
            animator.runtimeAnimatorController = playerOneHumanAnimationController;
            gameObject.layer = LayerMask.NameToLayer("Human");
        }
        else
        {
            gameObject.tag = "Ghost";
            rb.gravityScale = 0f;
            //gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            animator.runtimeAnimatorController = playerTwoGhostAnimationController;
            gameObject.layer = LayerMask.NameToLayer("Ghost");
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isMoving", isMoving);
        
        if (isMoving)
        {
            if (gameObject.tag == "Human")
                AudioManager.instance.PlayOnce("Step");
            else
                AudioManager.instance.PlayOnce("Flame");
        }

        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }

        if (gameObject.tag == "Human")
            timer.text = "Dropping in: " + Mathf.FloorToInt(timeRemaining % 60);

        movement.x = Input.GetAxisRaw("Player" + playerId + "Horizontal");

        if(movement.x < 0)
        {
            isMoving = true;
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
        else if(movement.x > 0)
        {
            isMoving = true;
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }
        else
        {
            isMoving = false;
        }

        if (gameObject.tag == "Ghost")
        {
            movement.y = Input.GetAxisRaw("Player" + playerId + "Vertical");
        }
        else
        {
            movement.y = 0;
        }

        if (Input.GetButtonDown("Fire" + playerId) && gameObject.tag == "Human" && !isAiming)
        {
            Aim();
        } else if (Input.GetButtonDown("Fire" + playerId) && gameObject.tag == "Human" && isAiming)
        {
            Throw();
        }

        if (isAiming)
        {
            float rZ = Mathf.SmoothStep(-RotAngleZ, RotAngleZ, Mathf.PingPong(Time.time * rotationSpeed, 1));
            arrow.localRotation = Quaternion.Euler(new Vector3(0f, 0f, rZ));
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
        if(playerId == 1)
        {
            animator.runtimeAnimatorController = playerOneGhostAnimationController;
        }
        else
        {
            animator.runtimeAnimatorController = playerTwoGhostAnimationController;
        }

        AudioManager.instance.Play("Woosh");
        CancelInvoke("Throw");

        isAiming = false;
        arrow.gameObject.SetActive(false);

        StartCoroutine(SwitchState("Ghost", 0.1f));
        //gameObject.GetComponent<BoxCollider2D>().isTrigger = true ;
        
        GameObject heart = Instantiate(heartPrefab, ThrowPoint.position, Quaternion.identity);
        Rigidbody2D heartRb = heart.GetComponent<Rigidbody2D>();
        heartRb.AddForce(arrow.right * thrust, ForceMode2D.Impulse);

    }

    public IEnumerator SwitchState(string tag, float delay = 0)
    {
        yield return new WaitForSeconds(delay);

        gameObject.tag = tag;
        gameObject.layer = LayerMask.NameToLayer(tag);

        if (tag == "Human")
        {
            rb.gravityScale = 9.8f;
            //gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            timeRemaining = 10;
            timerIsRunning = true;
            Invoke("Throw", dDayTimer);
            if (playerId == 1)
            {
                animator.runtimeAnimatorController = playerOneHumanAnimationController;
            }
            else
            {
                animator.runtimeAnimatorController = playerTwoHumanAnimationController;
            }
        }
        else
        {
            rb.gravityScale = 0f;
            //gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    public void RunCoroutine(string tag, float delay)
    {
        StartCoroutine(SwitchState(tag, delay));
    }
}
