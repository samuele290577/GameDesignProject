using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{
    public Button sel_button;
    public ControllerManager controller; 

    private void Start()
    {
        sel_button.Select();
        Debug.Log(controller.GetPlantDeck().getId());
        Debug.Log(controller.GetHumanDeck().getId());
       
    }
    public void SceneSwitcher()
    {
        SceneManager.LoadScene("Scena_test");
    }
    
}
