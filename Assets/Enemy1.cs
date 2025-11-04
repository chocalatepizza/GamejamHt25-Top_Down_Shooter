using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private GameObject player;
    private float speed = 5f; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPosition = player.transform.position;
        Vector2 direction = (playerPosition - (Vector2)transform.position).normalized;
        transform.up = direction;

        transform.position += transform.up * speed * Time.deltaTime;
    }

   
}
