using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{
    public Button sel_button_plants;
    public Button sel_button_humans;

    private void Start()
    {
        sel_button_plants.Select();
        sel_button_humans.Select();
       
    }
    public void SceneSwitcher()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
