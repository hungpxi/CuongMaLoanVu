using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat2 : MonoBehaviour
{
    public TakeDamege TakeDamege;
    //Mau, mana, no
    private Image heathBar1, Mana1, Rage1, heathBar2, Mana2, Rage2;
    private Canvas canvas1, canvas2;
    // dragon
    private DragonAttack dragonAttack; // Tham chiếu tới chiêu thức rồng của nhân vật


    public Animator animator;
    // cac point diem danh
    public Transform attack1_Point;
    public Transform RangeAttack_Point;
    public Transform SpecialSkill_Point;




    public LayerMask enemyLayers;

    //--------------------------------------
    // dame và tầm chiêu
    public float attack1_Range = 0.5f;
    public int attackDamage = 2;
    public int MinusMana = 10;
    public int AddRage = 10;
    public int Rage_nhan_Dame = 10;


    public float RangeAttack_Range = 0.5f;
    public int Range_attackDamage = 8;

    public float SpecialSkill_Range = 0.5f;
    public int SpecialSkill_attackDamage = 20;

    //---------------------------------------
    // attack rate
    public float attack1_Rate = 2f;
    float nextAttackTime = 0f;

    // Rigidbody2D

    private Rigidbody2D rb;
    public float moveSpeed;
    public float jumpForce;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        dragonAttack = GetComponent<DragonAttack>();

        animator = GetComponent<Animator>();
        if (TakeDamege == null)
        {
            TakeDamege = GetComponent<TakeDamege>();
        }
        // canvas cua P1
        canvas1 = GameObject.Find("Health 2").GetComponent<Canvas>();
        heathBar1 = canvas1.transform.Find("Healthbar").transform.Find("FillBar").GetComponent<Image>();
        Mana1 = canvas1.transform.Find("Mana").transform.Find("FillBar").GetComponent<Image>();
        Rage1 = canvas1.transform.Find("Rage").transform.Find("FillBar").GetComponent<Image>();

        // canvas cua P2
        canvas2 = GameObject.Find("Health 1").GetComponent<Canvas>();
        heathBar2 = canvas2.transform.Find("Healthbar").transform.Find("FillBar").GetComponent<Image>();
        Mana2 = canvas2.transform.Find("Mana").transform.Find("FillBar").GetComponent<Image>();
        Rage2 = canvas2.transform.Find("Rage").transform.Find("FillBar").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isP4 = gameObject.CompareTag("P4");

        // run jump stop
        if (Input.GetKeyDown(KeyCode.UpArrow) && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            if (isP4)
                animator.SetInteger("Integer", 2);
            else
                animator.SetTrigger("Jump"); // Set trang thai nhay
        }
        if (rb.velocity.y < 0)
        {
            if (isP4)
                animator.SetInteger("Integer", 0);
            else
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
            if (isP4)
                animator.SetInteger("Integer", 1);
            else
                animator.SetTrigger("Run");
        }
        // Movement to the left
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            if (isP4)
                animator.SetInteger("Integer", 1);
            else
                animator.SetTrigger("Run");
        }
        // Stop moving
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            if (isP4)
                animator.SetInteger("Integer", 0);
            else
                animator.SetInteger("State", 0);

        }







        //===========
        if (Time.time > nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attack1_Rate;
            }
        }

        //Range_Attack
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Range_Attack();
            nextAttackTime = Time.time + 1f / attack1_Rate;
        }

        //SpecialSkill
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            SpecialSkill_Attack();
            nextAttackTime = Time.time + 1f / attack1_Rate;
        }

        // Ulti
        if (Input.GetKeyDown(KeyCode.Keypad5)) // Su dung Ultimate
        {
            dragonAttack = GetComponent<DragonAttack>();
            if (isP4)
                animator.SetTrigger("Ulti");
            else
                animator.SetTrigger("Ulti");
            dragonAttack.Activate();
        }

    }
    private void Attack()
    {
        // Play an attack animation
        if (gameObject.CompareTag("P4"))
            animator.SetInteger("Integer", 4);
        else
            animator.SetTrigger("Attack1");

        // TakeDamege.TakeMana(Mana1, MinusMana);
        TakeDamege.TakeRage(Rage1, AddRage);

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attack1_Point.position, attack1_Range, enemyLayers);

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<TakeDamege>().TakeDamage(heathBar2, Rage2, attackDamage, Rage_nhan_Dame);
        }
    }

    // Range Attack
    private void Range_Attack()
    {
        // Play an attack animation
        if (gameObject.CompareTag("P4"))
            animator.SetInteger("Integer", 5);
        else
            animator.SetTrigger("Bullet");

        TakeDamege.TakeMana(Mana1, MinusMana);
        TakeDamege.AddRage(Rage1, AddRage);

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(RangeAttack_Point.position, RangeAttack_Range, enemyLayers);

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<TakeDamege>().TakeDamage(heathBar2, Rage2, Range_attackDamage, Rage_nhan_Dame);
        }
    }

    // SpecialSkill Attack
    private void SpecialSkill_Attack()
    {
        // Play an attack animation
        if (gameObject.CompareTag("P4"))
            animator.SetInteger("Integer", 6);
        else
            animator.SetTrigger("Skill1");

        TakeDamege.TakeMana(Mana1, MinusMana + 20);
        TakeDamege.AddRage(Rage1, AddRage);

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(SpecialSkill_Point.position, SpecialSkill_Range, enemyLayers);

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<TakeDamege>().TakeDamage(heathBar2, Rage2, SpecialSkill_attackDamage, Rage_nhan_Dame);
        }
    }


    private void OnDrawGizmosSelected()
    {
        if (attack1_Point == null)
        {
            return;
        }
        if (RangeAttack_Point == null)
        {
            return;
        }
        if (SpecialSkill_Point == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attack1_Point.position, attack1_Range);
        Gizmos.DrawWireSphere(RangeAttack_Point.position, RangeAttack_Range);
        Gizmos.DrawWireSphere(SpecialSkill_Point.position, SpecialSkill_Range);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    gameObject.GetComponent<TakeDamege>().TakeDamage(heathBar, Mana, Rage, attackDamage, MinusMana);
    //}

}
