using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class PhysicalPlayer_Tutorial: MonoBehaviour
{
    public string team;
	public int playerNumber;

    public List<GameObject> cardObjects = new List<GameObject>();
    public Animator animator;
    List<int> deck;

    Player player;
    GameObject enemy;

	public GameObject MovementLine;
	public GameObject MovementTarget;
	public GameObject ThrowLine;
	public GameObject ThrowTargetArea;
	int maxDrag = 40;

	int startPointX;
	int startPointY;
	double angle;
	double distance;
	Vector3 targetPosition;
	Vector3 targetSquare;
	int areaWidth;
	int areaHeight;

	int cardId;
	Card card;

	void Awake()
	{
		AirConsole.instance.onMessage += OnMessage;
	}

	// Start is called before the first frame update
	void Start()
    {
		if (team == "Plants") deck = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
		else deck = new List<int> { 10, 11, 12, 13, 14, 15, 16, 17, 18 };

		if (playerNumber == 1) player = MasterController.player1;
		else player = MasterController.player2;
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
                card = CardDatabase.getCardFromId(cardId);
                // obj = Instantiate<GameObject>(cardObjects[cardId]);
                //obj.transform.position = transform.position + new Vector3(0, .15f, 0); //spessorino per non collidere subito
                //obj.GetComponent<ThrowSimulation>().Throw(targetPosition, ((Arma)card).throwAngle);
                StartCoroutine(LancioOggetto(cardObjects[cardId], targetPosition, (Arma)card));
                animator.SetTrigger("isThrowing");
                break;
            case 6: //pietre
                obj = Instantiate<GameObject>(cardObjects[cardId]);
                obj.transform.position = targetPosition;
                obj.transform.eulerAngles= new Vector3(0, rotationToLookAt.eulerAngles.y, 0);
                animator.SetTrigger("isThrowing");
                break;
            case 7: //tronco
                obj = Instantiate<GameObject>(cardObjects[cardId]);
                obj.transform.position = targetPosition;
                obj.transform.eulerAngles = new Vector3(0, rotationToLookAt.eulerAngles.y, 0);
                animator.SetTrigger("isThrowing");
                break;
            case 8: //sabbia mobile
                obj = Instantiate<GameObject>(cardObjects[cardId]);
                obj.transform.position = targetPosition;
                animator.SetTrigger("isThrowing");
                break;
            case 10: //bomba
            case 11: //dinamite
            case 12: //molotov
            case 15: //pugnale
                card = (Arma)CardDatabase.getCardFromId(cardId);
               //   obj = Instantiate<GameObject>(cardObjects[cardId]);
               // obj.transform.position = transform.position + new Vector3(0, .15f, 0);//spessorino altrimenti collidono subito
              //  obj.GetComponent<ThrowSimulation>().Throw(targetPosition, ((Arma)card).throwAngle);
              StartCoroutine(LancioOggetto(cardObjects[cardId], targetPosition,(Arma)card));
                animator.SetTrigger("isThrowing");
                break;
            case 13: //fucile
            case 14: //bazooka
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
                obj = Instantiate<GameObject>(cardObjects[cardId]);
                obj.transform.position = targetPosition;
                obj.transform.eulerAngles = new Vector3(0, rotationToLookAt.eulerAngles.y, 0);
                animator.SetTrigger("isThrowing");
                break;
            case 17: //barili
                obj = Instantiate<GameObject>(cardObjects[cardId]);
                obj.transform.position = targetPosition;
                obj.transform.eulerAngles = new Vector3(0, rotationToLookAt.eulerAngles.y, 0);
                animator.SetTrigger("isThrowing");
                break;
            case 18: //mina
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


	void OnMessage(int fromDeviceID, JToken data)
	{
		if (fromDeviceID == player.id)
		{

			if (data["action"] != null && data["action"].ToString() == "confirm_card")
			{
				cardId = (int)data["cardId"]; //salva l'id della carta
				card = CardDatabase.getCardFromId(cardId); //setta la card, da cui poi prendere angolo e range
				Debug.Log("Carta scelta con indice: " + cardId);
				AirConsole.instance.Message(fromDeviceID, new { action = "showThrowItem" });
			}

			else if (data["action"] != null && data["action"].ToString() == "skip_movement")
			{
				var message = new { action = "cards", content = deck };
				AirConsole.instance.Message(fromDeviceID, message);
				AirConsole.instance.Message(fromDeviceID, new { action = "showChooseCard" });


			}

			else if (data["action"] != null && data["action"].ToString() == "skip_card")
			{
				AirConsole.instance.Message(fromDeviceID, new { action = "showMove" });
			}


			/**
			 * Touch area MOVIMENTO
			 */

			if (data["action"] != null && data["action"].ToString() == "touch_move_start")
			{
				//Set line starting point
				MovementLine.GetComponent<LineRenderer>().SetPosition(0, gameObject.transform.position);

				//set areaWidth and areaHeight, useful to calc angle and distance
				areaWidth = (int)data["width"];
				areaHeight = (int)data["height"];

				//set startPointX e startPointY to calc angle and distance
				startPointX = (int)((float)data["position"]["x"] * areaWidth);
				startPointY = (int)((float)data["position"]["y"] * areaHeight);
				//Debug.Log("X: " + startPointX + "; Y: " + startPointY);
			}

			else if (data["action"] != null && data["action"].ToString() == "touch_move_move")
			{
				//calcolo della posizione del cursore
				int x = (int)((float)data["position"]["x"] * areaWidth);
				int y = (int)((float)data["position"]["y"] * areaHeight);
				int deltaX = (startPointX - x);
				int deltaY = (startPointY - y);

				//calcolo dell'angolo e distanza associati
				angle = Math.Atan2(deltaY, deltaX);
				distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
				distance = distance / areaWidth; // percentuale su area.
				distance = distance * 100 / maxDrag;
				if (distance > 1) distance = 1;
				distance = distance * 4.8; //movimento massimo è di 5 unità, diminuito a 4.8 perché mi sembra meglio (punti troppo lontani in diagonale)

				//calcolo della target position
				var q = Quaternion.AngleAxis(Mathf.Rad2Deg * (float)angle, Vector3.up);
				targetPosition = gameObject.transform.position + q * Vector3.forward * (float)distance;
				//vincoli per non uscire dalla scacchiera
				if (targetPosition.x < 0) targetPosition.x = 0;
				if (targetPosition.x >= 20) targetPosition.x = 19.99F;
				if (targetPosition.z < 0) targetPosition.z = 0;
				if (targetPosition.z >= 30) targetPosition.z = 29.99F;
				//calcolo target square
				targetSquare = new Vector3((float)(Math.Floor(targetPosition.x) + 0.5), (float)0.11, (float)(Math.Floor(targetPosition.z) + 0.5));

				//Render del secondo estremo della linea e show line
				MovementLine.GetComponent<LineRenderer>().SetPosition(1, targetPosition);
				MovementLine.SetActive(true);

				//Render del quadrato target
				MovementTarget.transform.position = targetSquare;
				MovementTarget.SetActive(true);
			}

			else if (data["action"] != null && data["action"].ToString() == "touch_move_end")
			{
				if (MovementTarget.activeSelf == true) //altrimenti capisce dei touch end random
				{
					gameObject.GetComponent<Movement>().targetPosition = targetSquare;
					MovementLine.SetActive(false);
					MovementTarget.SetActive(false);
					var message = new { action = "cards", content = deck };
					AirConsole.instance.Message(fromDeviceID, message);
					AirConsole.instance.Message(fromDeviceID, new { action = "showChooseCard" });
				}
			}



			/**
			 * Touch area LANCIO
			 */

			//Cose che poi andranno messe da qualche altra parte
			int maxThrow = 10;
			float throwAngle = 45f;
			int explosion = 1;

			if (card != null)
			{
				maxThrow = card.range;
				throwAngle = card.throwAngle;
				if (card is Arma)
				{
					explosion = ((Arma)card).explosion;
				}
			}
			float N = 9;


			if (data["action"] != null && data["action"].ToString() == "touch_throw_start")
			{
				//set areaWidth and areaHeight, useful to calc angle and distance
				areaWidth = (int)data["width"];
				areaHeight = (int)data["height"];

				//set startPointX e startPointY to calc angle and distance
				startPointX = (int)((float)data["position"]["x"] * areaWidth);
				startPointY = (int)((float)data["position"]["y"] * areaHeight);
				//Debug.Log("X: " + startPointX + "; Y: " + startPointY);
			}

			else if (data["action"] != null && data["action"].ToString() == "touch_throw_move")
			{
				//calcolo della posizione del cursore
				int x = (int)((float)data["position"]["x"] * areaWidth);
				int y = (int)((float)data["position"]["y"] * areaHeight);
				int deltaX = (startPointX - x);
				int deltaY = (startPointY - y);

				//calcolo dell'angolo e distanza associati
				angle = Math.Atan2(deltaY, deltaX);
				distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
				distance = distance / areaWidth; // percentuale su area.
				distance = distance * 100 / maxDrag;
				if (distance > 1) distance = 1;
				distance = distance * maxThrow;

				//calcolo della target position
				var q = Quaternion.AngleAxis(Mathf.Rad2Deg * (float)angle, Vector3.up);
				targetPosition = transform.position + q * Vector3.forward * (float)distance;

				//calcolo target square
				targetSquare = new Vector3((float)(Math.Floor(targetPosition.x) + 0.5), (float)0.11, (float)(Math.Floor(targetPosition.z) + 0.5));

				//calcolo dei punti della linea
				LineRenderer line = ThrowLine.GetComponent<LineRenderer>();
				double tangent = Math.Tan(Mathf.Deg2Rad * throwAngle);
				for (int i = 0; i <= N; i++)
				{
					float x0 = transform.position.x;
					float xN = targetSquare.x;
					float z0 = transform.position.z;
					float zN = targetSquare.z;
					//Debug.Log(x0 + "; "+ xN + "; "+ z0 + "; " + zN);
					double XPos = (i / N) * xN + ((N - i) / N) * x0;
					double ZPos = (i / N) * zN + ((N - i) / N) * z0;
					double c = Math.Pow(XPos - ((x0 + xN) / 2), 2) + Math.Pow(ZPos - ((z0 + zN) / 2), 2);
					double YPos = (-tangent / distance * c + tangent * distance / 4);
					//Debug.Log(XPos + "; " + YPos + "; " + ZPos);
					line.SetPosition(i, new Vector3((float)XPos, (float)YPos, (float)ZPos));
				}
				ThrowLine.SetActive(true);

				//Render del quadrato target
				//ThrowTarget.transform.position = targetSquare;
				//ThrowTarget.SetActive(true);
				ThrowTargetArea.transform.position = targetSquare;
				ThrowTargetArea.transform.localScale = new Vector3(explosion, 0.02f, explosion);
				ThrowTargetArea.SetActive(true);

				/** if (ThrowTarget.transform.position == projectile.transform.position)
				{
					HumanPlayer.GetComponent<ThrowSimulation>().enabled = true;
				} **/

			}

			else if (data["action"] != null && data["action"].ToString() == "touch_throw_end")
			{
				if (ThrowTargetArea.activeSelf == true) //altrimenti capisce dei touch end random
				{
					StartCoroutine(FadeOut(ThrowLine));
					StartCoroutine(FadeOut(ThrowTargetArea));
					playCard(cardId, targetSquare);
					AirConsole.instance.Message(fromDeviceID, new { action = "showMove" });
				}
				//Debug.Log("Target: " + targetPosition);
			}
		}
	}


	void OnDestroy()
	{
		if (AirConsole.instance != null)
		{
			AirConsole.instance.onMessage -= OnMessage;
		}
	}


	IEnumerator FadeOut(GameObject obj)
	{
		Color c = obj.GetComponent<Renderer>().material.color;
		for (float ft = 1f; ft >= 0; ft -= 0.1f)
		{
			c.a = ft;
			obj.GetComponent<Renderer>().material.color = c;
			yield return new WaitForSeconds(.1f);
		}
		obj.SetActive(false);
		c.a = 1f;
		obj.GetComponent<Renderer>().material.color = c;
	}
}
