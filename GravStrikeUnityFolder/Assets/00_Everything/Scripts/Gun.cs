using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	private 

	void Start () 
	{
		Shoot ();
	}
	
	void Update () 
	{
		
	}

	void Shoot ()
	{
		GameObject bullet = (GameObject)Instantiate(Resources.Load("BulletPrefab"));
		bullet.transform.position = transform.position;
		bullet.transform.rotation = transform.rotation;
	}
}
