using UnityEngine;
using System.Collections;

public class BoardIcon : MonoBehaviour {

	// Use this for initialization
	public int Value;
	GameObject GameMaster;
	void Start () 
	{
		if(this.name == "Hat")
		{
			Value = 1;
		}
		else if(this.name == "Violin")
		{
			Value = 2;
		}
		else if(this.name == "Skull")
		{
			Value = 3;
		}
		else
		{
			Value = 4;
		}
		GameMaster = GameObject.FindGameObjectWithTag("MiniGameMaster");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnMouseDown()
	{
		print ("Lets try this");
		GameMaster.GetComponent<SymbokuGameMaster>().SetIcon(this.gameObject);
	}
}
