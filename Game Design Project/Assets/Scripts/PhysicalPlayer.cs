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
        switch (cardId)
        {
            case 0:
                player.RemoveCard(cardId);
                GameObject projectile = Instantiate<GameObject>(cardObjects[0]);
                projectile.transform.position = transform.position + new Vector3(0, .5f, 0);
                projectile.GetComponent<ThrowSimulation>().Throw(targetPosition, 45f);
                break;
        }
    }
}
