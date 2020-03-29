using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Stop speed
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.1f, rigid.velocity.y);
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        if(rigid.velocity.normalized.x == 0)
        {
            animator.SetBool("isWalking", false);
        }
        else
            animator.SetBool("isWalking", true);

        KeyDown();
    }

    private void FixedUpdate()
    {
        // Move by countrol
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed) //right
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x < maxSpeed * -1) // left
        {
            rigid.velocity = new Vector2(maxSpeed * -1, rigid.velocity.y);
        }
    }

    void KeyDown()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("kick"); 
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("crouchKick");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            animator.SetTrigger("punch");
        }
    }
}
