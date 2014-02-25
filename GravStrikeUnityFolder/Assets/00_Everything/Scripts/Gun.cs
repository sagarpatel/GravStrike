using UnityEngine;
using System.Collections;
using InControl;

public class Gun : MonoBehaviour 
{

	int playerIndex;
	public float bulletSpeed;
	public float waitTime;
	public float waitTimer;
	public bool canShoot;
//	public float countdownSpeed;
	CircleProgress cp;

	void Start () 
	{
		canShoot = true;
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
		
		if(inputDevice.RightTrigger.IsPressed)
		{
			if (canShoot)
			{
				StartShootTimer();
			}
			if (waitTimer <= 0)
			{
				canShoot = false;
			}

		} 

		if(inputDevice.RightTrigger.WasReleased)
		{
			if (!canShoot)
			{
				Shoot();
			}
			canShoot = true;
		
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
		bullet.GetComponent<Bullet>().playerIndex = playerIndex;
		PVA bulletPVA = bullet.GetComponent<PVA>();
		PVA playerPVA = transform.root.GetComponent<PVA>();
		bullet.transform.position = transform.position;
		bullet.transform.rotation = transform.rotation;
		bulletPVA.intialVelocity = transform.up * bulletSpeed + playerPVA.velocity;
	}
}
