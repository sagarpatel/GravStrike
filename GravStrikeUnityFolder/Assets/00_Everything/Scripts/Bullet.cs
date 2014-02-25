using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int playerIndex;
	PVA pva;
	public float selfDestroyWait;

	void Start () 
	{
		StartCoroutine (KillTimer());
	}

	void Update () 
	{

	}

	IEnumerator KillTimer ()
	{
		yield return new WaitForSeconds(selfDestroyWait);
		Destroy(gameObject);
	}
}
