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

	public GameObject MovementLine1;
	public GameObject MovementTarget1;
	public GameObject ThrowLine1;
	public GameObject ThrowTargetArea1;
	public GameObject MovementLine2;
	public GameObject MovementTarget2;
	public GameObject ThrowLine2;
	public GameObject ThrowTargetArea2;

	int maxDrag = 40;

	public GameObject HumanPlayer;
	public GameObject PlantPlayer;

	int startPointX_1;
	int startPointY_1;
	double angle_1;
	double distance_1;
	Vector3 targetPosition_1;
	Vector3 targetSquare_1;
	int areaWidth_1;
	int areaHeight_1;
	int cardId_1;
	Card card_1;


#if !DISABLE_AIRCONSOLE
	void Awake()
	{
		AirConsole.instance.onMessage += OnMessage;
	}

    private void Start()
    {
		
	}

	void OnMessage(int fromDeviceID, JToken data)
	{

	}
#endif
}