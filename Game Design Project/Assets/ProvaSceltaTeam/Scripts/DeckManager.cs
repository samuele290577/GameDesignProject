using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public Player deck_piante;
    public Player deck_umani;
    
    void Start()
    {
        Debug.Log("grandezza deck piante: " + deck_piante.getDeckSize());
        Debug.Log("grandezza deck umani: " + deck_umani.getDeckSize());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
