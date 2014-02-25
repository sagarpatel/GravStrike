using UnityEngine;
using System.Collections;

public class Destructability : MonoBehaviour {

	public string killTag;

	void Start () {
		
	}
	
	void Update () {
		
	}

	void On2DCollisionEnter2D (Collision2D collision)
	{
		print ("collided");
		if (collision.collider.tag == killTag)
		{
			Destroy (gameObject);
		}
	}
}
