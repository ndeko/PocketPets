using UnityEngine;
using System.Collections;

public class PlayButtonScripts : MonoBehaviour {

	public Sprite DefaultArt;
	public Sprite SelectedArt;
	// Use this for initialization
	private Camera MainCam;
	 int OrderNumber = 1;
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
		PlayMiniGame();
	}
	public void Select()
	{
		this.gameObject.GetComponent<SpriteRenderer>().sprite = SelectedArt;
	}
	public void Deselect()
	{
		this.gameObject.GetComponent<SpriteRenderer>().sprite = DefaultArt;
	}


	public void PlayMiniGame()
	{
		//Play game
	}
	

}
