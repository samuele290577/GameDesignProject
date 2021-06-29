using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ostruzione : Card
{
    public int vita;
    public int volume;
    public string descrizione;

    public Ostruzione(int id, string name, int range, int limit, int vita, int volume, string descrizione)
    {
        this.id = id;
        this.CardName = name;
        this.range = range;
        this.limit = limit;
        this.vita = vita;
        this.volume = volume;
        this.descrizione = descrizione;
        this.throwAngle = 10f;
    }
}
