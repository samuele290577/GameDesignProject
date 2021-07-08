using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine.SceneManagement;
using System.Threading;

public class Logic_Tutorial: MonoBehaviour {

#if !DISABLE_AIRCONSOLE
	void Awake()
	{
		AirConsole.instance.onMessage += OnMessage;
	}

	private void Start()
	{
		var message = new
		{
			p1 = new
			{
				id = MasterController.player1.id,
				team = "Humans"
			},
			p2 = new
			{
				id = MasterController.player1.id,
				team = "Plants"
			}
		};
		AirConsole.instance.Broadcast(new { action = "gameStats", content = message });
		AirConsole.instance.Broadcast(new { action = "showMove" });
	}

	void OnMessage(int fromDeviceID, JToken data)
	{

	}
#endif
}