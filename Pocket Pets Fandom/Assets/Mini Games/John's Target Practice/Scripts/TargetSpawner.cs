using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TargetSpawner : MonoBehaviour {

	// Use this for initialization
	public float spawnTime;
	public GameObject target;
	public GameObject childTarget;

	void Start () 
	{

		childTarget = null;
	}
	
	void Update () 
	{	

	}
	public bool HasTarget()
	{
		if (this.childTarget != null)
		{
			return true;
		}
		return false;
	}
	public void Spawn()
	{
		childTarget = (Instantiate(target,this.transform.position,Quaternion.identity) as GameObject);
	}
}
