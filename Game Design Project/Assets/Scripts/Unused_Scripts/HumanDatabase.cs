using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanDatabase: MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Arma(0, "Bomb", 10, 25, 12, 5));
        cardList.Add(new Arma(1, "Dynamite", 2, 15, 18, 25));
        cardList.Add(new Arma(2, "Molotov", 2, 35, 8, 4));
        cardList.Add(new Arma(3, "Rifle", 1, 30, 10, 1));
        cardList.Add(new Arma(4, "Shotgun", 1, 50, 3, 9));
        cardList.Add(new Arma(5, "Knife", 10, 30, 5, 1));
        cardList.Add(new Ostruzione(6, "Barrel", 20, 10, 30, 4, "Blocca gli attacchi dell'avversario se colpita"));
        cardList.Add(new Ostruzione(7, "Explosive Box", 10, 10, 15, 4, "Se colpita, moltiplica di 1.5 il danno d'attacco"));
        cardList.Add(new Ostruzione(8, "Mine", 15, 1, 10, 9, "Se colpisce l'avversario, egli salterà un turno di movimento"));
    }
}
