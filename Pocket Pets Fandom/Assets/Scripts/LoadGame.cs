﻿using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnMouseDown()
	{
		GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>().ContinueGame();
	}

}
