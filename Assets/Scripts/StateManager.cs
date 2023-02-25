using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public static StateManager instance;
    [SerializeField] GameObject playerOne;
    [SerializeField] GameObject playerTwo;
    public float score = 0;
    public float health = 100;
    public bool lost = false;

    public float damage = 3;
    public float threshold = 15;

    float distance = 0;

    private void Awake() {
        if(StateManager.instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Update() {
        distance = (playerOne.transform.position - playerTwo.transform.position).magnitude;
    }

    private void FixedUpdate()
    {
        if (health > 0 && distance > threshold)
            health = health - (damage * (distance / threshold) * Time.fixedDeltaTime);

        Debug.Log(health);
    }

    public void Lose(){
        lost = true;
    }

}