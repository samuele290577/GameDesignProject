using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();

    public void AddCard(Card card)
    {
        deck.Add(card);
        Debug.Log("Card Added: " + card.id + " , " + card.CardName);
    }

}
