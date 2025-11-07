using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float detectionRange = 5f;
    public float dashRange = 2f;
    public float dashSpeed = 10f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 2f;
    public Transform player;
    private Rigidbody2D rb;
    private bool isDashing = false;
    private float dashTimer = 0f;
    private float dashCooldownTimer = 0f;
    private Vector2 dashDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }
    }

    void FixedUpdate()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Handle dash cooldown
        if (!isDashing && dashCooldownTimer > 0f)
        {
            dashCooldownTimer -= Time.fixedDeltaTime;
        }

        if (isDashing)
        {
            rb.linearVelocity = dashDirection * dashSpeed;
            dashTimer += Time.fixedDeltaTime;

            if (dashTimer >= dashDuration)
            {
                isDashing = false;
                dashTimer = 0f;
                dashCooldownTimer = dashCooldown;
            }
        }
        else if (distanceToPlayer <= dashRange && dashCooldownTimer <= 0f)
        {
            // Start dash
            dashDirection = (player.position - transform.position).normalized;
            isDashing = true;
        }
        else if (distanceToPlayer <= detectionRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * moveSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}