using UnityEngine;
using System.Collections;

public class Destructability : MonoBehaviour {

	int playerIndex;
	public string killTag;

	void Start () {
		playerIndex = gameObject.GetComponent<PlayerInfo>().playerIndex;
	}
	
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
//		Debug.Log("collided");

		// if the bullet I collided with is not my bullet, destroy myself
		if (collision.collider.GetComponent<Bullet>() != null)
		{
			if (collision.collider.GetComponent<Bullet>().playerIndex != playerIndex)
			{
				if (collision.collider.tag == killTag)
				{
					Destroy (gameObject);
				}
			}
		}

		// if I collided with border destroy myself
		if (collision.collider.tag == "Border")
		{
			Destroy (gameObject);
		}
	}
}
