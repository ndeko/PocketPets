using UnityEngine;
using System.Collections;

public class SmallBoxSpawner : MonoBehaviour {

	public GameObject[] Markers;
	public GameObject NextMarker;
	void Start () 
	{
		NextMarker = Markers[Random.Range(0,Markers.Length)];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
