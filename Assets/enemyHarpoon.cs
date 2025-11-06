using UnityEngine;

public class enemyHarpoon : MonoBehaviour
{
    private GameObject player;
    private float speed = 6f;
    bool tryShoot = false;
    bool tryFlee = false;
    float dashTimer = 0;

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

        //checks distance between enemy and this enemy
        float playerDistance = Vector3.Distance(transform.position, playerPosition);

        if (tryShoot == false && (tryFlee == false))
        {
            speed = 6f;
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (tryShoot==true)
        { speed = 0f; }
        if (tryFlee == true)
        {
            speed = 8f;
            transform.position -= transform.up * speed * Time.deltaTime; 
        }

        if (playerDistance > 6)
            {
                tryShoot = false;
                tryFlee = false;
            }
            else if (playerDistance >= 3)
            {
                tryShoot = true;
                tryFlee = false;
            }
            else
            {
                tryShoot = false;
                tryFlee = true;
            }
    }
}