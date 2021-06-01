using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardCoroutine : MonoBehaviour
{
    //public List<Card> deck = new List<Card>();
    //public List<Card> container = new List<Card>();

    public PlayerDeck deck;
    public List<Card> cardList = new List<Card>();
    private float timer = 60f;
    void Start()
    {
        StartCoroutine(Cardcoroutine());
        cardList.Add(new Arma(0, "Apple", 10, 25, 12, 5));
        cardList.Add(new Arma(1, "Banana", 2, 15, 18, 25));
        cardList.Add(new Arma(2, "Pinapple", 2, 35, 8, 4));
        cardList.Add(new Arma(3, "Coconut", 1, 20, 20, 9));
        cardList.Add(new Arma(4, "Watermelon", 1, 20, 18, 4));
        cardList.Add(new Arma(5, "Oranges", 10, 30, 5, 1));
        cardList.Add(new Ostruzione(6, "Roccia", 20, 10, 30, 4, "Blocca gli attacchi dell'avversario se colpita"));
        cardList.Add(new Ostruzione(7, "Pietre", 10, 10, 15, 4, "Se colpita, moltiplica di 1.5 il danno d'attacco"));
        cardList.Add(new Ostruzione(8, "Sabbia Mobile", 15, 1, 10, 9, "Se colpisce l'avversario, egli salterà un turno di movimento"));
        Debug.Log(deck.getTeam());
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
        

        if (deck.getSize() <10)
        {
            for(int i=0; i<10-deck.getSize(); i++)
            {
                int randomIndex = Random.Range(0, cardList.Count);
                deck.AddCard(cardList[randomIndex]);
            }
            SceneManager.LoadScene("Scena_test");
        }
        else
        {
            SceneManager.LoadScene("Scena_test");
        }
    }
}
