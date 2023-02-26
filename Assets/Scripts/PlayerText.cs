using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerText : MonoBehaviour
{
    public TextMeshPro playerLabel;
    public GameObject player;
    string playerName;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name.Equals("Player-One")){
            playerName = "Player 1";
        }
        else{
            playerName = "Player 2";
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // playerLabel.text = playerName.ToString();
        playerLabel.transform.rotation = Camera.main.transform.rotation;
    }
}
