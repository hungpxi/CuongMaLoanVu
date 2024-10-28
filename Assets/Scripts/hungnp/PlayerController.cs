using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SHG.AnimatorCoder;
public class PlayerController : AnimatorCoder
{
    public float moveSpeed;
    public float jumpForce;
    float horizonMove = 0f;

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
    private SpriteRenderer sprite;

    //groundCheck
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundMask;
    public bool isGround;

    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        rb = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DefaultAnimation(0);
        // horizonMove = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(left))
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(right))
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
        isGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);

        if (Input.GetKeyDown(jump) && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Play(new(Animations.Jump));
        }

    }

    //private void FixedUpdate()
    //{
    //    rb.velocity = new(horizonMove * moveSpeed, rb.velocity.y);
    //}

    public override void DefaultAnimation(int layer)
    {
        if(horizonMove == 0) Play(new(Animations.Idle));
        else Play(new(Animations.Run));
        //if (horizonMove != 0) sprite.flipX = horizonMove < 0;
        if (GetCurrentAnimation(0) != Animations.Attack1 && horizonMove != 0) sprite.flipX = horizonMove < 0;
    }

    private readonly AnimationData IDLE = new(Animations.Idle);
    private readonly AnimationData RUN = new(Animations.Run);

}

//if (Input.GetKey(left))
//{
//    if (transform.localScale.x > 0)
//    {
//        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
//    }

//    rb.velocity = new Vector2(-moveSpeed * horizonMove, rb.velocity.y);
//}
//else if (Input.GetKey(right))
//{
//    if (transform.localScale.x < 0)
//    {
//        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
//    }

//    rb.velocity = new Vector2(moveSpeed * horizonMove, rb.velocity.y);
//}
//else
//{
//    rb.velocity = new Vector2(0, rb.velocity.y);
//}