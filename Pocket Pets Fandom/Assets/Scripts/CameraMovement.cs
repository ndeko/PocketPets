using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	float cameraMoveSpeed = 5f;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.A))
		{
			Camera.main.transform.position += Vector3.left * Time.deltaTime * cameraMoveSpeed;
		}
		if(Input.GetKey(KeyCode.W))
		{
			Camera.main.transform.position += Vector3.up * Time.deltaTime * cameraMoveSpeed;
		}
		if(Input.GetKey(KeyCode.D))
		{
			Camera.main.transform.position += Vector3.right * Time.deltaTime * cameraMoveSpeed;
		}		
		if(Input.GetKey(KeyCode.S))
		{
			Camera.main.transform.position += Vector3.down * Time.deltaTime * cameraMoveSpeed;
		}
		if(Input.GetMouseButton(1))
		{
			Camera.main.orthographicSize = 4.5f;
			cameraMoveSpeed = 3.5f;
		}
		else
		{
			Camera.main.orthographicSize = 6f;
			cameraMoveSpeed = 5f;
		}
	}
}
