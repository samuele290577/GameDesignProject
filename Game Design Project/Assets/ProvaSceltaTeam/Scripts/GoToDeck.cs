using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GoToDeck : MonoBehaviour
{
    public Team team1;
    public Team team2;
  
    
    public Button button;

    
    // Start is called before the first frame update
    void Start()
    {
        button.interactable = false;

    }

    // Update is called once per frame
    void Update()
    {
       if (team1.isReady&& team2.isReady && !(team1.team_name.Equals(team2.team_name)))
        {
            button.interactable = true;
            SceneSwitcher();
        }
        if (team1.team_name.Equals(team2.team_name))
        {
            button.interactable = false;
        }

    }
    public void SceneSwitcher()
    {
        SceneManager.LoadScene("carte_codice");
    }
}
