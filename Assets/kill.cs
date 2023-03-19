using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    private Vector2 startPosition;

    public HealthBar healthbar;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        startPosition = transform.position;
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (currentHealth > 1)
            {
                TakeDamage(1);
                transform.position = startPosition;
            }
            else 
            {
                SceneManager.LoadScene("gameover");
            }
        }
    }
}
