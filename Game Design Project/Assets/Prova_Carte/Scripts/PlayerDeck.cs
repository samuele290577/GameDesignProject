using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public double size = 0;
    public Text sizeText;
    public Image image;
    public Button warButton;

    public void AddCard(Card card)
    {
        deck.Add(card);
        Debug.Log("Card Added: " + card.id + " , " + card.CardName);
    }

    public void RemoveCard (Card card)
    {
        if (deck.Contains(card))
        {
            deck.Remove(card);
            Debug.Log("Card Removed: " + card.id + ", " + card.CardName);
        }
    }
    void Start()
    {
        warButton.interactable = false;
    }
    void Update()
    {
        size = deck.Count;
        sizeText.text = "Grandezza Deck: " + size;
        image.fillAmount = (float)(size * 0.1);
        isInteractable(warButton);

    } 
    public void isInteractable (Button button)
    {
        if ((size == 10))
        {
            button.interactable = true; 
        }
        else
        {
            button.interactable = false; 

        }
    }

}
