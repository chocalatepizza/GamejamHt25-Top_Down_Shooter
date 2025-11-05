using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyDash : MonoBehaviour
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

        //gets it to move
        transform.position += transform.up * speed * Time.deltaTime;

        //checks distance between enemy and this enemy
        float playerDistance = Vector3.Distance(transform.position, playerPosition);
        if (playerDistance <= 4)
        {
            speed = 10f;
             += 1;
        }
        else
        { 
            speed = 5f;

            playerPosition = player.transform.position;
            direction = (playerPosition - (Vector2)transform.position).normalized;
            transform.up = direction;
        }
    }
}
