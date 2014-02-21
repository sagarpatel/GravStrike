using UnityEngine;
using System.Collections;
using InControl;

public class PlayerControls : MonoBehaviour 
{	
	public int playerIndex = 0;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		var inputDevice = InputManager.Devices[playerIndex];

		if(inputDevice.Action1.IsPressed)
		{
			Debug.Log("Button Pressed!");
		}
	}


}
