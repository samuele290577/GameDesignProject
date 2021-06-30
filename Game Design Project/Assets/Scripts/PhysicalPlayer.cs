using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PhysicalPlayer : MonoBehaviour
{
    public string team;
    public List<GameObject> cardObjects = new List<GameObject>();
    public Animator animator; 


    Player player;
    GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        player = MasterController.getPlayerFromTeam(team);
        enemy = GetComponent<Movement>().enemy;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playCard(int cardId, Vector3 targetPosition)
    {
        Card card;
        GameObject obj;
        Debug.Log("Playing card: " + cardId);

        Quaternion rotationToLookAt = Quaternion.LookRotation(enemy.transform.position - targetPosition);

        switch (cardId)
        {
            case 0: //mela
            case 1: //banane
            case 2: //ananas
            case 3: //cocco
            case 4: //anguria
            case 5: //arancia
                player.RemoveCard(cardId);
                card = CardDatabase.getCardFromId(cardId);
                obj = Instantiate<GameObject>(cardObjects[cardId]);
                obj.transform.position = transform.position + new Vector3(0, .15f, 0); //spessorino per non collidere subito
                obj.GetComponent<ThrowSimulation>().Throw(targetPosition, ((Arma)card).throwAngle);
                animator.SetTrigger("isThrowing");
                break;
            case 6: //pietre
                player.RemoveCard(cardId);
                obj = Instantiate<GameObject>(cardObjects[cardId]);
                obj.transform.position = targetPosition;
                obj.transform.eulerAngles= new Vector3(0, rotationToLookAt.eulerAngles.y, 0);
                animator.SetTrigger("isThrowing");
                break;
            case 7: //tronco
                player.RemoveCard(cardId);
                obj = Instantiate<GameObject>(cardObjects[cardId]);
                obj.transform.position = targetPosition;
                obj.transform.eulerAngles = new Vector3(0, rotationToLookAt.eulerAngles.y, 0);
                animator.SetTrigger("isThrowing");
                break;
            case 8: //sabbia mobile
                player.RemoveCard(cardId);
                obj = Instantiate<GameObject>(cardObjects[cardId]);
                obj.transform.position = targetPosition;
                animator.SetTrigger("isThrowing");
                break;
            case 10: //bomba
            case 11: //dinamite
            case 12: //molotov
            case 15: //pugnale
                player.RemoveCard(cardId);
                card = (Arma)CardDatabase.getCardFromId(cardId);
                obj = Instantiate<GameObject>(cardObjects[cardId]);
                obj.transform.position = transform.position + new Vector3(0, .15f, 0); //spessorino altrimenti collidono subito
                obj.GetComponent<ThrowSimulation>().Throw(targetPosition, ((Arma)card).throwAngle);
                animator.SetTrigger("isThrowing");
                break;
            case 16: //muro
                player.RemoveCard(cardId);
                obj = Instantiate<GameObject>(cardObjects[cardId]);
                obj.transform.position = targetPosition;
                obj.transform.eulerAngles = new Vector3(0, rotationToLookAt.eulerAngles.y, 0);
                animator.SetTrigger("isThrowing");
                break;
            case 17: //barili
                player.RemoveCard(cardId);
                obj = Instantiate<GameObject>(cardObjects[cardId]);
                obj.transform.position = targetPosition;
                obj.transform.eulerAngles = new Vector3(0, rotationToLookAt.eulerAngles.y, 0);
                animator.SetTrigger("isThrowing");
                break;
            case 18: //mina
                player.RemoveCard(cardId);
                obj = Instantiate<GameObject>(cardObjects[cardId]);
                obj.transform.position = targetPosition;
                obj.transform.eulerAngles = new Vector3(0, rotationToLookAt.eulerAngles.y, 0);
                animator.SetTrigger("isThrowing");
                break;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collisione del Player con " + collider.gameObject);
        //fermati se trovi una collisione
        if (collider.gameObject.tag == "Ostruzione")
        {
            Vector3 pos = transform.position - collider.gameObject.transform.position;
            float newX = (float)Math.Round(transform.position.x);
            float newZ = (float)Math.Round(transform.position.z);
            if (pos.x < 0) newX = newX - 0.5f;
            else newX = newX + 0.5f;
            if (pos.z < 0) newZ = newZ - 0.5f;
            else newZ = newZ + 0.5f;
            GetComponent<Movement>().targetPosition = new Vector3(newX, transform.position.y, newZ);
        }
            
            
            

        //diversi casi a seconda del team di appartenenza
        if (team == "Humans")
        {
            if (collider.gameObject.name == "Pietre" || collider.gameObject.name == "Pietre(Clone)")
            {


            }
            else if (collider.gameObject.name == "Tronco" || collider.gameObject.name == "Tronco(Clone)")
            {


            }
            else if (collider.gameObject.name == "Sabbia" || collider.gameObject.name == "Sabbia(Clone)")
            {


            }
        }
        if (team == "Plants")
        {
            if (collider.gameObject.name == "Muro" || collider.gameObject.name == "Muro(Clone)")
            {


            }
            else if (collider.gameObject.name == "Barili" || collider.gameObject.name == "Barili(Clone)")
            {


            }
            else if (collider.gameObject.name == "Mina" || collider.gameObject.name == "Mina(Clone)")
            {


            }
        }
    }
}
