using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    //Lista di oggetti a cui faremo il danno quando andremo a collidere con qualcosa che ci distrugge l'arma
    public GameObject DamageArea;
    public GameObject arma;
    public List<GameObject> targets = new List<GameObject>();
  
  
    void Start()
    {
        Debug.Log("ok trigger area");

        if (arma.tag != "Human_Weapon" && arma.tag != "Plant_Weapon")
        {
            GetComponent<CollisionDetection>().enabled = false;
        }
        else
            GetComponent<CollisionDetection>().enabled = true;
    }

    private void Update()
    {
        targets = DamageArea.GetComponent<DamageArea>().potentialTargets;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Checkerboard" ||
            collision.gameObject.name == "Plant_Player" ||
            collision.gameObject.tag == "Obstacle" ||
            collision.gameObject.name == "Human_Player"
            ) {
            Debug.Log("Collisione con " + collision.gameObject);

            //ARMI UMANO

            if (this.name == "Bomba" || this.name =="Bomba(Clone)")
        {
            Debug.Log("la bomba!");
            TakeDamage(25);
        }
        else if (this.name == "Dinamite" || this.name == "Dinamite(Clone)")
        {
            Debug.Log("la dinamite!");
            TakeDamage(15);
        }
        else if (this.name == "Molotov" || this.name == "Molotov(Clone)")
        {
            Debug.Log("la molotov!");
            TakeDamage(35);
        }
        else if (this.name == "projectile" || this.name == "projectile(Clone)")
        {
            Debug.Log("fucile a pompa o lancia razzi");
            TakeDamage(20);
        }
  
        else if (this.name == "Pugnale" || this.name == "Pugnale(Clone)")
        {
            Debug.Log("il pugnale!");
            TakeDamage(30);
        }

        //ARMI PIANTE

        else if(this.name =="mela" || this.name == "mela(Clone)")
            {
                Debug.Log("mela");
                TakeDamage(25);
            }
            else if (this.name == "banana" || this.name == "banana(Clone)")
            {
                Debug.Log("banana");
                TakeDamage(15);
            }
            else if (this.name == "ananas" || this.name == "ananas(Clone)")
            {
                Debug.Log("ananas");
                TakeDamage(35);
            }
            else if (this.name == "cocco" || this.name == "cocco(Clone)")
            {
                Debug.Log("cocco");
                TakeDamage(25);
            }
            else if (this.name == "anguria" || this.name == "anguria(Clone)")
            {
                Debug.Log("anguria");  
                TakeDamage(20);
            }
            else if (this.name == "arancia" || this.name == "arancia(Clone)")
            {
                Debug.Log("arancia");
                TakeDamage(30);
            }


            Destroy(gameObject);

        }
        
    }

    void TakeDamage(int damage)
    {
        foreach(var t in targets)
        {
            //diventerà stats
            t.GetComponent<Stats>().currentHealth -= damage;
            int newCurrentHealth = t.GetComponent<Stats>().currentHealth;
            t.GetComponent<Stats>().healthBar.SetHealth(newCurrentHealth);
        }
    }



}
