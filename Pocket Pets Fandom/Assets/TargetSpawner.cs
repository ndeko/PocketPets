using UnityEngine;
using System.Collections;

public class TargetSpawner : MonoBehaviour {

	// Use this for initialization
	public float timer = 5;
	public GameObject newTarget;
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(timer <= 0)
		{
			Instantiate(newTarget, this.transform.position,Quaternion.identity);
			timer = 10;
		}
		else
		{
			timer -= 1 * Time.deltaTime;
		}
	}
}
