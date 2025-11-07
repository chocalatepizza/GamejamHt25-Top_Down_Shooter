using UnityEngine;

public class enemyProjectile : MonoBehaviour
{
    private GameObject player;
    public float speed = 7f;
    public float deleteTime = 2;
    float timeExisting = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPosition = player.transform.position;
        Vector2 direction = (playerPosition - (Vector2)transform.position).normalized;
        transform.up = direction;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        timeExisting += Time.deltaTime;

        if (timeExisting > deleteTime)
        { Destroy(gameObject); }

    }
}
