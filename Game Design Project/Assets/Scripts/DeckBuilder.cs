using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class DeckBuilder : MonoBehaviour
{
    public string team;
    private int playerNumber;
    private Player player;

    public int cardAttiva;
    public int limitUpId;
    public int limitDownId;

    public KeyCode up;
    public KeyCode down;
    public KeyCode select;
    public KeyCode remove;
    public KeyCode GoToWar;

    public DeckBuilderManager deckBuilderManager;

    public Text sizeText;
    public Button warButton;
    private int size;
    public Image image;
    public Text idLabel;

    private void Awake()
    {
        AirConsole.instance.onMessage += OnMessage;
    }

    private void Start()
    {
        player = MasterController.getPlayerFromTeam(team);
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

    /*
     * RIMPIAZZATO DA AIRCONSOLE, ma tenuto attivo
     */
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
                Debug.Log("Go To War");
            }
        }
    }

    void OnMessage(int fromDeviceID, JToken data)
    {
        //Debug.Log("new message from " + fromDeviceID + ": " + data);

        if (data["action"] != null && data["action"].ToString() == "deck_up" && fromDeviceID == player.id)
        {
            if (cardAttiva >= limitUpId)
                cardAttiva = limitDownId;
            
            else cardAttiva++;
        }
        else if (data["action"] != null && data["action"].ToString() == "deck_down" && fromDeviceID == player.id)
        {
            if (cardAttiva <= limitDownId)
                cardAttiva = limitUpId;

            else cardAttiva--;
        }
        else if (data["action"] != null && data["action"].ToString() == "deck_add" && fromDeviceID == player.id)
        {
            addCardToPlayer(cardAttiva);
        }
        else if (data["action"] != null && data["action"].ToString() == "deck_remove" && fromDeviceID == player.id)
        {
            removeCardFromPlayer(cardAttiva);
        }
        else if (data["action"] != null && data["action"].ToString() == "deck_gotowar" && fromDeviceID == player.id)
        {
            if (size == 10)
            {
                deckBuilderManager.PlayerReady(player.team);
                Debug.Log("Ready to FIGHT!");
            }
        }
    }
}
