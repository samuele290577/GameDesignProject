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
        Debug.Log( gameObject.name +  "Debug Lancio : Collisione con " + collision.gameObject.name);
   
        if (collision.gameObject.name == "Checkerboard" ||
            collision.collider.name == "Plant_Player" ||
            collision.collider.tag == "Obstacle" ||
            collision.collider.name == "Human_Player"
            )

            foreach (var t in targets)
            {
                Debug.Log(gameObject + "Debug lancio:" + t);
            }
        
        {
            

            //ARMI UMANO

            if (this.name == "Bomba" || this.name =="Bomba(Clone)")
            {
                Debug.Log("la bomba!");
                if (checkObstructionPower("Humans")) TakeDamage((int)(25 * 1.5));
                else TakeDamage(25);
                }
            else if (this.name == "Dinamite" || this.name == "Dinamite(Clone)")
            {
                Debug.Log("la dinamite!");
                if (checkObstructionPower("Humans")) TakeDamage((int)(15 * 1.5));
                else TakeDamage(15);
            }
            else if (this.name == "Molotov" || this.name == "Molotov(Clone)")
            {
                Debug.Log("la molotov!");
                if (checkObstructionPower("Humans")) TakeDamage((int)(35 * 1.5));
                else TakeDamage(35);
            }
            else if (this.name == "projectile" || this.name == "projectile(Clone)")
            {
                if (checkObstructionPower("Humans")) TakeDamage((int)(20 * 1.5));
                else TakeDamage(20);
            }
  
            else if (this.name == "Pugnale" || this.name == "Pugnale(Clone)")
            {
                Debug.Log("il pugnale!");
                if (checkObstructionPower("Humans")) TakeDamage((int)(30 * 1.5));
                else TakeDamage(30);
            }

            //ARMI PIANTE

            else if(this.name =="mela" || this.name == "mela(Clone)")
            {
                Debug.Log("mela");
                if (checkObstructionPower("Plants")) TakeDamage((int)(25 * 1.5));
                else TakeDamage(25);
            }
            else if (this.name == "banane" || this.name == "banane(Clone)")
            {
                Debug.Log("banana");
                if (checkObstructionPower("Plants")) TakeDamage((int)(15 * 1.5));
                else TakeDamage(15);
            }
            else if (this.name == "ananas" || this.name == "ananas(Clone)")
            {
                Debug.Log("ananas");
                if (checkObstructionPower("Plants")) TakeDamage((int)(35 * 1.5));
                else TakeDamage(35);
            }
            else if (this.name == "cocco" || this.name == "cocco(Clone)")
            {
                Debug.Log("cocco");
                if (checkObstructionPower("Plants")) TakeDamage((int)(25 * 1.5));
                else TakeDamage(25);
            }
            else if (this.name == "anguria" || this.name == "anguria(Clone)")
            {
                Debug.Log("anguria");
                if (checkObstructionPower("Plants")) TakeDamage((int)(20 * 1.5));
                else TakeDamage(20);
            }
            else if (this.name == "arancia" || this.name == "arancia(Clone)")
            {
                Debug.Log("arancia");
                if (checkObstructionPower("Plants")) TakeDamage((int)(30 * 1.5));
                else TakeDamage(30);
            }


            Destroy(gameObject);

        }
        
    }

    void TakeDamage(int damage)
    {
        Debug.Log("Danno inflitto: " + damage);
        foreach(var t in targets)
        {
            //diventerà stats
            t.GetComponent<Stats>().currentHealth -= damage;
            int newCurrentHealth = t.GetComponent<Stats>().currentHealth;
            t.GetComponent<Stats>().healthBar.SetHealth(newCurrentHealth);
        }
    }

    bool checkObstructionPower(string team)
    {
        if (team == "Plants")
        {
            var ostruzioni = FindObjectsOfType<PhysicalOstruzione>();
            foreach (var el in ostruzioni)
            {
                if (el.id == 7)
                {
                    if (Vector3.Distance(transform.position, el.gameObject.transform.position) < 5 ) return true;
                }
            }
                
        }
        else if (team == "Humans")
        {
            var ostruzioni = FindObjectsOfType<PhysicalOstruzione>();
            foreach (var el in ostruzioni)
            {
                if (el.id == 17)
                {
                    if (Vector3.Distance(transform.position, el.gameObject.transform.position) < 5) return true;
                }
            }

        }
        return false;
    }

}
