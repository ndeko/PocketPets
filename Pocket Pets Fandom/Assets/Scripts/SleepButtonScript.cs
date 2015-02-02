using UnityEngine;
using System.Collections;

public class SleepButtonScript : MonoBehaviour {

	// Use this for initialization
	public Sprite DefaultArt;
	public Sprite SelectedArt;
	private Camera MainCam;
	int OrderNumber = 0;
	void Start () 
	{
		MainCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public void RestPet()
	{
		GameObject.FindGameObjectWithTag("Pet").GetComponent<Pet>().Sleep();
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
		RestPet();
	}
	public void Select()
	{
		this.gameObject.GetComponent<SpriteRenderer>().sprite = SelectedArt;
	}
	 public void Deselect()
	{
		this.gameObject.GetComponent<SpriteRenderer>().sprite = DefaultArt;
	}
}
