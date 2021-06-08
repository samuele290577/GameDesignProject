using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    // static public Team team;
    public bool isReady;
    public string team;
    public int id; 
    private int bananacounter = 0;
    private int pinapplecounter = 0;
    private int coconutcounter = 0;
    private int watermeloncounter = 0;
    private int sabbiacounter = 0;
    public bool overload = false;


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
                        overload = true;
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
                        overload = true;
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
                        overload = true;
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
                        overload = true;
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
                        overload = true;
                    }
                    break;


            }
        }


    }
    public void setTeam (string team_scelto){
        team = team_scelto; 
    }
    public string getTeam()
    {
        return team;
    }
    public int getSize()
    {
        return deck.Count;
    }

    public void setId(int id_scelto)
    {
        id = id_scelto;
    }
    public int getId()
    {
        return id;
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
    
    

}