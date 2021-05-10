﻿using System.Collections;
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
    public int bananacounter = 0;
    public int pinapplecounter = 0;
    public int coconutcounter = 0;
    public int watermeloncounter = 0;
    public int sabbiacounter = 0;


    public void AddCard(Card card)
    {
        if (card.CardName == "Apple" || card.CardName == "Oranges" || card.CardName == "Roccia" || card.CardName == "Pietre")
        {
            deck.Add(card);
            Debug.Log("Card Added: " + card.id + " , " + card.CardName);

        }

        else
        {
            switch (card.CardName)
            {
                case ("Banana"):
                   
                    if (bananacounter < card.limit)
                    {
                        deck.Add(card);
                        Debug.Log("Card Added: " + card.id + " , " + card.CardName + " Banana Counter: " + bananacounter);
                        bananacounter++;

                    }
                    else
                    {
                        Debug.Log("Raggiunto il limite di carte di tipo " + card.CardName + " per questo deck");
                    }
                    break;
                case ("Pinapple"):
                    
                    if (pinapplecounter < card.limit)
                    {
                        deck.Add(card);
                        Debug.Log("Card Added: " + card.id + " , " + card.CardName);
                        pinapplecounter++;

                    }
                    else
                    {
                        Debug.Log("Raggiunto il limite di carte di tipo " + card.CardName + " per questo deck");
                    }
                    break;
                case ("Coconut"):
                    
                    if (coconutcounter < card.limit)
                    {
                        deck.Add(card);
                        Debug.Log("Card Added: " + card.id + " , " + card.CardName);
                        coconutcounter++;

                    }
                    else
                    {
                        Debug.Log("Raggiunto il limite di carte di tipo " + card.CardName + " per questo deck");
                    }
                    break;
                case ("Watermelon"):
                    
                    if (watermeloncounter < card.limit)
                    {
                        deck.Add(card);
                        Debug.Log("Card Added: " + card.id + " , " + card.CardName);
                        watermeloncounter++;

                    }
                    else
                    {
                        Debug.Log("Raggiunto il limite di carte di tipo " + card.CardName + " per questo deck");
                    }
                    break;
                case ("Sabbia Mobile"):
                    
                    if (sabbiacounter < card.limit)
                    {
                        deck.Add(card);
                        Debug.Log("Card Added: " + card.id + " , " + card.CardName);
                        sabbiacounter++;

                    }
                    else
                    {
                        Debug.Log("Raggiunto il limite di carte di tipo " + card.CardName + " per questo deck");
                    }
                    break;


            }
        }


    }

    public void RemoveCard(Card card)
    {

        if (deck.Contains(card))
        {
            if (card.CardName == "Apple" || card.CardName == "Oranges" || card.CardName == "Roccia" || card.CardName == "Pietre")
            {
                deck.Remove(card);
                Debug.Log("Card Removed: " + card.id + ", " + card.CardName);
            }
            else
            {
                switch (card.CardName)
                {
                    case ("Banana"):
                        deck.Remove(card);
                        bananacounter--;
                        Debug.Log("Card Removed: " + card.id + ", " + card.CardName);
                        break;
                       
                    case ("Pinapple"):
                        deck.Remove(card);
                        pinapplecounter--;
                        Debug.Log("Card Removed: " + card.id + ", " + card.CardName);

                        break;
                    case ("Coconut"):
                        deck.Remove(card);
                        Debug.Log("Card Removed: " + card.id + ", " + card.CardName);

                        break;
                    case ("Watermelon"):
                        deck.Remove(card);
                        watermeloncounter--;
                        Debug.Log("Card Removed: " + card.id + ", " + card.CardName);

                        break;
                    case ("Sabbia Mobile"):
                        deck.Remove(card);
                        sabbiacounter--;
                        Debug.Log("Card Removed: " + card.id + ", " + card.CardName);

                        break;


                }
            }
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
    public void isInteractable(Button button)
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