using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase
{ 
    public static Dictionary<int,Card> cardDatabase = new Dictionary<int,Card>();

    public static void Populate()
    {
        //PIANTE
        cardDatabase.Add(0, new Arma(0, "Apple", 10, 25, 12, 5, 45f));
        cardDatabase.Add(1, new Arma(1, "Banana", 2, 15, 18, 25, 45f));
        cardDatabase.Add(2, new Arma(2, "Pinapple", 2, 35, 8, 4, 45f));
        cardDatabase.Add(3, new Arma(3, "Coconut", 1, 20, 20, 9, 45f));
        cardDatabase.Add(4, new Arma(4, "Watermelon", 1, 20, 18, 4, 45f));
        cardDatabase.Add(5, new Arma(5, "Oranges", 10, 30, 5, 1, 45f));
        cardDatabase.Add(6, new Ostruzione(6, "Rocks", 20, 10, 30, 4, "If hit, it blocks the opponent's attacks"));
        cardDatabase.Add(7, new Ostruzione(7, "Trunk", 10, 10, 15, 4, "If hit, multiplies attack damage by 1.5"));
        cardDatabase.Add(8, new Ostruzione(8, "Quicksand", 15, 1, 10, 9, "If it hits the opponent, he will miss the movement's turn"));

        //UMANI
        cardDatabase.Add(10, new Arma(10, "Bomb", 10, 25, 12, 5, 45f));
        cardDatabase.Add(11, new Arma(11, "Dynamite", 2, 15, 18, 25, 45f));
        cardDatabase.Add(12, new Arma(12, "Molotov", 2, 35, 8, 4, 45f));
        cardDatabase.Add(13, new Arma(13, "Rifle", 1, 30, 10, 1, 45f));
        cardDatabase.Add(14, new Arma(14, "Shotgun", 1, 50, 3, 9, 45f));
        cardDatabase.Add(15, new Arma(15, "Knife", 10, 30, 5, 1, 10f));
        cardDatabase.Add(16, new Ostruzione(16, "Wall", 20, 10, 30, 4, "If hit, it blocks the opponent's attacks"));
        cardDatabase.Add(17, new Ostruzione(17, "Barrels", 10, 10, 15, 4, "If hit, multiplies attack damage by 1.5"));
        cardDatabase.Add(18, new Ostruzione(18, "Mine", 15, 1, 10, 9, "If it hits the opponent, he will miss the movement's turn"));
    }
    public static Card getCardFromId(int id)
    {
        return cardDatabase[id];
    }
    
}
