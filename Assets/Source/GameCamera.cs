using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{


    // External references
    private PlayerCharacter player;

    // Called before start
    private void Awake()
    {
        player = FindObjectOfType<PlayerCharacter>();
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Always follow the player's position
        transform.position = player.transform.position;
    }
}
