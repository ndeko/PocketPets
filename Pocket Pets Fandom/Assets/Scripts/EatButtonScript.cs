using UnityEngine;
using System.Collections;

public class EatButtonScript : MonoBehaviour {

	public Sprite DefaultArt;
	public Sprite SelectedArt;
	private Camera MainCam;
	// Use this for initialization
	int OrderNumber = 2;
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
		Eat();
	}
	public void Select()
	{
		this.gameObject.GetComponent<SpriteRenderer>().sprite = SelectedArt;
	}
	public void Deselect()
	{
		this.gameObject.GetComponent<SpriteRenderer>().sprite = DefaultArt;
	}
	public void Eat()
	{
		GameObject.FindGameObjectWithTag("Pet").GetComponent<Pet>().Feed();
	}

}
