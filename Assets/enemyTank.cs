using UnityEngine;

public class enemyTank : MonoBehaviour
{
    private GameObject player;
    public float speed = 4f;
    public float shootRange = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
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

        if (playerDistance < shootRange)
        { speed = 0f; }
        else { speed = 4f; }
    }
}
