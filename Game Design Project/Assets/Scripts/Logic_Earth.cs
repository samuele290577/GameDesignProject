﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class Logic_Earth: MonoBehaviour {

	public GameObject HumanPlayer;
	public GameObject PlantPlayer;

	public GameObject MovementLine;
	public GameObject MovementTarget;
	public GameObject ThrowLine;
	public GameObject ThrowTarget;

	int maxDrag = 40;

	private Player_Earth HumanLogic = null;
	private Player_Earth PlantLogic = null;

	private int startPointX = 0;
	private int startPointY = 0;
	double angle = 0;
	double distance = 0;
	Vector3 targetPosition;
	Vector3 targetSquare;
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
			HumanLogic = HumanPlayer.GetComponent<Player_Earth>();
			HumanLogic.setID(deviceID);
			return;
		}
		if (PlantLogic == null)
		{
			Debug.Log("Set PlantLogic");
			PlantLogic = PlantPlayer.GetComponent<Player_Earth>();
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

	private Player_Earth getPlayerLogic(int deviceID)
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

		if (data["action"] != null && data["action"].ToString() == "touch_move_start")
        {
			//Set line starting point
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
			distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
			distance = distance / areaWidth; // percentuale su area.
			distance = distance * 100 / maxDrag;
			if (distance > 1) distance = 1;
			distance = distance * 4.8; //movimento massimo è di 5 unità, diminuito a 4.8 perché mi sembra meglio (punti troppo lontani in diagonale)

			//calcolo della target position
			var q = Quaternion.AngleAxis(Mathf.Rad2Deg * (float)angle, Vector3.up);
			targetPosition = Player.transform.position + q * Vector3.forward * (float)distance;
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
			Player.GetComponent<Movement>().targetPosition = targetSquare;
			MovementLine.SetActive(false);
			MovementTarget.SetActive(false);
			//Debug.Log("Target: " + targetPosition);
		}



		/**
		 * Touch area LANCIO
		 */

		//Cose che poi andranno messe da qualche altra parte
		int maxThrow = 20;
		float throwAngle = 45F;
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
			targetPosition = Player.transform.position + q * Vector3.forward * (float)distance;
			//calcolo target square
			targetSquare = new Vector3((float)(Math.Floor(targetPosition.x) + 0.5), (float)0.11, (float)(Math.Floor(targetPosition.z) + 0.5));

			//calcolo dei punti della linea
			LineRenderer line = ThrowLine.GetComponent<LineRenderer>();
			double tangent = Math.Tan(Mathf.Deg2Rad * throwAngle);
			Debug.Log(tangent);
			for (int i = 0; i <= N; i++)
            {
				float x0 = Player.transform.position.x;
				float xN = targetSquare.x;
				float z0 = Player.transform.position.z;
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
			ThrowTarget.transform.position = targetSquare;
			ThrowTarget.SetActive(true);
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

