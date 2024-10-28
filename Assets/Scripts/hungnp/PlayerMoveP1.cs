using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveP1 : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Awake()
    {
        animator = GetComponent<Animator>();
        // Set initial state to Idle
        animator.SetInteger("State", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
            animator.SetTrigger("Jump"); // Set trang thai nhay
        }
        if (rb.velocity.y < 0) 
        {
            animator.SetInteger("State", 3); // Set trang thai roi
        }

        // Movement to the right
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            animator.SetTrigger("Run");
        }
        // Movement to the left
        else if (Input.GetKey(KeyCode.A))
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            animator.SetTrigger("Run");
        }
        // Stop moving
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetInteger("State", 0);
            
        }

        if (Input.GetKeyDown(KeyCode.J)) // danh thuong
        {
            animator.SetTrigger("Attack1"); 
        }

        if (Input.GetKeyDown(KeyCode.I)) // Su dung Ultimate
        {
            animator.SetTrigger("Ulti"); 
        }

        if (Input.GetKeyDown(KeyCode.K)) // Skill 1
        {
            animator.SetTrigger("Skill1"); 
        }

        if (Input.GetKeyDown(KeyCode.U)) // Combo Attack
        {
            animator.SetTrigger("Combo");
        }

        if (Input.GetKeyDown(KeyCode.L)) // Ban Xa
        {
            animator.SetTrigger("Bullet"); 
        }

        if (Input.GetKeyDown(KeyCode.O)) // Skill 3
        {
            animator.SetTrigger("Skill3");
        }
    }
}
