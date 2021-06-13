using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckBuilder : MonoBehaviour
{
    public string team;
    private int playerNumber;

    public int cardAttiva;
    public int limitUpId;
    public int limitDownId;
    public KeyCode up;
    public KeyCode down;
    public KeyCode select;
    public KeyCode remove;
    public KeyCode GoToWar;


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
        isSelected();
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
    public void isSelected()
    {
        if (Input.GetKeyDown(select))
        {
            addCardToPlayer(cardAttiva);
        }
        if (Input.GetKeyDown(up))
        {
            if (cardAttiva >= limitUpId)
                cardAttiva = limitDownId;

            else cardAttiva++;
        }
        if (Input.GetKeyDown(down))
        {
            if (cardAttiva >= limitDownId)
                cardAttiva = limitUpId;
            
            else cardAttiva--;
        }
        if (Input.GetKeyDown(remove))
        {
            removeCardFromPlayer(cardAttiva);
        }
        if (Input.GetKeyDown(GoToWar))
        {
            if (size == 10)
            {
                Debug.Log("Go TO War");
            }
        }
    }
}
