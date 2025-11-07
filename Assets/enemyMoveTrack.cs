using System;
using UnityEngine;

public class enemyMoveTrack : MonoBehaviour
{
    private GameObject player;
    private float speed = 5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        //Finds the position of the player
        Vector2 playerPosition = player.transform.position;
        Vector2 direction = (playerPosition - (Vector2)transform.position).normalized;
        transform.up = direction;

        // Gets it to move
        transform.position += transform.up * speed * Time.deltaTime;

        //checks distance between enemy and player
        float playerDistance = Vector3.Distance(transform.position, playerPosition);
        
    }
}
