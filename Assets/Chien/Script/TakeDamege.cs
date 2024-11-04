using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamege : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Play hurt ainmation
        animator.SetTrigger("Take_Damage");


        if(currentHealth < 0)
        {
            Die();
        }
    }

    
    void Die()
    {
        Debug.Log("Enemy Die!");

        // Die Animation
        animator.SetBool("IsLose", true);

        // Disabale enemy      
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
}
