using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;
using System.Threading;

public class Logic_Earth: MonoBehaviour {

	public GameObject MovementLine;
	public GameObject MovementTarget;
	public GameObject ThrowLine;
	public GameObject ThrowTarget;
	public GameObject ThrowTargetArea;

	public float change = 45f;
	IEnumerator timer;
	IEnumerator timer2;
	IEnumerator timer3;
	IEnumerator timer4;


	int maxDrag = 40;

	public GameObject HumanPlayer;
	public GameObject PlantPlayer;

	private int startPointX = 0;
	private int startPointY = 0;
	double angle = 0;
	double distance = 0;
	Vector3 targetPosition;
	Vector3 targetSquare;
	private int areaWidth = 0;
	private int areaHeight = 0;

	//Chi gioca ora e chi giocherà il prox turno
	public String currentTurn;
	public String nextTurn;
	public GameObject currentPlayer;

	//Eventuale carta scelta
	int cardId = -1;
	Card card;

	public void ChangeTurn()
    {
		if (timer != null) StopCoroutine(timer);
		if (timer2 != null) StopCoroutine(timer2);
		if (timer3 != null) StopCoroutine(timer3);
		if (timer4 != null) StopCoroutine(timer4);
		
		currentTurn = nextTurn;
		if (currentTurn == "Plants")
		{ 
			nextTurn = "Humans";
			currentPlayer = GameObject.FindWithTag("Plant_Player");
		}

		else {
			nextTurn = "Plants";
			currentPlayer = GameObject.FindWithTag("Human_Player");
		}
			
		AirConsole.instance.Message(MasterController.getPlayerFromTeam(currentTurn).id, new { action = "showMove"});
		AirConsole.instance.Message(MasterController.getPlayerFromTeam(nextTurn).id, new { action = "showWaitYourTurn"});
		
	}
	//gestione tempo
	private IEnumerator TimeUpdate(float sec)
    {
		 change = sec;
		
        while (change > 0)
        {
			yield return new WaitForSeconds(1f);
			change--;
			//Debug.Log("eharth:" + change);
		}
		
		ChangeTurn();
		timer4 = TimeUpdate(45f);
		StartCoroutine(timer4);

	}

#if !DISABLE_AIRCONSOLE
	void Awake()
	{
		AirConsole.instance.onMessage += OnMessage;
		//AirConsole.instance.onReady += OnReady;
		//AirConsole.instance.onConnect += OnConnect;
	}

    private void Start()
    {
		if (MasterController.player1 == null || MasterController.player2 == null) SceneManager.LoadScene("Launcher");

		//Giocatore random per iniziare
		System.Random rand = new System.Random();
		if (rand.Next(0, 2) == 0) //Iniziano umani
        {
			currentTurn = "Humans";
			currentPlayer = GameObject.FindWithTag("Human_Player");

			nextTurn = "Plants";
		}
		else //iniziano le piante
        {
			currentTurn = "Plants";
			currentPlayer = GameObject.FindWithTag("Plant_Player");
			nextTurn = "Humans";
		}
		Debug.Log("start");
		AirConsole.instance.Message(MasterController.getPlayerFromTeam(currentTurn).id, new { action = "showMove"});
		AirConsole.instance.Message(MasterController.getPlayerFromTeam(nextTurn).id, new { action = "showWaitYourTurn"});
		timer = TimeUpdate(45f);
		StartCoroutine(timer);
	}

    void OnMessage(int fromDeviceID, JToken data)
	{
		Player player = MasterController.getPlayerFromId(fromDeviceID);
		PhysicalPlayer physicalPlayer;

		if (MasterController.getPlayerFromId(fromDeviceID).team == "Plants") physicalPlayer = PlantPlayer.GetComponent<PhysicalPlayer>();
		else if (MasterController.getPlayerFromId(fromDeviceID).team == "Humans") physicalPlayer = HumanPlayer.GetComponent<PhysicalPlayer>();
		else physicalPlayer = null; //Va messo se no mi da errore!


		if (data["action"] != null && data["action"].ToString() == "confirm_card")
        {
			cardId = (int)data["cardId"]; //salva l'id della carta
			card = CardDatabase.getCardFromId(cardId); //setta la card, da cui poi prendere angolo e range
			Debug.Log("Carta scelta con indice: " + cardId);
			AirConsole.instance.Message(fromDeviceID, new { action = "showThrowItem" });
        }

		else if (data["action"] != null && data["action"].ToString() == "skip_movement")
		{
			var message = new { action = "cards", content = player.getCards() };
			AirConsole.instance.Message(fromDeviceID, message);
			AirConsole.instance.Message(fromDeviceID, new { action = "showChooseCard" });
			

		}

		else if (data["action"] != null && data["action"].ToString() == "skip_card")
		{
			
			ChangeTurn();
			timer2 = TimeUpdate(45f);
			StartCoroutine(timer2);

		}


		/**
		 * Touch area MOVIMENTO
		 */

		if (data["action"] != null && data["action"].ToString() == "touch_move_start")
        {
			//Set line starting point
			MovementLine.GetComponent<LineRenderer>().SetPosition(0, physicalPlayer.gameObject.transform.position);

			//set areaWidth and areaHeight, useful to calc angle and distance
			areaWidth = (int)data["width"];
			areaHeight = (int)data["height"];

			//set startPointX e startPointY to calc angle and distance
			startPointX = (int) ((float)data["position"]["x"] * areaWidth);
			startPointY = (int) ((float)data["position"]["y"] * areaHeight);
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
			angle = Math.Atan2(deltaY,deltaX);
			distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
			distance = distance / areaWidth; // percentuale su area.
			distance = distance * 100 / maxDrag;
			if (distance > 1) distance = 1;
			distance = distance * 4.8; //movimento massimo è di 5 unità, diminuito a 4.8 perché mi sembra meglio (punti troppo lontani in diagonale)

			//calcolo della target position
			var q = Quaternion.AngleAxis(Mathf.Rad2Deg * (float)angle, Vector3.up);
			targetPosition = physicalPlayer.gameObject.transform.position + q * Vector3.forward * (float)distance;
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
				physicalPlayer.gameObject.GetComponent<Movement>().targetPosition = targetSquare;
				MovementLine.SetActive(false);
				MovementTarget.SetActive(false);
				var message = new { action = "cards", content = player.getCards() };
				AirConsole.instance.Message(fromDeviceID, message);
				AirConsole.instance.Message(fromDeviceID, new { action = "showChooseCard" });
			}
			//Debug.Log("Target: " + targetPosition);
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
			if(card is Arma)
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
			targetPosition = physicalPlayer.transform.position + q * Vector3.forward * (float)distance;

			//calcolo target square
			targetSquare = new Vector3((float)(Math.Floor(targetPosition.x) + 0.5), (float)0.11, (float)(Math.Floor(targetPosition.z) + 0.5));

			//calcolo dei punti della linea
			LineRenderer line = ThrowLine.GetComponent<LineRenderer>();
			double tangent = Math.Tan(Mathf.Deg2Rad * throwAngle);
			for (int i = 0; i <= N; i++)
            {
				float x0 = physicalPlayer.transform.position.x;
				float xN = targetSquare.x;
				float z0 = physicalPlayer.transform.position.z;
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
			Color col = ThrowTargetArea.GetComponent<Renderer>().material.color;
			col.a = 1f;
			ThrowTargetArea.GetComponent<Renderer>().material.color = col;
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
				//StartCoroutine(FadeOut(ThrowTarget));
				StartCoroutine(FadeOut(ThrowTargetArea));
				physicalPlayer.playCard(cardId, targetSquare);
				ChangeTurn();
				timer3 = TimeUpdate(45f);
				StartCoroutine(timer3);
			}
			//Debug.Log("Target: " + targetPosition);
		}
	
		



	}


	void OnDestroy()
	{
		if (AirConsole.instance != null)
		{
			AirConsole.instance.onMessage -= OnMessage;
			//AirConsole.instance.onReady -= OnReady;
			//AirConsole.instance.onConnect -= OnConnect;
		}
	}


	IEnumerator FadeOut(GameObject obj)
    {
		for (float ft = 1f; ft >= 0; ft -= 0.1f)
		{
			Color c = obj.GetComponent<Renderer>().material.color;
			c.a = ft;
			obj.GetComponent<Renderer>().material.color = c;
			yield return new WaitForSeconds(.1f);
		}
		obj.SetActive(false);
	}
#endif
}