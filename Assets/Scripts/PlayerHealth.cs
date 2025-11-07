using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 3;
    [SerializeField] private int currentHealth;
    [SerializeField] private float invulnerabilityTime = 1f;
    [SerializeField] private List<Image> heartImages; 

    private bool isInvulnerable = false;
    private float invulTimer = 0f;

    //Death menu
    [SerializeField] private GameObject deathMenu; 

    private bool isDead = false;


    void Start()
    {
        currentHealth = maxHealth;
        deathMenu.SetActive(false);
        UpdateHearts();
    }

    void Update()
    {
        if (isInvulnerable)
        {
            invulTimer += Time.deltaTime;
            if (invulTimer >= invulnerabilityTime)
            {
                isInvulnerable = false;
                invulTimer = 0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyBullet"))
        {
            TakeDamage(1); // Adjust damage value as needed
        }
    }

    public void TakeDamage(int amount)
    {
        if (isInvulnerable) return;
        if (isDead) return;
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHearts();

        if (currentHealth <= 0)
        {
            isDead = true;
            deathMenu.SetActive(true); // Show death menu
            Time.timeScale = 0f; // Pause game

        }

        isInvulnerable = true;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHearts();
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < heartImages.Count; i++)
        {
            heartImages[i].color = i < currentHealth ? Color.red : Color.gray;
        }
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}