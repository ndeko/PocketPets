using UnityEngine;
using System.Collections;

public class Despawner : MonoBehaviour {

	// Use this for initialization
	private GameObject NextMarker;
	void Start () {
		NextMarker = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Target")
		{
			other.gameObject.GetComponent<TargetLogic>().Suicide ();
		}
	}
}
