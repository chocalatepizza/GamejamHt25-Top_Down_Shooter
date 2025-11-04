using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    [SerializeField] float projectileDeleatSpeed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.up * speed;
        StartCoroutine(Deletee());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Deletee()
    {
        yield return new WaitForSeconds(projectileDeleatSpeed);
        Destroy(gameObject);
    }

}
