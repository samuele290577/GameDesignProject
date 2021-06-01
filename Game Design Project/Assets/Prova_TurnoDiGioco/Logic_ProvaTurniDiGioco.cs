using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class Logic_ProvaTurniDiGioco: MonoBehaviour {

	public GameObject PlayerCharacter;

	public GameObject Player;
	public GameObject ControlLine;
	public float distanceScaleFactor;

	private Player_ProvaTurniDiGioco PlayerA = null;
	private Player_ProvaTurniDiGioco PlayerB = null;

	private int startPointX = 0;
	private int startPointY = 0;
	double angle = 0;
	double distance = 0;
	private int areaWidth = 0;
	private int areaHeight = 0;

#if !DISABLE_AIRCONSOLE
	void Awake()
	{
		AirConsole.instance.onMessage += OnMessage;
		AirConsole.instance.onReady += OnReady;
		AirConsole.instance.onConnect += OnConnect;
	}


    private void Update()
    {
		ControlLine.GetComponent<LineRenderer>().SetPosition(0, PlayerCharacter.transform.position);
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
		var message = new { action = "cards", content = getPlayer(device).getCards()};
		AirConsole.instance.Message(device, message);
	}

	private void AddNewPlayer(int deviceID)
	{

		if (getPlayer(deviceID) != null) return; //esiste già in registro, ignora.

		//Instantiate player prefab
		if (PlayerA == null)
		{
			Debug.Log("Set PlayerA");
			PlayerA = Instantiate(Player).GetComponent<Player_ProvaTurniDiGioco>();
			PlayerA.setID(deviceID);
			return;
		}
		if (PlayerB == null)
		{
			Debug.Log("SetPlayerB");
			PlayerB = Instantiate(Player).GetComponent<Player_ProvaTurniDiGioco>();
			PlayerB.setID(deviceID);
			return;
		}
		return;
	}

	private Player_ProvaTurniDiGioco getPlayer(int deviceID)
    {
		if (PlayerA && PlayerA.getID() == deviceID) return PlayerA;
		if (PlayerB && PlayerB.getID() == deviceID) return PlayerB;
		Debug.Log("No Player with this ID found");
		return null; //boh bisogna ritornare qualcosa
    }

	void OnMessage(int fromDeviceID, JToken data)
	{
		//Log to on-screen Console
		//Debug.Log("Incoming message from device: " + fromDeviceID + ": " + data + " \n \n");

		if (data["action"] != null && data["action"].ToString() == "confirm_card")
        {
			Debug.Log("Carta scelta con indice: " + data["cardIndex"]);
			AirConsole.instance.Message(fromDeviceID, new { action = "showLaunchItem" });
        }

		else if(data["action"] != null && data["action"].ToString() == "touch_start")
        {
			//set areaWidth and areaHeight, useful to calc angle and distance
			areaWidth = (int)data["width"];
			areaHeight = (int)data["height"];

			//set startPointX e startPointY to calc angle and distance


			startPointX = (int) ((float)data["position"]["x"] * areaWidth);
			startPointY = (int) ((float)data["position"]["y"] * areaHeight);
			Debug.Log("X: " + startPointX + "; Y: " + startPointY);
        }

		else if (data["action"] != null && data["action"].ToString() == "touch_move")
		{
			//calcolo della posizione del cursore
			int x = (int)((float)data["position"]["x"] * areaWidth);
			int y = (int)((float)data["position"]["y"] * areaHeight);
			int deltaX = (startPointX - x);
			int deltaY = (startPointY - y);
			angle = Math.Atan2(deltaY,deltaX);
			distance = Math.Sqrt(Math.Pow(deltaX,2) + Math.Pow(deltaY,2)) * distanceScaleFactor;
			testRender();
		}

		else if (data["action"] != null && data["action"].ToString() == "touch_end")
		{
			var q = Quaternion.AngleAxis(Mathf.Rad2Deg * (float)angle, Vector3.up);
			var targetPosition = PlayerCharacter.transform.position + q * Vector3.right * (float)distance;
			PlayerCharacter.GetComponent<Movement>().targetPosition = targetPosition;
			Debug.Log("Target: " + targetPosition);

		}

	}

	void testRender()
    {
		var q = Quaternion.AngleAxis(Mathf.Rad2Deg * (float)angle, Vector3.up);
		var targetPos = PlayerCharacter.transform.position + q * Vector3.right * (float) distance;
		ControlLine.GetComponent<LineRenderer>().SetPosition(1, targetPos);

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

