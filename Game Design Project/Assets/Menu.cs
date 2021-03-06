using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Scena_teaser");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HelpGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Awake()
    {
        AirConsole.instance.onMessage += OnMessage;
    }

    void OnMessage(int fromDeviceID, JToken data)
    {
        if (data["action"] != null && data["action"].ToString() == "play")
        {
            SceneManager.LoadScene("Scena_teaser");
        }
        else if (data["action"] != null && data["action"].ToString() == "quit")
        {
            Application.Quit();
        }
        else if (data["action"] != null && data["action"].ToString() == "tutorial")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
