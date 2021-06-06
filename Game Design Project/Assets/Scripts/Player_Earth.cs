using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Earth : MonoBehaviour
{

    int id = -1; //-1 significa unset

    private List<string> cards = new List<string>{ "A1", "A2", "A3", "A3", "A4", "A5", "B1", "B2", "B3", "B2"}; //sarebbe una lista delle carte, ora le carte sono stringhe. 

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

    public List<string> getCards()
    {
        return cards;
    }
}
