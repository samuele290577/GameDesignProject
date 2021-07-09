using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalcredits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FinalCoroutine());
    }

    IEnumerator FinalCoroutine()
    {

        yield return new WaitForSeconds(44);

        Application.Quit();
    }
}
