using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalOstruzione : MonoBehaviour
{

    public int id;
    Logic_Earth logicEarth;

    // Start is called before the first frame update
    void Start()
    {
        logicEarth = FindObjectOfType<Logic_Earth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Humans_Player")
        {
            if (id == 8) //Sabbia mobile
            {
                logicEarth.ChangeTurn();
            }
        }
        if (other.gameObject.tag == "Plants_Player")
        {
            if (id == 18) //Mina
            {
                logicEarth.ChangeTurn();
            }
        }
    }
}
