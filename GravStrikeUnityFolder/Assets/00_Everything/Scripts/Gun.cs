using UnityEngine;
using System.Collections;
using InControl;

public class Gun : MonoBehaviour 
{

	int playerIndex;
	public float waitTime;
	public float waitTimer;
//	public float countdownSpeed;
	CircleProgress cp;

	void Start () 
	{
		waitTimer = waitTime;
		cp = transform.root.FindChild("circle").gameObject.GetComponent<CircleProgress>();
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
//			Debug.Log("FIRE BUTTON PRESSED !!!");
			StartShootTimer();
			if (waitTimer <= 0)
			{
				Shoot();
			}

		} else {
			ResetShootTimer();
//			Debug.Log ("FIRE NOT PRESSED");
		}

	}

	void StartShootTimer ()
	{
		waitTimer -= 1 * Time.deltaTime;
		cp.prog = (waitTimer * 180)/waitTime;
	}

	void ResetShootTimer ()
	{
		waitTimer = waitTime;
		cp.prog = 180;
	}

	void Shoot ()
	{
		ResetShootTimer();
		GameObject bullet = (GameObject)Instantiate(Resources.Load("BulletPrefab"));
		bullet.transform.position = transform.position;
		bullet.transform.rotation = transform.rotation;
	}
}
