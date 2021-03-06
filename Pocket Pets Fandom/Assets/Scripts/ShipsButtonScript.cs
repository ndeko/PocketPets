﻿using UnityEngine;
using System.Collections;

public class ShipsButtonScript : MonoBehaviour {

	public Sprite DefaultArt;
	public Sprite SelectedArt;

	private Camera MainCam;
	 int OrderNumber = 4;

	// Use this for initialization
	void Start () 
	{
		MainCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void OnMouseOver()
	{
		MainCam.GetComponent<MenuButtonScript>().Deselect();
		MainCam.GetComponent<MenuButtonScript>().SelectedIndex = OrderNumber;
		MainCam.GetComponent<MenuButtonScript>().Select();
	}
	void OnMouseExit()
	{
		
	}
	void OnMouseDown()
	{
		ViewShips();
	}
	public void Select()
	{
		this.gameObject.GetComponent<SpriteRenderer>().sprite = SelectedArt;
	}
	public void Deselect()
	{
		this.gameObject.GetComponent<SpriteRenderer>().sprite = DefaultArt;
	}
	public void ViewShips()
	{
		//View Ships
	}
	

}
