using UnityEngine;

public class enemyTank : MonoBehaviour
{
    private GameObject player;
    public float speed = 16f;
    public float stopWalking = 3f;
    public float fireDistance = 8f;
    public float shotCooldown = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Finds the position of the player, looks towards it
        Vector2 playerPosition = player.transform.position;
        Vector2 direction = (playerPosition - (Vector2)transform.position).normalized;
        transform.up = direction;

        //checks distance between enemy and this enemy
        float playerDistance = Vector3.Distance(transform.position, playerPosition);

        if (playerDistance < stopWalking)
        { speed = 0f; }
        else { speed = 4f; }
        transform.position += transform.up * speed * Time.deltaTime;

        if (playerDistance < fireDistance)
        { }

    }
}
