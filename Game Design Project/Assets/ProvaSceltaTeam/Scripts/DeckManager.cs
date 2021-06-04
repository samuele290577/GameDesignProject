using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public PlayerDeck deck_piante;
    public PlayerDeck deck_umani;
    
    void Start()
    {
        Debug.Log("grandezza deck piante: " + deck_piante.getSize());
        Debug.Log("grandezza deck umani: " + deck_umani.getSize());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
