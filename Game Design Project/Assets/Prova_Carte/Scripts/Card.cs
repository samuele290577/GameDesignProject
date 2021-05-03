using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int id;
    public string CardName;
    public int limit;
    public int range;
    public int power;
    public int explosion; 

    public Card(int id, string CardName, int limit, int power, int range, int explosion)
    {
        this.id = id;
        this.CardName = CardName;
        this.limit = limit;
        this.power = power;
        this.range = range;
        this.explosion = explosion;

    }
}
