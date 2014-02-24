using UnityEngine;
using System.Collections;

public class PathPreview : MonoBehaviour 
{

	PVA pva;

	Vector3[] pathArray;

	// Use this for initialization
	void Start () 
	{
		pva = gameObject.GetComponent<PVA>();
		pathArray = new Vector3[10];

		for(int i = 0; i < pathArray.Length; i++)
		{
			pathArray[i] = transform.position;
		}

	}
	
	// Update is called once per frame
	void Update () 
	{


	
	}

	public Vector3 CalculateNextPosition( Vector3 startPosition )
	{
		
	}


}
