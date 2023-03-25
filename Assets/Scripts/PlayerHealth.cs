using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Rigidbody2D rb;
    public int maxHealth = 5;
    public int currentHealth;
    public HealthBar healthbar;
    public Animator animator;
    public ParticleSystem ps;

    private Vector2 startPosition;
    

    void Gameover()
    {
        SceneManager.LoadScene("gameover");
        animator.SetBool("IsDie", false);
    }

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

   public void Die(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy")|| collision.gameObject.CompareTag("Poddle"))
            {
                if (collision.gameObject.CompareTag("Enemy")) TakeDamage(1);
                else
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePosition;
                    TakeDamage(5);
                    ps.Play();
                }
            
                if (currentHealth > 1)
                    {
                        transform.position = startPosition;
                    }
                    else
                    {
                        animator.SetBool("IsDie", true);
                        Invoke("Gameover", 3);
                    }
            }
        }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die(collision);
    }
}
