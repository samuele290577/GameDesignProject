using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugListaCarte : MonoBehaviour
{
    private void Start()
    {
        string playerTeam = MasterController.player1.team;
        Debug.Log("Carte scelte da team " + playerTeam + ", numero giocatore: 1");
        foreach (int cardId in MasterController.player1.getCards())
        {
            Card card = CardDatabase.getCardFromId(cardId);
            Debug.Log(card.id + ", " + card.CardName);
        }

        playerTeam = MasterController.player2.team;
        Debug.Log("Carte scelte da team " + playerTeam + ", numero giocatore: 2");
        foreach (int cardId in MasterController.player2.getCards())
        {
            Card card = CardDatabase.getCardFromId(cardId);
            Debug.Log(card.id + ", " + card.CardName);
        }
    }
}
