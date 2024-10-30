using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveP1 : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rb;

    public PlayerHealth playerHealth;
    Animator animator;
    public class CharAndAnimator
    {
        public Animator animator1;
        public Canvas canvas;
    }

    public CharAndAnimator p1, p2;
    //Rigidbody2D Rigidbody2D;

    private List<CharAndAnimator> listPlayer = new List<CharAndAnimator>();

    // Start is called before the first frame update
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
                player2 = player;
                p2 = new CharAndAnimator()
                {
                    animator1 = player2.GetComponent<Animator>(),
                    canvas = canvas2
                };
                listPlayer.Add(p2);
            }
        }

        Debug.Log(listPlayer.Count);


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
            animator.SetTrigger("Run");
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            
        }
        // Movement to the left
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetTrigger("Run");
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" /* ||Them nut vao day */)
        {
            var gamer1 = p1.canvas.transform.Find("Mana");
            var gamer11 = p1.canvas.transform.Find("Rage");
            var gamer111 = p1.canvas.transform.Find("Healthbar");

            Image mana1 = gamer1.transform.Find("FillBar").GetComponent<Image>();
            Image rage1 = gamer11.transform.Find("FillBar").GetComponent<Image>();
            Image healthbar1 = gamer111.transform.Find("FillBar").GetComponent<Image>();

            playerHealth.MinusMana(2,mana1);

            
        }
    }
}
