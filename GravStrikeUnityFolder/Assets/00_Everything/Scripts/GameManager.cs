using UnityEngine;
using System.Collections;
using InControl;

public class GameManager : MonoBehaviour 
{

	void Start () 
	{
		InputManager.Setup();
		InputManager.AttachDevice( new UnityInputDevice( new FPSProfile() ) );
	}
	
	void Update () 
	{
		
		InputManager.Update();

	}


}
