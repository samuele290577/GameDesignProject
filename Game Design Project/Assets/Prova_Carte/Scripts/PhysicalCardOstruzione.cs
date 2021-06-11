using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PhysicalCardOstruzione : MonoBehaviour
{
    public int cardId;

    private Ostruzione thisCard;


    public Text nameText;
    public Text VolumeText;
    public Text RangeText;
    public Text LifeText;
    public Text LimitText;
    public Text DescrizioneText;

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
    }
}
