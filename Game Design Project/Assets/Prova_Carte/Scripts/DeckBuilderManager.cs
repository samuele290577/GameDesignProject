using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeckBuilderManager : MonoBehaviour
{
    private bool playerPlantsReady = false;
    private bool playerHumansReady = false;

    public void PlayerReady(string team)
    {
        switch (team)
        {
            case "Plants":
                playerPlantsReady = true;
                break;
            case "Humans":
                playerHumansReady = true;
                break;
        }
    }

    private void Update()
    {
        if (playerPlantsReady && playerHumansReady) SceneManager.LoadScene("SampleScene");
    }
}
