using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
{
    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public Card card;
    

    public Text nameText;
    public Text PowerText;
    public Text RangeText;
    public Text LimitText;
    public Text explosionText;
    void Start()
    {
        thisCard[0] = CardDatabase.cardList[thisId];
    }

    // Update is called once per frame
    void Update()
    {
        card.id = thisCard[0].id;
        card.CardName = thisCard[0].CardName;
        card.power = thisCard[0].power;
        card.range = thisCard[0].range;
        card.limit = thisCard[0].limit;
        card.explosion = thisCard[0].explosion;

        nameText.text = "" + card.CardName;
        RangeText.text = "" + card.range;
        LimitText.text = "" + card.limit;
        PowerText.text = "" + card.power;
        explosionText.text = "" + card.explosion;
    }
}
