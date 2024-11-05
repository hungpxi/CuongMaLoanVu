using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamege : MonoBehaviour
{
    public Animator animator;

    [SerializeField]
    public int maxHealth = 100;
    int currentHealth;

    [SerializeField]
    int maxMana = 100;
    int currentMana;

    [SerializeField]
    int maxRage = 100;
    int currentRage;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
        currentRage = maxRage;
    }

    public void TakeDamage(Image Ihealth, Image Imana, Image Irage ,int damage, int mana)
    {
        currentHealth -= damage;
        Ihealth.fillAmount = (float)currentHealth / (float)maxHealth;
        
        currentMana -= mana;
        Imana.fillAmount = (float)currentMana / (float)maxMana;

        //currentRage += rage
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
