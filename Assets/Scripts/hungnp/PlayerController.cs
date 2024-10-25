using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    //player movement
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode def;

    //player attack
    public KeyCode attackJ;
    public KeyCode bullet;
    public KeyCode ultimate;
    public KeyCode attackO;

    private Rigidbody2D rb;

    //groundCheck
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundMask;
    public bool isGround;



    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
        if(Input.GetKey(left))
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if(Input.GetKey(right))
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(jump) && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }

    }
}
