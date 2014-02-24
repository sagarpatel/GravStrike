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

		var inputDevice = InputManager.Devices[playerIndex];
		if(inputDevice.Action1.IsPressed)
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
