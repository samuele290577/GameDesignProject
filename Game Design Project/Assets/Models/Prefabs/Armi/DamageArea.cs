using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{

    public List<GameObject> potentialTargets = new List<GameObject>();
    public GameObject arma;
    void Start()
    {
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
        //TO DO o tag oppure tag su stats per smistare piante / umani
        if(other.gameObject.name == "Plant_Player" || other.gameObject.tag == "Ostruzione" || other.gameObject.name == "Human_Player") 
        potentialTargets.Add(other.gameObject);
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
            //Debug.Log(gameObject.name + "Debug Lancio: potential targets  " + t);
        }
    }   
}
