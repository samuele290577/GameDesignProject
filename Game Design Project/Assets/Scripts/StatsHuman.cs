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
        //Health set up on start
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    private void Update()
    {
        if(currentHealth <= 0)
        {
            Debug.Log("Game over le piante hanno vinto");
            //qui cambio scena storia vittoria umani (???) 
        }






        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(15);
        }    
    }
    private void OnCollisionEnter(Collision collision)
    {
        animator.SetTrigger("isHurt");
        //apple 
        if(collision.gameObject.name == "mela" || collision.gameObject.name == "mela(Clone)")
        {
            Debug.Log("apple collision detected");
            TakeDamage(25);
        }
        //banana
        else if (collision.gameObject.name == "banane" || collision.gameObject.name == "banane(Clone)")
        {
            Debug.Log("banana collision detected");
            TakeDamage(15);
        }
        //pineapple
        else if (collision.gameObject.name == "ananas" || collision.gameObject.name == "ananas(Clone)")
        {
            Debug.Log("ananas collision detected");
            TakeDamage(35);
        }
        //coconut
        else if (collision.gameObject.name == "cocco" || collision.gameObject.name == "cocco(Clone)")
        {
            Debug.Log("coconut collision detected");
            TakeDamage(20);
        }
        //watermelon
        else if (collision.gameObject.name == "anguria" || collision.gameObject.name == "anguria(Clone)")
        {
            Debug.Log("watermelon collision detected");
            TakeDamage(20);
        }
        //arancia
        else if(collision.gameObject.name == "arancia" || collision.gameObject.name == "arancia(Clone)")
        {
            Debug.Log("orange collision detected");
            TakeDamage(30);
        }
    }
    //function for damage
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
