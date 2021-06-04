using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ThisHumanOstruzione : MonoBehaviour
{
    public List<Ostruzione> thisCard = new List<Ostruzione>();
    public int thisId;

    public Ostruzione card;


    public Text nameText;
    public Text VolumeText;
    public Text RangeText;
    public Text LifeText;
    public Text LimitText;
    public Text DescrizioneText;
    void Start()
    {
        thisCard[0] = (Ostruzione)HumanDatabase.cardList[thisId];
    }

    // Update is called once per frame
    void Update()
    {
        card.id = thisCard[0].id;
        card.CardName = thisCard[0].CardName;
        card.vita = thisCard[0].vita;
        card.range = thisCard[0].range;
        card.limit = thisCard[0].limit;
        card.descrizione = thisCard[0].descrizione;
        card.volume = thisCard[0].volume;

        nameText.text = "" + card.CardName;
        RangeText.text = "" + card.range;
        LimitText.text = "" + card.limit;
        VolumeText.text = "" + card.volume;
        LifeText.text = "" + card.vita;
        DescrizioneText.text = "" + card.descrizione;
    }
}
