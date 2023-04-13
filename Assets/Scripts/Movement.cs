using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public PlayerHealth ph;

    public int upForce = 500;
    public float speed = 500;

    public bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (ph.currentHealth > 0)
        {
            float move = Input.GetAxis("Horizontal");
            if (move == 0)
            {
                animator.SetBool("IsRun", false);
            }
            else
            {
                /*if (move > 0)
                {
                    transform.localScale = new Vector3(2, 2, 0);
                }
                else if (move < 0)
                {
                    transform.localScale = new Vector3(-2, 2, 0);
                }*/
                rb.velocity = new Vector2(move * speed * Time.deltaTime, rb.velocity.y);
                animator.SetBool("IsRun", true);
            }


            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(Vector2.up * upForce);
                isGrounded = false;
                animator.SetBool("IsJump", true);
            }
            
        }
        
        if (rb.velocity.y<0)
        {
            animator.SetBool("IsFall", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        animator.SetBool("IsJump", false);
        animator.SetBool("IsFall", false);
    }

}
