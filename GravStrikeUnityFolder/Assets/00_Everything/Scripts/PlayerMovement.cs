using UnityEngine;
using System.Collections;
using InControl;

public class PlayerMovement : MonoBehaviour 
{
	int playerIndex;

	[Range(0,10)]
	public float playerPropulsionSpeed = 1.0f;

	// Use this for initialization
	void Start () 
	{
		playerIndex = transform.root.gameObject.GetComponent<PlayerInfo>().playerIndex;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// for debung, in case no controller is plugged in
		var inputDevice = InputManager.ActiveDevice;

		if( InputManager.Devices.Count > 0 )
		{
			inputDevice = InputManager.Devices[playerIndex];
		}
		
		
		if(inputDevice.LeftTrigger.IsPressed || inputDevice.LeftBumper.IsPressed)
		{
			Propulse();
		}
	
	
	}

	void Propulse()
	{
		Vector3 velocityToAdd = transform.up * playerPropulsionSpeed;
		gameObject.GetComponent<PVA>().velocity += velocityToAdd;

	}


}
