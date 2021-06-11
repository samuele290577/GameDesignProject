using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public int id;
    public string CardName;
    public int limit;
    public int range;

    public string getName()
    {
        return CardName;
    }
    
    public int getId()
    {
        return id;
    }
}
