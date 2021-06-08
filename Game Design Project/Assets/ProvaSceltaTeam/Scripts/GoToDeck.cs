using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GoToDeck : MonoBehaviour
{
    public PlayerDeck player1;
    public PlayerDeck player2;
    public bool diversi;


    
    // Start is called before the first frame update
    void Start()
    {
        // button.interactable = false;
        player1.setTeam("Player 1");
        player2.setTeam("Player 2");
        diversi = true;

    }

    // Update is called once per frame
    void Update()
    {
        diversi = !(player1.getTeam().Equals(player2.getTeam()));
        Debug.Log(diversi + "" + player1.getTeam() + "" + player2.getTeam());
        
        if (player1.isReady&& player2.isReady && diversi)
        {
           //  button.interactable = true;
            SceneSwitcher();
        }
        /*if (player1.getTeam().Equals(player2.getTeam())) 
        {
            button.interactable = false;
        }*/

    }
    public void SceneSwitcher()
    {
        SceneManager.LoadScene("carte_codice");
    }
}
