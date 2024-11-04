using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
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
    public int attackDamage = 10;

    public float RangeAttack_Range = 0.5f;
    public int Range_attackDamage = 40;

    public float SpecialSkill_Range = 0.5f;
    public int SpecialSkill_attackDamage = 20;
    //---------------------------------------
    // attack rate
    public float attack1_Rate = 2f;
    float nextAttackTime = 0f;

    
    
    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                Attack();
                nextAttackTime = Time.time + 1f/attack1_Rate;
            }
        }

        //Range_Attack
        if (Input.GetKeyDown(KeyCode.L))
        {
            Range_Attack();
            nextAttackTime = Time.time + 1f / attack1_Rate;
        }

        //SpecialSkill
        if (Input.GetKeyDown(KeyCode.K))
        {
            SpecialSkill_Attack();
            nextAttackTime = Time.time + 1f / attack1_Rate;
        }

        // Ulti
        if (Input.GetKeyDown(KeyCode.I)) // Su dung Ultimate
        {
            dragonAttack = GetComponent<DragonAttack>();

            animator.SetTrigger("Ulti");
            dragonAttack.Activate();
        }

    }
    private void Attack()
    {
        // Play an attack animation
        animator.SetTrigger("Attack1");

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attack1_Point.position, attack1_Range, enemyLayers);

        // Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<TakeDamege>().TakeDamage(attackDamage);
        }
    }

    // Range Attack
    private void Range_Attack()
    {
        // Play an attack animation
        animator.SetTrigger("Bullet");

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(RangeAttack_Point.position, RangeAttack_Range, enemyLayers);

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<TakeDamege>().TakeDamage(Range_attackDamage);
        }
    }

    // SpecialSkill Attack
    private void SpecialSkill_Attack()
    {
        // Play an attack animation
        animator.SetTrigger("Skill1");

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(SpecialSkill_Point.position, SpecialSkill_Range, enemyLayers);

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<TakeDamege>().TakeDamage(SpecialSkill_attackDamage);
        }
    }


    private void OnDrawGizmosSelected()
    {
        if(attack1_Point == null)
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
    
}
