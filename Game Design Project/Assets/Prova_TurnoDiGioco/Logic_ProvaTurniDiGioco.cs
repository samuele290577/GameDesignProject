using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class Logic_ProvaTurniDiGioco: MonoBehaviour {

	public GameObject HumanPlayer;
	public GameObject PlantPlayer;

	public GameObject MovementLine;
	public GameObject ThrowLine;
	public float distanceScaleFactor;

	private Player_ProvaTurniDiGioco HumanLogic = null;
	private Player_ProvaTurniDiGioco PlantLogic = null;

	private int startPointX = 0;
	private int startPointY = 0;
	double angle = 0;
	double distance = 0;
	Vector3 targetPosition; 
	private int areaWidth = 0;
	private int areaHeight = 0;

#if !DISABLE_AIRCONSOLE
	void Awake()
	{
		AirConsole.instance.onMessage += OnMessage;
		AirConsole.instance.onReady += OnReady;
		AirConsole.instance.onConnect += OnConnect;
	}

    void OnReady(string code)
	{
		//Since people might be coming to the game from the AirConsole store once the game is live, 
		//I have to check for already connected devices here and cannot rely only on the OnConnect event 
		//DA FARE, QUI è fatto ad minchiam.
		List<int> connectedDevices = AirConsole.instance.GetControllerDeviceIds();
		foreach (int deviceID in connectedDevices)
		{
			AddNewPlayer(deviceID);
		}
	}

	void OnConnect(int device)
	{
		AddNewPlayer(device);
	}

	private void AddNewPlayer(int deviceID)
	{

		if (getPlayer(deviceID) != null) return; //esiste già in registro, ignora.

		//Instantiate player prefab
		if (HumanLogic == null)
		{
			Debug.Log("Set HumanLogic");
			HumanLogic = HumanPlayer.GetComponent<Player_ProvaTurniDiGioco>();
			HumanLogic.setID(deviceID);
			return;
		}
		if (PlantLogic == null)
		{
			Debug.Log("Set PlantLogic");
			PlantLogic = PlantPlayer.GetComponent<Player_ProvaTurniDiGioco>();
			PlantLogic.setID(deviceID);
			return;
		}
		return;
	}

	private GameObject getPlayer(int deviceID)
    {
		if (HumanLogic && HumanLogic.getID() == deviceID) return HumanPlayer;
		if (PlantLogic && PlantLogic.getID() == deviceID) return PlantPlayer;
		Debug.Log("No Player with this ID found");
		return null;
    }

	private Player_ProvaTurniDiGioco getPlayerLogic(int deviceID)
    {
		if (HumanLogic && HumanLogic.getID() == deviceID) return HumanLogic;
		if (PlantLogic && PlantLogic.getID() == deviceID) return PlantLogic;
		Debug.Log("No Player with this ID found");
		return null;
	}

	void OnMessage(int fromDeviceID, JToken data)
	{
		//Metto in player il Game object Prefab del Giocatore
		var Player = getPlayer(fromDeviceID);

		//Log to on-screen Console
		//Debug.Log("Incoming message from device: " + fromDeviceID + ": " + data + " \n \n");

		if (data["action"] != null && data["action"].ToString() == "confirm_card")
        {
			Debug.Log("Carta scelta con indice: " + data["cardIndex"]);
			AirConsole.instance.Message(fromDeviceID, new { action = "showThrowItem" });
        }

		else if (data["action"] != null && data["action"].ToString() == "skip_movement")
		{
			var message = new { action = "cards", content = getPlayerLogic(fromDeviceID).getCards() };
			AirConsole.instance.Message(fromDeviceID, message);
			AirConsole.instance.Message(fromDeviceID, new { action = "showChooseCard" });
		}



		/**
		 * Touch area MOVIMENTO
		 */

		else if (data["action"] != null && data["action"].ToString() == "touch_move_start")
        {
			//Activate Line and set starting point
			MovementLine.SetActive(true);
			MovementLine.GetComponent<LineRenderer>().SetPosition(0, Player.transform.position);

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
			distance = Math.Sqrt(Math.Pow(deltaX,2) + Math.Pow(deltaY,2)) * distanceScaleFactor;

			//calcolo della target position
			var q = Quaternion.AngleAxis(Mathf.Rad2Deg * (float)angle, Vector3.up);
			targetPosition = Player.transform.position + q * Vector3.right * (float)distance;

			//Render del secondo estremo della linea
			MovementLine.GetComponent<LineRenderer>().SetPosition(1, targetPosition);
		}

		else if (data["action"] != null && data["action"].ToString() == "touch_move_end")
		{
			Player.GetComponent<Movement>().targetPosition = targetPosition;
			MovementLine.SetActive(false);
			//Debug.Log("Target: " + targetPosition);
		}



		/**
		 * Touch area LANCIO
		 */

		else if (data["action"] != null && data["action"].ToString() == "touch_throw_start")
		{
			//Activate Line and set starting point
			ThrowLine.SetActive(true);
			ThrowLine.GetComponent<LineRenderer>().SetPosition(0, Player.transform.position);

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
			distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2)) * distanceScaleFactor;

			//calcolo della target position
			var q = Quaternion.AngleAxis(Mathf.Rad2Deg * (float)angle, Vector3.up);
			targetPosition = Player.transform.position + q * Vector3.right * (float)distance;

			//calcolo del secondo estremo della linea
			ThrowLine.GetComponent<LineRenderer>().SetPosition(1, targetPosition);
		}

		else if (data["action"] != null && data["action"].ToString() == "touch_thorw_end")
		{
			ThrowLine.SetActive(false);
			//Debug.Log("Target: " + targetPosition);
		}



	}

	void OnDestroy()
	{
		if (AirConsole.instance != null)
		{
			AirConsole.instance.onMessage -= OnMessage;
			AirConsole.instance.onReady -= OnReady;
			AirConsole.instance.onConnect -= OnConnect;
		}
	}
#endif
}

