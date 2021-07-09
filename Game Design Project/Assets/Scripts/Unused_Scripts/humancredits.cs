using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class humancredits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreditsCoroutine());
    }


    IEnumerator CreditsCoroutine()
    {

        yield return new WaitForSeconds(24);

        SceneManager.LoadScene("Scena_credits");
    }
}
