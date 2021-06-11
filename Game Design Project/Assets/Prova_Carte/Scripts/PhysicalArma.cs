using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PhysicalArma : MonoBehaviour
{
    public int cardId;

    private Arma thisCard;

    public Text nameText;
    public Text PowerText;
    public Text RangeText;
    public Text LimitText;
    public Text explosionText;

    void Start()
    {
        //prendo la carta dal database in base all'id
        thisCard = (Arma) CardDatabase.getCardFromId(cardId);

        //scrivo i dati nell'interfaccia
        nameText.text = "" + thisCard.CardName;
        RangeText.text = "" + thisCard.range;
        LimitText.text = "" + thisCard.limit;
        PowerText.text = "" + thisCard.power;
        explosionText.text = "" + thisCard.explosion;
    }
}