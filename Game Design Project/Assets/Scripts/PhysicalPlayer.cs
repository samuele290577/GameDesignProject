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

    IEnumerator LancioOggetto( GameObject x, Vector3 targetPosition, Card card)
    {
        yield return new WaitForSeconds(.8f);
        GameObject obj = Instantiate<GameObject>(x);
        obj.transform.position = transform.position + new Vector3(0, 1, 0);
        obj.GetComponent<ThrowSimulation>().Throw(targetPosition, ((Arma)card).throwAngle);

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
                // obj = Instantiate<GameObject>(cardObjects[cardId]);
                //obj.transform.position = transform.position + new Vector3(0, .15f, 0); //spessorino per non collidere subito
                //obj.GetComponent<ThrowSimulation>().Throw(targetPosition, ((Arma)card).throwAngle);
                StartCoroutine(LancioOggetto(cardObjects[cardId], targetPosition, (Arma)card));
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
               //   obj = Instantiate<GameObject>(cardObjects[cardId]);
               // obj.transform.position = transform.position + new Vector3(0, .15f, 0);//spessorino altrimenti collidono subito
              //  obj.GetComponent<ThrowSimulation>().Throw(targetPosition, ((Arma)card).throwAngle);
              StartCoroutine(LancioOggetto(cardObjects[cardId], targetPosition,(Arma)card));
                animator.SetTrigger("isThrowing");
                break;
            case 13: //fucile
            case 14: //bazooka
                player.RemoveCard(cardId);
                GetComponent<Movement>().overrideRotation = true;
                transform.LookAt(targetPosition);
                obj = Instantiate<GameObject>(cardObjects[cardId]);
                obj.transform.rotation = transform.rotation;
                obj.transform.Rotate(0, 90, 0);
                obj.transform.position = transform.position + obj.transform.TransformDirection(new Vector3(-0.2f, 1.5f, .3f));
                obj.GetComponent<Gun>().Fire(targetPosition);
                animator.SetTrigger("isShooting");
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
        //Log("Collisione del Player con " + collider.gameObject);

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
    }
}
