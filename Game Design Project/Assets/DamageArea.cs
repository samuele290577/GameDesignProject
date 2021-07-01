﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public List<GameObject> potentialTargets = new List<GameObject>();
    public GameObject arma;
    void Start()
    {
        Debug.Log("ok trigger area");

        if (arma.tag!= "Human_Weapon")
        {
            GetComponent<DamageArea>().enabled = false;
        }
        else
            GetComponent<DamageArea>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Plant_Player" || other.gameObject.tag == "Plant_ostruzione") 
        potentialTargets.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        potentialTargets.Remove(other.gameObject);
    }
    void Update()
    {
        foreach(var t in potentialTargets)
        {
            Debug.Log("CIAO"+ " " + t.name);
        }
    }
}
