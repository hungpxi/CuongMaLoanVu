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

    public Image healthBar; // Tham chiếu đến thanh máu trên UI

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
        currentRage = maxRage;

        // Khởi tạo thanh máu ban đầu
        UpdateHealthUI();
    }

    public void TakeDamage(Image Ihealth, Image Irage ,int damage,int Rage_nhan_Dame)
    {
        currentHealth -= damage;
        Ihealth.fillAmount = (float)currentHealth / (float)maxHealth;

        currentRage += Rage_nhan_Dame;
        Irage.fillAmount = (float)currentRage / (float)maxRage;

        //currentRage += rage
        // Play hurt ainmation
        animator.SetTrigger("Take_Damage");


        if(currentHealth < 0)
        {
            Die();
        }
    }

    // Ở trong class TakeDamege
    public int GetCurrentMana()
    {
        return currentMana;
    }
    public int GetCurrentRage()
    {
        return currentRage;
    }

    public void ResetRage()
    {
        currentRage = 0;
        UpdateRageUI();
    }

    // Cập nhật thanh Rage trên UI
    private void UpdateRageUI()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentRage / maxRage;
        }
    }
    // Cập nhật thanh máu trên UI
    private void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
    }

    // dragon dame
    public void TakeDamage1(int damage)
    {
        currentHealth -= damage;

        // Tự động cập nhật thanh máu trên UI
        UpdateHealthUI();
        // Update thanh máu nếu cần thiết
        // Ihealth.fillAmount = (float)currentHealth / (float)maxHealth;

        animator.SetTrigger("Take_Damage");

        if (currentHealth <= 0)
        {
            Die();
        }
    }


    public void TakeMana(Image Imana, int mana)
    {
        currentMana -= mana;
        Imana.fillAmount = (float)currentMana / (float)maxMana;
    }

    public void TakeRage(Image Irage, int rage)
    {
        currentRage -= rage;
        Irage.fillAmount = (float)currentRage / (float)maxRage;
    }
    public void AddRage(Image Irage, int rage)
    {
        currentRage += rage;
        Irage.fillAmount = (float)currentRage / (float)maxRage;
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
