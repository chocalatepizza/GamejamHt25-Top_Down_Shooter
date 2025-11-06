using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField] public int maxHealth = 3;
   [SerializeField] private int currentHealth;
    

    public Slider healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth = amount;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Debug.Log("Player died!");
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        healthBar.value = currentHealth;
    }
}
