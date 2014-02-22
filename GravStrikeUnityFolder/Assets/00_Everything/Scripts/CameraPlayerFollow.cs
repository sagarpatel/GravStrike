using UnityEngine;
using System.Collections;

public class CameraPlayerFollow : MonoBehaviour 
{
	[Range(0.1f, 50)]
	public float cameraPositionLerpMultiplier = 1.0f;

	[Range(0.1f, 50)]
	public float cameraZoomLerpMultiplier = 2.0f;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		GameObject[] playersGO = GameObject.FindGameObjectsWithTag("Player");

		// set position
		Vector3 averagePosition = new Vector3(0, 0, 0);
		float numberOfPlayer = 0;
		foreach( GameObject playerGO in playersGO )
		{
			averagePosition += playerGO.transform.position;
			numberOfPlayer += 1;
		}
		averagePosition = averagePosition/numberOfPlayer;
		averagePosition.z = 0;

		transform.position = Vector3.Lerp(transform.position, averagePosition, cameraPositionLerpMultiplier * Time.deltaTime);
		

		// set zoom
		/*
		Camera camera = gameObject.GetComponent<Camera>();

		// check if players are in Rect of camera
		// get planes that define camera frustrum
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
		bool areAllPlayersInCameraFrustrum = false;
		foreach( GameObject playerGO in playersGO )
		{
			// might be overkill to do 3D bounds check (looks like its testing all planes, but thats fine)
			areAllPlayersInCameraFrustrum |= GeometryUtility.TestPlanesAABB(planes, playerGO.collider.bounds);
		}
		Debug.Log(areAllPlayersInCameraFrustrum);	

		// zoom out if not in view
		if(areAllPlayersInCameraFrustrum == false)
		{
			camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, 2.0f * camera.orthographicSize, cameraZoomLerpMultiplier * Time.deltaTime);
		}
		else
		{
			camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, 0.75f * camera.orthographicSize, cameraZoomLerpMultiplier * Time.deltaTime);	
		}
		*/


	}


}
