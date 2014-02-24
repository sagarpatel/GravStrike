using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravitySource : MonoBehaviour 
{

	[Range(1,50)]
	public float gravityReach = 2.0f;
	public enum gravityEquationTypes
	{
		Constant, Linear, Squared, InverseDistanceSquare
	}
	public gravityEquationTypes gravityEquation;

	[Range(-20,20)]
	public float gravityPullStrength = 1.0f;

	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		ApplyGravity( GetHBGameObjectsList() );
	}

	public List<GameObject> GetHBGameObjectsList()
	{
		HiggsBoson[] goHBArray = GameObject.FindObjectsOfType(typeof(HiggsBoson)) as HiggsBoson[] ;
		List<GameObject> hbGameObjectsList = new List<GameObject>();

		for(int i = 0; i< goHBArray.Length; i ++)
		{
			GameObject higgBosonGO = goHBArray[i].transform.gameObject;
			float distanceToGO = Vector3.Distance(transform.position, higgBosonGO.transform.position);
			if(distanceToGO < gravityReach)
			{
				hbGameObjectsList.Add(higgBosonGO);
			}
		}

		return hbGameObjectsList;
	}

	void ApplyGravity( List<GameObject> hbGameObjectsList )
	{
		if(gravityEquation == gravityEquationTypes.Constant )
		{
			foreach( GameObject hbGameObject in hbGameObjectsList )
			{
				float distanceToGo = Vector3.Distance(transform.position, hbGameObject.transform.position);
				if( distanceToGo < gravityReach )
				{
					Vector3 forceDirection = transform.position - hbGameObject.transform.position;
					forceDirection.Normalize();
					Vector3 velocityToAdd = gravityPullStrength * forceDirection;
					hbGameObject.GetComponent<PVA>().velocity += velocityToAdd;
				}
			}
		}
		else if( gravityEquation == gravityEquationTypes.Linear )
		{
			foreach( GameObject hbGameObject in hbGameObjectsList )
			{
				float distanceToGo = Vector3.Distance(transform.position, hbGameObject.transform.position);
				if( distanceToGo < gravityReach )
				{
					Vector3 forceDirection = transform.position - hbGameObject.transform.position;
					float distanceBetween = Mathf.Clamp(forceDirection.magnitude, 1.0f, gravityReach);

					forceDirection.Normalize();
					Vector3 velocityToAdd = gravityPullStrength/distanceBetween * forceDirection;
					hbGameObject.GetComponent<PVA>().velocity += velocityToAdd;
				}
			}
		}
		else if( gravityEquation == gravityEquationTypes.Squared )
		{
			foreach( GameObject hbGameObject in hbGameObjectsList )
			{
				float distanceToGo = Vector3.Distance(transform.position, hbGameObject.transform.position);
				if( distanceToGo < gravityReach )
				{
					Vector3 forceDirection = transform.position - hbGameObject.transform.position;
					float distanceBetween = Mathf.Clamp(forceDirection.magnitude, 1.0f, gravityReach);
					distanceBetween = distanceBetween * distanceBetween;

					forceDirection.Normalize();
					Vector3 velocityToAdd = gravityPullStrength/distanceBetween * forceDirection;
					hbGameObject.GetComponent<PVA>().velocity += velocityToAdd;
				}
			}
		}
		else if( gravityEquation == gravityEquationTypes.InverseDistanceSquare )
		{
			foreach( GameObject hbGameObject in hbGameObjectsList )
			{
				float distanceToGo = Vector3.Distance(transform.position, hbGameObject.transform.position);
				if( distanceToGo < gravityReach )
				{
					Vector3 forceDirection = transform.position - hbGameObject.transform.position;
					float distanceBetween = Mathf.Clamp(forceDirection.magnitude, 1.0f, gravityReach);
					distanceBetween = distanceBetween * distanceBetween;

					forceDirection.Normalize();
					Vector3 velocityToAdd = gravityPullStrength * distanceBetween * forceDirection;
					hbGameObject.GetComponent<PVA>().velocity += velocityToAdd;
				}
			}
		}

	}

	void OnDrawGizmos() 
	{
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, gravityReach);
    }


}
