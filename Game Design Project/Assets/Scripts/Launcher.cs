using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Popola il database di carte 
        CardDatabase.Populate();

        // Creo i due giocatori, poi da creare con AirConsole
        MasterController.setPlayers();

        SceneManager.LoadScene("SceltaTeam");
    }
}
