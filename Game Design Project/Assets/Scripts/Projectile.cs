using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public string team;

    // Start is called before the first frame update
    private void Start()
    {
        GameObject playerToIgnore;
        if (team == "Plants") playerToIgnore = GameObject.FindGameObjectWithTag("Plant_Player");
        else playerToIgnore = GameObject.FindGameObjectWithTag("Human_Player");
        Physics.IgnoreCollision(playerToIgnore.GetComponent<BoxCollider>(), this.GetComponent<CapsuleCollider>());
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
