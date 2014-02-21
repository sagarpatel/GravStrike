using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GravitySource : MonoBehaviour 
{

	[Range(1,10)]
	public float gravityReach = 2.0f;
	public enum rotationTypes
	{
		ClockWise, CounterClockWise
	}
	public rotationTypes gravityRotation;

	public List<GameObject> gameObjectsInReach;

	// Use this for initialization
	void Start () 
	{
		gameObjectsInReach = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetGameObjectsInReach();
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

	void OnDrawGizmosSelected() 
	{
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, gravityReach);
    }


}
