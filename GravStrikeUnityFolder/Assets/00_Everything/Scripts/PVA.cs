using UnityEngine;
using System.Collections;

public class PVA : MonoBehaviour 
{	
	public bool rotationPointsToCurrentVelocity = false;

	Vector3 position;
	public Vector3 velocity;
	public Vector3 acceleration;

	public Vector3 intialVelocity;
	public Vector3 intialAcceleration;

	[Range(0,1)]
	public float velocityDecay = 0;

	[Range(0,1)]
	public float accelerationDecay = 0;

	// Use this for initialization
	void Start () 
	{
		position = new Vector3(0, 0, 0);
		velocity = intialVelocity;
		acceleration = intialAcceleration;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// do core PVA update
		position = transform.position;
		position += velocity * Time.deltaTime;
		velocity += acceleration * Time.deltaTime;

		transform.position = position;

		// apply decay
		velocity = (1.0f - velocityDecay) * velocity;
		acceleration = (1.0f - accelerationDecay) * acceleration;

		// do rotation, if necessary
		if(rotationPointsToCurrentVelocity)
		{
			if(velocity.magnitude != 0)
			{
				Vector3 direction = velocity;
				direction.Normalize();
				transform.right = direction;
			}
		}

	}


}
