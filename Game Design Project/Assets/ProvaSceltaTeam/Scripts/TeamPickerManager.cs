using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamPickerManager : MonoBehaviour
{
    public Button button_plants;
    public Button button_humans;
    public KeyCode plants;
    public KeyCode humans;
    public KeyCode ready;
    public int playerNumber;
    public GoToDeck GoToDeck;

    private Player player;

    public void Start()
    {
        if (playerNumber == 1) player = MasterController.player1;
        else if (playerNumber == 2) player = MasterController.player2;
        else Debug.LogError("Errore nell'assegnazione del giocatore!");
    }

    public void ChosenPlants()
    {
            player.setTeam("Plants");
            button_plants.image.color = Color.green;
            button_humans.image.color = Color.white;
            Debug.Log("Player"+ player.getId() + " ha scelto"  + player.getTeam());

    }
    public void ChosenHumans()
    {

            player.setTeam("Humans");
            button_humans.image.color = Color.red;
            button_plants.image.color = Color.white;
            Debug.Log("Player" + player.getId() + " ha scelto" + player.getTeam());

    }
    private void Update()
    {
        if (Input.GetKey(plants))
        {
            ChosenPlants();
        }
        if (Input.GetKey(humans))
        {
            ChosenHumans();
        }
        if (Input.GetKey(ready))
        {
            if (player.getTeam() == "unset") return; //se non è stato scelto il team, non si può confermare
            GoToDeck.teamReady(playerNumber, player.getTeam());
        }
    }
}
