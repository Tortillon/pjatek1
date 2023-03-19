using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public HealthBar healthbar;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

    }
    void TakeDamage(int damage)
    {
        currentHealth += damage;
        healthbar.SetMaxHealth(currentHealth);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
