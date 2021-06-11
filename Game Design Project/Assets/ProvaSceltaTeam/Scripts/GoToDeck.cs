using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToDeck : MonoBehaviour
{
    public bool diversi;

    private bool player1Ready = false;
    private bool player2Ready = false;

    public void teamReady(int teamNumber, string type)
    {
        if (teamNumber == 1) player1Ready = true;
        else if (teamNumber == 2) player2Ready = true;
        else Debug.LogError("Wrong team number in team Ready Script!");
    }

    // Update is called once per frame
    void Update()
    {
        diversi = !(MasterController.player1.getTeam().Equals(MasterController.player2.getTeam()));

        if (player1Ready && player2Ready && diversi)
        {
            SceneManager.LoadScene("carte_codice");
        }
    }
}