using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;

    [SerializeField] int maxmana;
    int currentMana;

    [SerializeField] int maxrage;
    int currentrage;

    public UnityEvent OnDeath;



    private void OnEnable()
    {
        OnDeath.AddListener(Death);
    }

    private void OnDisable()
    {
        OnDeath.RemoveListener(Death);
    }

    private void Start()
    {
        currentrage = maxrage;
        currentMana = maxmana;
        currentHealth = maxHealth;
        //healthBar.UpdateBar(currentHealth, maxHealth);
    }

    public void MinusMana(int mana, Image manaBar)
    {
        currentMana -= mana;
        manaBar.fillAmount = (float)currentMana / (float)maxmana;

    }


    public void AddMana(int mana, Image manaBar)
    {
        currentMana += mana;
        manaBar.fillAmount = (float)currentMana / (float)maxmana;

    }


    public void MinusRage(int rage, Image rageBar)
    {
        currentrage -= rage;
        rageBar.fillAmount = (float)currentrage / (float)maxrage;
    }

    public void AddRage(int rage, Image rageBar)
    {
        currentrage += rage;
        rageBar.fillAmount = (float)currentrage / (float)maxrage;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            OnDeath.Invoke();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("EndGame");
    }

    private void Update()
    {

    }
}