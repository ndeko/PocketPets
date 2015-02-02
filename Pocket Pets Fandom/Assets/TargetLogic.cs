using UnityEngine;
using System.Collections;

public class TargetLogic : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//print("ok");
	}

	void OnMouseDown()
	{
		Destroy(this.gameObject);
	}
}
