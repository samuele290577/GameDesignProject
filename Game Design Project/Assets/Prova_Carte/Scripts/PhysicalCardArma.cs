using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PhysicalCardArma : MonoBehaviour
{
    public int cardId;

    private Arma thisCard;

    public Text nameText;
    public Text PowerText;
    public Text RangeText;
    public Text LimitText;
    public Text explosionText;
    public Text Counter;
    private int counter = 0;

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
        Counter.text = "" + counter;
    }
    private void Update()
    {
        countCardId();
        Counter.text = "" + counter;
       
    }
    public void countCardId()
    {
        if (MasterController.player1.deck.Contains(cardId))
        {
            counter = 0;
            for (int i = 0; i < MasterController.player1.getDeckSize(); i++)
            {
                if (MasterController.player1.deck[i] == cardId)
                {
                    counter++;
                }
            }
        }
        else
        {
            counter = 0;
            for (int i = 0; i < MasterController.player2.getDeckSize(); i++)
            {
                if (MasterController.player2.deck[i] == cardId)
                {
                    counter++;
                }
            }
        }
    }
}