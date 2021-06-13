using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Earth : MonoBehaviour
{

    int id = -1; //-1 significa unset

    private List<int> cards = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 }; //sarebbe una lista delle carte, ora le carte sono stringhe

    public List<GameObject> cardObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setID(int deviceID)
    {
        this.id = deviceID;
        Debug.Log("New deviceID set: " + this.id);
    }

    public int getID()
    {
        return this.id;
    }

    public void Noitify()
    {
        Debug.Log("Player " + this.id + " is alive!");
    }

    public List<int> getCards()
    {
        return cards;
    }

    public void playCard(int cardId, Vector3 targetPosition)
    {
        switch (cardId)
        {
            case 0:
                GameObject projectile = Instantiate<GameObject>(cardObjects[0]);
                projectile.transform.position = transform.position + new Vector3(0,.5f,0);
                projectile.GetComponent<ThrowSimulation>().Throw(targetPosition,45f);
                break;
        }
    }
}
