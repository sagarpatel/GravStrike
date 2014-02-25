using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	GameObject[] players;
	public float camSizeAdjust;

	void Start () 
	{
		players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	void Update () 
	{
		Bounds box = new Bounds(gameObject.transform.position, new Vector3(1,1,1));
		foreach (GameObject p in players)
		{
			box.Encapsulate(p.transform.position);
		}
		camera.transform.position = new Vector3(box.center.x, box.center.y, -100);
//		camera.orthographicSize = box.size.x / camSizeAdjust;

	}
}
