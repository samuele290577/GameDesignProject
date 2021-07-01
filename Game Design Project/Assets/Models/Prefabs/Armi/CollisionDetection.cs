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

        if (arma.tag != "Human_Weapon")
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
        Debug.Log("Collisione con " + collision.gameObject);

        if (collision.gameObject.name == "terrain" ||
            collision.gameObject.name == "Plant_Player" ||
            collision.gameObject.tag == "Obstacle"
            ) {

        if(this.name == "Bomba" || this.name =="Bomba(Clone)")
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
            Debug.Log("la dinamite!");
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
        }
        Destroy(gameObject);
    }

    void TakeDamage(int damage)
    {
        foreach(var t in targets)
        {
            //diventerà stats
            t.GetComponent<StatsPlant>().currentHealth -= damage;
            int newCurrentHealth = t.GetComponent<StatsPlant>().currentHealth;
            t.GetComponent<StatsPlant>().healthBar.SetHealth(newCurrentHealth);
        }
    }



}
