
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardCoroutine : MonoBehaviour
{
    private int randomIndex;
    private float timer = 60f;
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


        if (MasterController.player1.deck.Count < 10)
        {
            for (int i = MasterController.player1.deck.Count; i < 11; i++)
            {
                if (MasterController.player1.team == "Plants")
                {
                    randomIndex = Random.Range(0, 8);
                }
                else
                {
                    randomIndex = Random.Range(10, 18);
                }
                MasterController.player1.AddCard(randomIndex);
                while (MasterController.player1.deckOverload == true)
                {
                    MasterController.player1.deckOverload = false;
                    if (MasterController.player1.team == "Plants")
                    {
                        randomIndex = Random.Range(0, 8);
                    }
                    else
                    {
                        randomIndex = Random.Range(10, 18);
                    }
                    MasterController.player1.AddCard(randomIndex);
                }
            }
        }
        else if (MasterController.player1.deck.Count > 10)
        {
            for (int i = MasterController.player1.deck.Count; i > 10; i--)
            {
                MasterController.player1.deck.RemoveAt(i - 1);
                Debug.Log("carta tolta");
            }
            Debug.Log("deck overload");
        }
        if (MasterController.player2.deck.Count < 10)
        {
            for (int i = MasterController.player2.deck.Count; i < 11; i++)
            {
                if (MasterController.player2.team == "Plants")
                {
                    randomIndex = Random.Range(0, 8);
                }
                else
                {
                    randomIndex = Random.Range(10, 18);
                }
                MasterController.player2.AddCard(randomIndex);
                while (MasterController.player2.deckOverload == true)
                {
                    MasterController.player2.deckOverload = false;
                    if (MasterController.player2.team == "Plants")
                    {
                        randomIndex = Random.Range(0, 8);
                    }
                    else
                    {
                        randomIndex = Random.Range(10, 18);
                    }
                    MasterController.player2.AddCard(randomIndex);
                }
            }
        }
        else if (MasterController.player2.deck.Count > 10)
        {
            for (int i = MasterController.player2.deck.Count; i > 10; i--)
            {
                MasterController.player2.deck.RemoveAt(i - 1);
            }
        }
        SceneManager.LoadScene("Earth");
    }
}
