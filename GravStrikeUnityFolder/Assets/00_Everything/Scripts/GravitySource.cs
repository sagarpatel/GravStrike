using UnityEngine;
using System.Collections;

public class GravitySource : MonoBehaviour 
{

	[Range(1,10)]
	public float gravityReach = 2.0f;
	public enum rotationTypes
	{
		ClockWise, CounterClockWise
	}
	public rotationTypes gravityRotation;

	GameObject[] gameObjectsInReach;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		GetGameObjectsInReach();
	}

	void GetGameObjectsInReach()
	{
		HiggsBoson[] goHBArray = GameObject.FindObjectsOfType(typeof(HiggsBoson)) as HiggsBoson[] ;
		//Debug.Log(goHBArray);
		for(int i = 0; i< goHBArray.Length; i ++)
		{
			GameObject higgBosonGO = goHBArray[i].transform.gameObject;
			//Debug.Log(higgBosonGO);
		}


	}

	void OnDrawGizmosSelected() 
	{
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, gravityReach);
    }


}
