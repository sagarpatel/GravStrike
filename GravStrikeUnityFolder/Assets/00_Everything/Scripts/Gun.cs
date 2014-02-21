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
		var inputDevice = InputManager.Devices[playerIndex];
		if(inputDevice.Action1.IsPressed)
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
