using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();

    void Start()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collisione con " + collision.gameObject.name + "piantona");
        Destroy(gameObject);
    }
}
