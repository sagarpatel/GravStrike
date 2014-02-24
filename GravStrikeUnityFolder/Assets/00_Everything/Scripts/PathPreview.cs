using UnityEngine;
using System.Collections;
using System.Reflection;

public class PathPreview : MonoBehaviour 
{

	public GameObject pathPreviewNodePrefab;
	public int frameBetweenNodes = 10;
	GameObject[] pathPreviewNodesArray;

	// Use this for initialization
	void Start () 
	{

		pathPreviewNodesArray = new GameObject[10];

		for(int i = 0; i < pathPreviewNodesArray.Length; i++)
		{
			pathPreviewNodesArray[i] = (GameObject)Instantiate(pathPreviewNodePrefab, transform.position, Quaternion.identity);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		for(int i = 0; i < pathPreviewNodesArray.Length; i++)
		{

			if(i == 0)
			{
				CopyPVAValues( pathPreviewNodesArray[i], transform.root.gameObject );
				pathPreviewNodesArray[i].GetComponent<PVA>().isPathPreviewNode = true;
			}
			else
			{
				CopyPVAValues( pathPreviewNodesArray[i], pathPreviewNodesArray[i-1]);
			}

			// Loop through a few frames of simulation
			for(int j = 0; j < frameBetweenNodes; j ++)
			{	
				// get gravity
				foreach( GameObject gsGO in GameObject.FindGameObjectsWithTag("GravitySource") )	
				{
					gsGO.GetComponent<GravitySource>().ApplyGravity( pathPreviewNodesArray[i] );
				}
				// apply PVA
				pathPreviewNodesArray[i].GetComponent<PVA>().ApplyPVA();
			}

		}
	
	}


	// Trying to use reflection to copy copmonent/class/object values over
	// as see on --> http://answers.unity3d.com/questions/458207/copy-a-component-at-runtime.html
	void CopyPVAValues(GameObject intoGO, GameObject fromGo)
	{
		PVA intoPVA = intoGO.GetComponent<PVA>();
		PVA fromPVA = fromGo.GetComponent<PVA>();

		System.Type type = intoPVA.GetType();
		System.Reflection.FieldInfo[] fields = type.GetFields();

		foreach (System.Reflection.FieldInfo field in fields)
	    {
	       field.SetValue(intoPVA, field.GetValue(fromPVA));
	    }

	}

}
