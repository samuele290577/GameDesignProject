using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{

    public List<GameObject> potentialTargets = new List<GameObject>();
    public GameObject arma;
   
    void Start()
    {
        Debug.Log(gameObject.tag + "tag");
        //Debug.Log("ok trigger area");

        /** if (arma.tag!= "Human_Weapon" || arma.tag!= "Plant_Weapon")
         {
             GetComponent<DamageArea>().enabled = false;
         }
         else
             GetComponent<DamageArea>().enabled = true;
      **/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (arma.tag == "Plant_Weapon")
        {
            if (other.gameObject.name == "Barili(Clone)" || other.gameObject.name == "Human_Player" || other.gameObject.name == "Mina(Clone)" || other.gameObject.name == "Muro(Clone)")
            {
                potentialTargets.Add(other.gameObject);
            }
            else Debug.Log("no");
        }
        else if (arma.tag == "Human_Weapon")
                {
            if(other.gameObject.name == "Plant_Player" || other.gameObject.name == "pietre(Clone)" || other.gameObject.name == "sabbia(Clone)" || other.gameObject.name == "tronco(Clone)")
            {
                potentialTargets.Add(other.gameObject);
            }
            else Debug.Log("no");
        }
        else
        {
            Debug.Log("ok");
        }

        //TO DO o tag oppure tag su stats per smistare piante / umani
        
       //QUA MA COME ?????
        
    }

    private void OnTriggerExit(Collider other)
    {
        //rimozione se fuori da trigger area
        potentialTargets.Remove(other.gameObject);
    }
    void Update()
    {
        foreach(var t in potentialTargets)
        {
         Debug.Log("potential targets di " + gameObject.name + " sono "  + t);
        }
    }   
}
