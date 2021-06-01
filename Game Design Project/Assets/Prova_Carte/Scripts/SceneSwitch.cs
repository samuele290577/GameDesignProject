using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{
    public Button sel_button;
    private void Start()
    {
        sel_button.Select();  
    }
    public void SceneSwitcher()
    {
        SceneManager.LoadScene("Scena_test");
    }
    
}
