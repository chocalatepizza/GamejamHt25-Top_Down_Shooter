using UnityEngine;

public class enemyHarpoon : MonoBehaviour
{
    private GameObject player;
    public float speed = 6f;
    bool tryShoot = false;
    bool tryFlee = false;
    public float fireDistance = 6;
    public float fleeDistance = 3;


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
    }
}