using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardCoroutine : MonoBehaviour
{
    //public List<Card> deck = new List<Card>();
    //public List<Card> container = new List<Card>();

    private float timer = 60f;
    private string nameScene;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Cardcoroutine());
    }

    bool DeleagetForWait()
    {
        if (timer <= 0)
        {
            return true;
        }
        else
        {
            timer -= Time.deltaTime;
            return false;
        }
    }
    IEnumerator Cardcoroutine()
    {
        yield return new WaitUntil(DeleagetForWait);
        //bool isEmpty = !deck.Any();
        /*if (isEmpty)
        {
            for(i=0; i<11; i++)
            {
                int randomIndex = Random.Range(0, container.Count);
                deck[i].Insert(container[randomIndex]);
            }
            SceneManager.LoadScene(nameScene);
        }
        else
        {
            SceneManager.LoadScene(nameScene);
        }*/
    }
}
