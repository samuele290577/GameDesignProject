using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PhysicalCardOstruzione : MonoBehaviour
{
    public int cardId;

    private Ostruzione thisCard;
    public DeckBuilder deckBuilder;


    public Text nameText;
    public Text VolumeText;
    public Text RangeText;
    public Text LifeText;
    public Text LimitText;
    public Text DescrizioneText;
    public Text Counter;
    private int counter = 0;

    void Start()
    {
        //prendo la carta dal database in base all'id
        thisCard = (Ostruzione) CardDatabase.getCardFromId(cardId);

        //scrivo i dati nell'interfaccia
        nameText.text = "" + thisCard.CardName;
        RangeText.text = "" + thisCard.range;
        LimitText.text = "" + thisCard.limit;
        VolumeText.text = "" + thisCard.volume;
        LifeText.text = "" + thisCard.vita;
        DescrizioneText.text = "" + thisCard.descrizione;
        Counter.text = "" + counter;
       
    }
    private void Update()
    {
        countCardId();
        Counter.text = "" + counter;
        if (deckBuilder.cardAttiva == cardId)
        {
            //attivare carta
            GetComponent<Button>().Select();
        }
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
