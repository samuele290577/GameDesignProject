using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalPlayer : MonoBehaviour
{
    public string team;
    public List<GameObject> cardObjects = new List<GameObject>();

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = MasterController.getPlayerFromTeam(team);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playCard(int cardId, Vector3 targetPosition)
    {
        Card card;
        GameObject projectile;

        switch (cardId)
        {
            case 0: //mela
            case 1: //banane
            case 2: //ananas
            case 3: //cocco
            case 4: //anguria
            case 5: //arancia
                player.RemoveCard(cardId);
                card = (Arma) CardDatabase.getCardFromId(cardId);
                projectile = Instantiate<GameObject>(cardObjects[cardId]);
                projectile.transform.position = transform.position + new Vector3(0, 0, 0);
                projectile.GetComponent<ThrowSimulation>().Throw(targetPosition, ((Arma)card).throwAngle);
                break;
        }
    }
}
