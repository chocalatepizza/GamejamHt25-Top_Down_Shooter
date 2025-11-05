using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    [SerializeField] float projectileDeleatSpeed = 1f;
    [SerializeField] float hitDeleatSpeed = 0f;
    public int damage = 40;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.up * speed;
        StartCoroutine(Deletee());
    }



    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            StartCoroutine(HitDeletee());
        }
        else
        {
            StartCoroutine(HitDeletee());
        }
    }


    private IEnumerator Deletee()
    {
        yield return new WaitForSeconds(projectileDeleatSpeed);
        Destroy(gameObject);
    }

    private IEnumerator HitDeletee()
    {
        yield return new WaitForSeconds(hitDeleatSpeed);
        Destroy(gameObject);
    }
}
