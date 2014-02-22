using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravitySource : MonoBehaviour 
{

	[Range(1,20)]
	public float gravityReach = 2.0f;
	public enum gravityEquationTypes
	{
		Constant, LinearScale
	}
	public gravityEquationTypes gravityEquation;

	[Range(-10,10)]
	public float gravityPullStrength = 1.0f;

	List<GameObject> gameObjectsInReach;

	// Use this for initialization
	void Start () 
	{
		gameObjectsInReach = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetGameObjectsInReach();
		ApplyGravity();
	}

	void GetGameObjectsInReach()
	{
		HiggsBoson[] goHBArray = GameObject.FindObjectsOfType(typeof(HiggsBoson)) as HiggsBoson[] ;
		gameObjectsInReach.Clear();

		for(int i = 0; i< goHBArray.Length; i ++)
		{
			GameObject higgBosonGO = goHBArray[i].transform.gameObject;
			float distanceToGO = Vector3.Distance(transform.position, higgBosonGO.transform.position);
			if(distanceToGO < gravityReach)
			{
				gameObjectsInReach.Add(higgBosonGO);
			}
		}
	}

	void ApplyGravity()
	{
		if(gravityEquation == gravityEquationTypes.Constant )
		{
			foreach( GameObject hbGameObject in gameObjectsInReach )
			{
				Vector3 forceDirection = transform.position - hbGameObject.transform.position;
				forceDirection.Normalize();
				Vector3 velocityToAdd = gravityPullStrength * forceDirection;
				hbGameObject.GetComponent<PVA>().velocity += velocityToAdd;
			}
		}
		else if( gravityEquation == gravityEquationTypes.LinearScale )
		{
			foreach( GameObject hbGameObject in gameObjectsInReach )
			{
				Vector3 forceDirection = transform.position - hbGameObject.transform.position;
				float distanceBetween = Mathf.Clamp(forceDirection.magnitude, 1.0f, gravityReach);

				forceDirection.Normalize();
				Vector3 velocityToAdd = gravityPullStrength/distanceBetween * forceDirection;
				hbGameObject.GetComponent<PVA>().velocity += velocityToAdd;
			}
		}

	}

	void OnDrawGizmosSelected() 
	{
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, gravityReach);
    }


}
