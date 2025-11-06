using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyDash : MonoBehaviour
{
    private GameObject player;
    private float speed = 8f;
    bool isDashing = false;
    float dashTimer = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {

        if (isDashing == false)
        {
            //Finds the position of the player
            Vector2 playerPosition = player.transform.position;
            Vector2 direction = (playerPosition - (Vector2)transform.position).normalized;
            transform.up = direction;

            //gets it to move
            transform.position += transform.up * speed * Time.deltaTime;

            //checks distance between enemy and this enemy
            float playerDistance = Vector3.Distance(transform.position, playerPosition);


            if (playerDistance <= 3)
            {
                isDashing = true;
            }
        }
        else
        {
            speed = 12;
            transform.position += transform.up * speed * Time.deltaTime;
            dashTimer += Time.deltaTime;
            if (dashTimer > 1)
            {
                isDashing = false;
                speed = 8;
                dashTimer = 0;
            }
        }
    }
}