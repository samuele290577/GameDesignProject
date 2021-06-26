using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPlant : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    public HealthBar healthBar;
    //public Animator animator;

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
            TakeDamagePlant(15);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //animator.SetTrigger("isHurt");

        //bomba 
        if (collision.gameObject.name == "Bomba" || collision.gameObject.name == "Bomba(Clone)")
        {
            Debug.Log("bomba collision detected");
            TakeDamagePlant(25);
        }
        //dinamite
        else if (collision.gameObject.name == "dinamite" || collision.gameObject.name == "dinamite(Clone)")
        {
            Debug.Log("banana collision detected");
            TakeDamagePlant(50);
        }
        //molotov
        else if (collision.gameObject.name == "molotov" || collision.gameObject.name == "molotov(Clone)")
        {
            Debug.Log("ananas collision detected");
            TakeDamagePlant(25);
        }
        //fucile a pompa
        else if (collision.gameObject.name == "fucile a pompa" || collision.gameObject.name == "fucile a pompa(Clone)")
        {
            Debug.Log("coconut collision detected");
            TakeDamagePlant(25);
        }
        //lanciarazzi
        else if (collision.gameObject.name == "lancirazzi" || collision.gameObject.name == "lanciarazzi(Clone)")
        {
            Debug.Log("watermelon collision detected");
            TakeDamagePlant(25);
        }
        //pugnale
        else if (collision.gameObject.name == "pugnale" || collision.gameObject.name == "pugnale(Clone)")
        {
            Debug.Log("orange collision detected");
            TakeDamagePlant(25);
        }
    }
    //function for damage
    void TakeDamagePlant(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}


