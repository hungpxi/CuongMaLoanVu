using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayerMoves_P1;

public class PlayerMoveP2 : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public PlayerHealth playerHealth;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    Animator animator;
    public CharAndAnimator p1, p2;
    private List<CharAndAnimator> listPlayer = new List<CharAndAnimator>();
    // Start is called before the first frame update
    private Image mana1, rage1, healthbar1, mana2, rage2, healthbar2;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        Canvas canvas1 = GameObject.FindGameObjectWithTag("Health1").GetComponent<Canvas>();
        Canvas canvas2 = GameObject.FindGameObjectWithTag("Health2").GetComponent<Canvas>();
        GameObject player1, player2;
        foreach (GameObject player in players)
        {
            if (player.transform.localScale.x > 0)
            {
                var active = player.gameObject.GetComponent<PlayerMoveP2>();
                if(active != null)
                {
                    active.enabled = false;
                }
                
                player1 = player;
                p1 = new CharAndAnimator()
                {
                    animator1 = player1.GetComponent<Animator>(),
                    canvas = canvas1
                };
                listPlayer.Add(p1);
            }
            else
            {
                var active = player.gameObject.GetComponent<PlayerMoves_P1>();
                if(active != null)
                {
                    active.enabled = false;
                }

                player2 = player;
                p2 = new CharAndAnimator()
                {
                    animator1 = player2.GetComponent<Animator>(),
                    canvas = canvas2
                };
                listPlayer.Add(p2);
            }
        }
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
        if (Input.GetKeyDown(KeyCode.UpArrow) && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("Jump"); // Set trang thai nhay
        }
        if (rb.velocity.y < 0)
        {
            animator.SetInteger("State", 3); // Set trang thai roi
        }

        // Movement to the right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

            animator.SetInteger("State", 1); // set trang thai chay 

        }
        // Movement to the left
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);

            animator.SetInteger("State", 1);// set trang thai chay 

        }
        // Stop moving
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetInteger("State", 0);

        }

        if (Input.GetKeyDown(KeyCode.Keypad1)) // danh thuong
        {
            animator.SetTrigger("Attack1");
        }

        if (Input.GetKey(KeyCode.DownArrow)) // block
        {
            animator.SetTrigger("Block");
        }

        if (Input.GetKeyDown(KeyCode.Keypad5)) // Su dung Ultimate
        {
            animator.SetTrigger("Ulti");
        }

        if (Input.GetKeyDown(KeyCode.Keypad2)) // Skill 1
        {
            animator.SetTrigger("Skill1");
        }

        if (Input.GetKeyDown(KeyCode.Keypad4)) // Combo Attack
        {
            animator.SetTrigger("Combo");
        }

        if (Input.GetKeyDown(KeyCode.Keypad3)) // Ban Xa
        {
            animator.SetTrigger("Bullet");
        }

        if (Input.GetKeyDown(KeyCode.Keypad6)) // Skill 3
        {
            animator.SetTrigger("Skill3");
        }
    }
}
