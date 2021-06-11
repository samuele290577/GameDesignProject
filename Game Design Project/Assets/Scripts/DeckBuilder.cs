using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckBuilder : MonoBehaviour
{
    public string team;
    private int playerNumber;

    public Text sizeText;
    public Button warButton;
    private int size;
    public Image image;
    public Text idLabel;

    private void Start()
    {
        playerNumber = MasterController.getPlayerNumberFromTeam(team);
        idLabel.text = "" + playerNumber;
        warButton.interactable = false;
    }

    public void addCardToPlayer(int id)
    {
        switch (playerNumber)
        {
            case 1:
                MasterController.player1.AddCard(id);
                break;
            case 2:
                MasterController.player2.AddCard(id);
                break;
        }
    }

    public void removeCardFromPlayer(int id)
    {
        switch (playerNumber)
        {
            case 1:
                MasterController.player1.RemoveCard(id);
                break;
            case 2:
                MasterController.player2.RemoveCard(id);
                break;
        }
    }

    void Update()
    {
        Player player = MasterController.getPlayerFromId(playerNumber);
        size = player.getDeckSize();
        sizeText.text = "Grandezza deck: " + size;
        image.fillAmount = (float)(size * 0.1);
        isInteractable(warButton);
    }

    public void isInteractable(Button button)
    {
        if ((size == 10))
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
}
