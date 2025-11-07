using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyDash : MonoBehaviour
{
    private GameObject player;
    float speed = 7f;
    public float dashSpeed = 14f;
    public float dashActivationDistance = 4f;
    public float dashTimeInSeconds = 1;
    bool isDashing = false;
    float dashTimer = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        //Finds the position of the player

        if (isDashing == false)
        {
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
            speed = dashSpeed;
            transform.position += transform.up * speed * Time.deltaTime;
            dashTimer += Time.deltaTime;
            if (dashTimer > dashTimeInSeconds)
            {
                isDashing = false;
                speed = 7;
                dashTimer = 0;
            }
        }
    }
}