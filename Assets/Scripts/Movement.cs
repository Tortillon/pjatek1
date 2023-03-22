using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public int upForce = 500;
    public float speed = 500;
    public Animator animator;

    public bool isGrounded = false;

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        if (move == 0)
        {
            animator.SetBool("IsRun", false);
        }
        else
        {
            if (move > 0) 
            {
                transform.localScale = new Vector3(2, 2, 0);
            }
            else if (move < 0)
            {
                transform.localScale = new Vector3(-2, 2, 0);
            }
            rb.velocity = new Vector2(move * speed * Time.deltaTime, rb.velocity.y);
            animator.SetBool("IsRun", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        { 
            rb.AddForce(Vector2.up * upForce);
            isGrounded = false;
            animator.SetBool("IsJump", true);
            if (Input.GetAxis("Verctical") < 0)
            {
                animator.SetBool("IsJump", true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        animator.SetBool("IsJump", false);
    }

}
