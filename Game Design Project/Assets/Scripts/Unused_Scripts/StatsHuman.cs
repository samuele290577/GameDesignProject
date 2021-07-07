using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsHuman : MonoBehaviour
{
    public int maxHealth = 150;
    public int currentHealth;
    public HealthBar healthBar;
    public Animator animator;



    void Start()
    {
        if (gameObject.name == "Human_Player" || gameObject.name == "Plant_Player")
        {
            maxHealth = 150;
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("Game over le piante hanno vinto");
            //qui cambio scena storia vittoria umani (???) 
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        animator.SetTrigger("isHurt");
    }
}

