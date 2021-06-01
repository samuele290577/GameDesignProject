using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public PlayerDeck deck; 
    void Start()
    {
        Debug.Log("grandezza deck: " + deck.getSize());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
