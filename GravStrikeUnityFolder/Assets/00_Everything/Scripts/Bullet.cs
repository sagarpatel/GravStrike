using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void Start () 
	{
		
	}
	
	void Update () 
	{
		rigidbody2D.AddForce(transform.up*10);
	}
}
