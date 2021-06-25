using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;


    void Start()
    {
        //Health set up on start
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(15);
        }    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "mela" || collision.gameObject.name == "mela(Clone)")
        {
            Debug.Log("collisione ok");
            TakeDamage(25);
        }
    }






    //function for damage
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }





}
