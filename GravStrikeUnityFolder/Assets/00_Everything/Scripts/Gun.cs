using UnityEngine;
using System.Collections;
using InControl;

public class Gun : MonoBehaviour 
{

	int playerIndex;

	void Start () 
	{
		Debug.Log(gameObject.GetComponent<PlayerInfo>());
		// traversing up to the main player object
		playerIndex = transform.root.gameObject.GetComponent<PlayerInfo>().playerIndex;
	}
	
	void Update () 
	{
		// for debung, in case no controller is plugged in
		var inputDevice = InputManager.ActiveDevice;

		if( InputManager.Devices.Count > 0 )
		{
			inputDevice = InputManager.Devices[playerIndex];
		}
		
		if(inputDevice.Action3.IsPressed)
		{
			Debug.Log("FIRE BUTTON PRESSED !!!");
		}

	}

	void Shoot ()
	{
		GameObject bullet = (GameObject)Instantiate(Resources.Load("BulletPrefab"));
		bullet.transform.position = transform.position;
		bullet.transform.rotation = transform.rotation;
	}
}
