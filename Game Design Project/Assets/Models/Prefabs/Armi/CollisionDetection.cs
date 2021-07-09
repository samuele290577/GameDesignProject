using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    //Lista di oggetti a cui faremo il danno quando andremo a collidere con qualcosa che ci distrugge l'arma
    public GameObject DamageArea;
    public GameObject arma;
    public List<GameObject> targets = new List<GameObject>();
    public GameObject earthLogic;
    public GameObject currentPlayer;
    public GameObject giocatore_pianta;
    public GameObject giocatore_umano;
    public Animator animator_pianta;
    public Animator animator_umano;


    //damage text prova
    public GameObject damageText;
  
  
    void Start()
    {
        Debug.Log("ok trigger area");

        if (arma.tag != "Human_Weapon" && arma.tag != "Plant_Weapon")
        {
            GetComponent<CollisionDetection>().enabled = false;
        }
        else
            GetComponent<CollisionDetection>().enabled = true;
        giocatore_pianta = GameObject.Find("Plant_Player");
        giocatore_umano = GameObject.Find("Human_Player");
        animator_pianta = giocatore_pianta.GetComponent<Animator>();
        animator_umano = giocatore_umano.GetComponent<Animator>();

    }

    private void Update()
    {
        earthLogic = GameObject.Find("GameLogic");
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

                if (this.name == "Bomba" || this.name == "Bomba(Clone)")
            {
                foreach (var t in targets)
                {
                    if (t.name != "Human_Player" || t.name != "Barili(Clone)" || t.name != "Mina(Clone)" || t.name != "Muro(Clone)")
                    {
                        Debug.Log("bomba");
                        if (checkObstructionPower("Humans")) TakeDamage(t, (int)(25 * 1.5));
                        else TakeDamage(t, 25);
                        animator_pianta.SetTrigger("isHurt");
                    }
                    
                }
            }

            else if (this.name == "Dinamite" || this.name == "Dinamite(Clone)")
            {
                foreach (var t in targets)
                {
                    if (t.name != "Human_Player" || t.name != "Barili(Clone)" || t.name != "Mina(Clone)" || t.name != "Muro(Clone)" )
                    {
                        Debug.Log("dinamite");
                        if (checkObstructionPower("Humans")) TakeDamage(t, (int)(15 * 1.5));
                        else TakeDamage(t, 15);
                        animator_pianta.SetTrigger("isHurt");
                    }
                    
                }
            }
            else if (this.name == "Molotov" || this.name == "Molotov(Clone)")
            {
                foreach (var t in targets)
                {
                    if (t.name != "Human_Player" || t.name != "Barili(Clone)" || t.name != "Mina(Clone)" || t.name != "Muro(Clone)")
                    {
                        Debug.Log("molotov");
                        if (checkObstructionPower("Humans")) TakeDamage(t, (int)(35 * 1.5));
                        else TakeDamage(t, 35);
                        animator_pianta.SetTrigger("isHurt");
                    }
                    
                }

            }
            else if (this.name == "projectile" || this.name == "projectile(Clone)")
            {
                currentPlayer = earthLogic.GetComponent<Logic_Earth>().currentPlayer;
                currentPlayer.GetComponent<BoxCollider>().enabled = false;
                 
                foreach (var t in targets)
                {
                    if (t.name != "Human_Player" || t.name != "Barili(Clone)" || t.name != "Mina(Clone)" || t.name != "Muro(Clone)")
                    {
                        Debug.Log("projectile");
                        if (checkObstructionPower("Humans")) TakeDamage(t, (int)(20 * 1.5));
                        else TakeDamage(t, 20);
                        animator_pianta.SetTrigger("isHurt");
                    }
                    
                }
                currentPlayer.GetComponent<BoxCollider>().enabled = true;
            }

            else if (this.name == "Pugnale" || this.name == "Pugnale(Clone)")
            {
                foreach (var t in targets)
                {
                    if (t.name != "Human_Player" || t.name != "Barili(Clone)" || t.name != "Mina(Clone)" || t.name != "Muro(Clone)")
                    {
                        Debug.Log("pugnale");
                        if (checkObstructionPower("Humans")) TakeDamage(t, (int)(30 * 1.5));
                        else TakeDamage(t, 30);
                        animator_pianta.SetTrigger("isHurt");
                    }
                    
                }
            }

            //ARMI PIANTE

            else if (this.name == "mela" || this.name == "mela(Clone)")
            {
                foreach (var t in targets)
                {
                    if (t.name != "Plant_Player" || t.name != "tronco(Clone)" || t.name != "sabbia(Clone)" || t.name != "pietre(Clone)")
                    {
                        Debug.Log("mela");
                        if (checkObstructionPower("Plants")) TakeDamage(t, (int)(25 * 1.5));
                        else TakeDamage(t, 25);
                        animator_umano.SetTrigger("isHurt");
                    }
                    
                }

            }
            else if (this.name == "banane" || this.name == "banane(Clone)")
            {
                foreach (var t in targets)
                {
                    if (t.name != "Plant_Player" || t.name != "tronco(Clone)" || t.name != "sabbia(Clone)" || t.name != "pietre(Clone)")
                    {
                        Debug.Log("banane");
                        if (checkObstructionPower("Plants")) TakeDamage(t, (int)(15 * 1.5));
                        else TakeDamage(t, 15);
                        animator_umano.SetTrigger("isHurt");
                    }
                    
                }
            }

            else if (this.name == "ananas" || this.name == "ananas(Clone)")
            {
                foreach (var t in targets)
                {
                    if (t.name != "Plant_Player" || t.name != "tronco(Clone)" || t.name != "sabbia(Clone)" || t.name != "pietre(Clone)")
                    {
                        Debug.Log("ananas");
                        if (checkObstructionPower("Plants")) TakeDamage(t, (int)(35 * 1.5));
                        else TakeDamage(t, 35);
                        animator_umano.SetTrigger("isHurt");
                    }
                    
                }
            }

            else if (this.name == "cocco" || this.name == "cocco(Clone)")
            {
                foreach (var t in targets)
                {
                    if(t.name != "Plant_Player" || t.name != "tronco(Clone)" || t.name != "sabbia(Clone)" || t.name != "pietre(Clone)")
                    {
                        Debug.Log("cocco");
                        if (checkObstructionPower("Plants")) TakeDamage(t, (int)(25 * 1.5));
                        else TakeDamage(t, 25);
                        animator_umano.SetTrigger("isHurt");
                    }
                    
                }

       
            }
            else if (this.name == "anguria" || this.name == "anguria(Clone)")
            {
                foreach (var t in targets)
                {
                    if (t.name != "Plant_Player" || t.name != "tronco(Clone)" || t.name != "sabbia(Clone)" || t.name != "pietre(Clone)")
                    {
                        Debug.Log("anguria");
                        if (checkObstructionPower("Plants")) TakeDamage(t, (int)(20 * 1.5));
                        else TakeDamage(t, 20);
                        animator_umano.SetTrigger("isHurt");
                    }
                    
                }
            }
            else if (this.name == "arancia" || this.name == "arancia(Clone)")
            {
                foreach (var t in targets)
                {
                    if (t.name != "Plant_Player" || t.name != "tronco(Clone)" || t.name != "sabbia(Clone)" || t.name != "pietre(Clone)")
                    {
                        Debug.Log("arancia");
                        if (checkObstructionPower("Plants")) TakeDamage(t, (int)(30 * 1.5));
                        else TakeDamage(t, 30);
                        animator_umano.SetTrigger("isHurt");
                    }

                }
            }
               Destroy(gameObject);

            }
        
        
    }

    void TakeDamage(GameObject t, int damage)
    { 
            t.GetComponent<Stats>().currentHealth -= damage;
            int newCurrentHealth = t.GetComponent<Stats>().currentHealth;
            t.GetComponent<Stats>().healthBar.SetHealth(newCurrentHealth);

        //damage text prova

        DamageIndicator indicator = Instantiate(damageText, transform.position, Quaternion.identity).GetComponent<DamageIndicator>();
        indicator.SetDamageText(damage);

        


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
