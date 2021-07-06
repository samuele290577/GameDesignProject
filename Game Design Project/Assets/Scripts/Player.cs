using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    public List<int> deck = new List<int>();
    public string team;
    public int id; 

    private int bananacounter = 0;
    private int pinapplecounter = 0;
    private int coconutcounter = 0;
    private int watermeloncounter = 0;
    private int sabbiacounter = 0;
    private int riflecounter = 0;
    private int shotguncounter = 0;
    private int dynamitecounter = 0;
    private int molotovcounter = 0;
    private int minecounter = 0;

    public bool deckOverload = false;

    public Player (int id)
    {
        this.id = id;
        this.team = "unset";
    }

    
    public void setTeam (string team_scelto){
        team = team_scelto; 
    }

    public string getTeam()
    {
        return team;
    }

    public void setId(int id_scelto)
    {
        id = id_scelto;
    }

    public int getId()
    {
        return id;
    }

    public int getDeckSize()
    {
        return deck.Count;
    }


    public List<int> getCards()
    {
        return deck;
    }


    public void AddCard(int cardId)
    {
        Card card = CardDatabase.getCardFromId(cardId);

        if (team.Equals("Plants"))
        {
            if (card.CardName == "Apple" || card.CardName == "Oranges" || card.CardName == "Roccia" || card.CardName == "Pietre")
            {
                deck.Add(card.getId());
                Debug.Log("Card Added: " + card.id + " , " + card.CardName);
            }

            else
            {
                switch (card.CardName)
                {
                    case ("Banana"):

                        if (bananacounter < card.limit)
                        {
                            deck.Add(card.getId());
                            Debug.Log("Card Added: " + card.id + " , " + card.CardName + " Banana Counter: " + bananacounter);
                            bananacounter++;

                        }
                        else
                        {
                            Debug.Log("Raggiunto il limite di carte di tipo " + card.CardName + " per questo deck");
                            deckOverload = true;
                        }
                        break;
                    case ("Pinapple"):

                        if (pinapplecounter < card.limit)
                        {
                            deck.Add(card.getId());
                            Debug.Log("Card Added: " + card.id + " , " + card.CardName);
                            pinapplecounter++;

                        }
                        else
                        {
                            Debug.Log("Raggiunto il limite di carte di tipo " + card.CardName + " per questo deck");
                            deckOverload = true;
                        }
                        break;
                    case ("Coconut"):

                        if (coconutcounter < card.limit)
                        {
                            deck.Add(card.getId());
                            Debug.Log("Card Added: " + card.id + " , " + card.CardName);
                            coconutcounter++;

                        }
                        else
                        {
                            Debug.Log("Raggiunto il limite di carte di tipo " + card.CardName + " per questo deck");
                            deckOverload = true;
                        }
                        break;
                    case ("Watermelon"):

                        if (watermeloncounter < card.limit)
                        {
                            deck.Add(card.getId());
                            Debug.Log("Card Added: " + card.id + " , " + card.CardName);
                            watermeloncounter++;

                        }
                        else
                        {
                            Debug.Log("Raggiunto il limite di carte di tipo " + card.CardName + " per questo deck");
                            deckOverload = true;
                        }
                        break;
                    case ("Sabbia Mobile"):

                        if (sabbiacounter < card.limit)
                        {
                            deck.Add(card.getId());
                            Debug.Log("Card Added: " + card.id + " , " + card.CardName);
                            sabbiacounter++;

                        }
                        else
                        {
                            Debug.Log("Raggiunto il limite di carte di tipo " + card.CardName + " per questo deck");
                            deckOverload = true;
                        }
                        break;


                }
            }


        }
        else
        {
            if (card.CardName == "Bomb" || card.CardName == "Knife" || card.CardName == "Barrel" || card.CardName == "Explosive Box")
            {
                deck.Add(card.getId());
                Debug.Log("Card Added: " + card.id + " , " + card.CardName);

            }

            else
            {
                switch (card.CardName)
                {
                    case ("Dynamite"):

                        if (dynamitecounter < card.limit)
                        {
                            deck.Add(card.getId());
                            dynamitecounter++;
                            Debug.Log("Card Added: " + card.id + " , " + card.CardName + " Dynamite Counter: " + dynamitecounter);


                        }
                        else
                        {
                            Debug.Log("Raggiunto il limite di carte di tipo " + card.CardName + " per questo deck");
                            deckOverload = true;
                        }
                        break;
                    case ("Molotov"):

                        if (molotovcounter < card.limit)
                        {
                            deck.Add(card.getId());
                            Debug.Log("Card Added: " + card.id + " , " + card.CardName);
                            molotovcounter++;

                        }
                        else
                        {
                            Debug.Log("Raggiunto il limite di carte di tipo " + card.CardName + " per questo deck");
                            deckOverload = true;
                        }
                        break;
                    case ("Rifle"):

                        if (riflecounter < card.limit)
                        {
                            deck.Add(card.getId());
                            Debug.Log("Card Added: " + card.id + " , " + card.CardName);
                            riflecounter++;

                        }
                        else
                        {
                            Debug.Log("Raggiunto il limite di carte di tipo " + card.CardName + " per questo deck");
                            deckOverload = true;
                        }
                        break;
                    case ("Shotgun"):

                        if (shotguncounter < card.limit)
                        {
                            deck.Add(card.getId());
                            Debug.Log("Card Added: " + card.id + " , " + card.CardName);
                            shotguncounter++;

                        }
                        else
                        {
                            Debug.Log("Raggiunto il limite di carte di tipo " + card.CardName + " per questo deck");
                            deckOverload = true;
                        }
                        break;
                    case ("Mine"):

                        if (minecounter < card.limit)
                        {
                            deck.Add(card.getId());
                            Debug.Log("Card Added: " + card.id + " , " + card.CardName);
                            minecounter++;

                        }
                        else
                        {
                            Debug.Log("Raggiunto il limite di carte di tipo " + card.CardName + " per questo deck");
                            deckOverload = true;
                        }
                        break;


                }
            }
        }
    }


    public void RemoveCard(int cardId)
    {
        Card card = CardDatabase.getCardFromId(cardId);
        if (team.Equals("Plants"))
        {
            if (deck.Contains(card.getId()))
            {
                if (card.CardName == "Apple" || card.CardName == "Oranges" || card.CardName == "Roccia" || card.CardName == "Pietre")
                {
                    deck.Remove(card.getId());
                    Debug.Log("Card Removed: " + card.id + ", " + card.CardName);
                }
                else
                {
                    switch (card.CardName)
                    {
                        case ("Banana"):
                            deck.Remove(card.getId());
                            bananacounter--;
                            Debug.Log("Card Removed: " + card.id + ", " + card.CardName);
                            break;

                        case ("Pinapple"):
                            deck.Remove(card.getId());
                            pinapplecounter--;
                            Debug.Log("Card Removed: " + card.id + ", " + card.CardName);

                            break;
                        case ("Coconut"):
                            deck.Remove(card.getId());
                            Debug.Log("Card Removed: " + card.id + ", " + card.CardName);

                            break;
                        case ("Watermelon"):
                            deck.Remove(card.getId());
                            watermeloncounter--;
                            Debug.Log("Card Removed: " + card.id + ", " + card.CardName);

                            break;
                        case ("Sabbia Mobile"):
                            deck.Remove(card.getId());
                            sabbiacounter--;
                            Debug.Log("Card Removed: " + card.id + ", " + card.CardName);

                            break;


                    }
                }
            }
        }
        else if (team.Equals("Humans"))
        {
            Debug.Log("Dentro Remove HUmans");
            if (deck.Contains(card.getId()))
            {
                Debug.Log("Armi Umane remove");
                if (card.CardName == "Bomb" || card.CardName == "Knife" || card.CardName == "Barrel" || card.CardName == "Explosive Box")
                {
                    deck.Remove(card.getId());
                    Debug.Log("Card Removed: " + card.id + ", " + card.CardName);
                }
                else
                {
                    switch (card.CardName)
                    {
                        case ("Dynamite"):
                            deck.Remove(card.getId());
                            dynamitecounter--;
                            Debug.Log("Card Removed: " + card.id + ", " + card.CardName);
                            break;

                        case ("Molotov"):
                            deck.Remove(card.getId());
                            molotovcounter--;
                            Debug.Log("Card Removed: " + card.id + ", " + card.CardName);

                            break;
                        case ("Rifle"):
                            deck.Remove(card.getId());
                            riflecounter--;
                            Debug.Log("Card Removed: " + card.id + ", " + card.CardName);

                            break;
                        case ("Shotgun"):
                            deck.Remove(card.getId());
                            shotguncounter--;
                            Debug.Log("Card Removed: " + card.id + ", " + card.CardName);

                            break;
                        case ("Mine"):
                            deck.Remove(card.getId());
                            minecounter--;
                            Debug.Log("Card Removed: " + card.id + ", " + card.CardName);

                            break;


                    }
                }
            }
        }
    }
}