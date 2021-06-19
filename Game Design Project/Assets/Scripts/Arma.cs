using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : Card
{
    
    public int power;
    public int explosion;
    public float throwAngle;

    public Arma(int id, string CardName, int limit, int power, int range, int explosion, float throwAngle)
    {
        this.id = id;
        this.CardName = CardName;
        this.limit = limit;
        this.power = power;
        this.range = range;
        this.explosion = explosion;
        this.throwAngle = throwAngle;
    }
}
