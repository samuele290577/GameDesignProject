using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ThisOstruzione : MonoBehaviour
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
        thisCard[0] = (Ostruzione)CardDatabase.cardList[thisId];
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
        RangeText.text = "Range: " + card.range;
        LimitText.text = "Limit: " + card.limit;
        VolumeText.text = "Volume: " + card.volume;
        LifeText.text = "Vita: " + card.vita;
        DescrizioneText.text = "" + card.descrizione;
    }
}
