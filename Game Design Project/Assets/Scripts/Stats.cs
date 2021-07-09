using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        else if(gameObject.name == "pietre" || gameObject.name == "pietre(Clone)")
        {
            maxHealth = 30;
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }
        else if (gameObject.name == "tronco" || gameObject.name == "tronco(Clone)")
        {
             
            maxHealth = 15;
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }
        else if (gameObject.name == "sabbia" || gameObject.name == "sabbia(Clone)")
        {
            maxHealth = 10;
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }
        else if (gameObject.name == "Barili" || gameObject.name == "Barili(Clone)")
        {
            maxHealth = 15;
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }
        else if (gameObject.name == "Mina" || gameObject.name == "Mina(Clone)")
        {
            maxHealth = 10;
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }
        else if (gameObject.name == "Muro" || gameObject.name == "Muro(Clone)")
        {
            maxHealth = 30;
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Ostruzione") Destroy(gameObject);

            if( gameObject.tag == "Plant_Player")
            {
                //umani vincitrici
                SceneManager.LoadScene("Scena_humanswin");
            }

            if (gameObject.tag == "Human_Player")
            {
                //piante vincitori
                SceneManager.LoadScene("Scena_piantewin");
            }

        }
        if (MasterController.player1.deck.Count == 0 && MasterController.player2.deck.Count == 0)
        {
            //pareggio
            SceneManager.LoadScene("Scena_pareggio");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        animator.SetTrigger("isHurt");
    }
}


