using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;
    public Animator animator;

    void Start()
    {
        //INIZIALIZZAZIONE SALUTE
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
            //here cambio scena fumetto vittoria umani conquista mondo ecc. ecc. 
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        animator.SetTrigger("isHurt");
    }
}


