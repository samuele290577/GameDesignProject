using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "Apple", 10, 25, 12, 5));
        cardList.Add(new Card(1, "Banana", 2, 15, 18, 25));
        cardList.Add(new Card(2, "Pinapple", 2, 35, 8, 4));
        cardList.Add(new Card(3, "Coconut", 1, 20, 20, 9));
        cardList.Add(new Card(4, "Watermelon", 1, 20, 18, 4));
        cardList.Add(new Card(5, "Oranges", 10, 30, 5, 1));
    }
}
