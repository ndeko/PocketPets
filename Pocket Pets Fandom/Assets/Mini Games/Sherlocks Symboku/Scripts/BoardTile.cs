using UnityEngine;
using System.Collections;

public class BoardTile : MonoBehaviour {

	public int row;
	public int col;
	public bool Changeable;
	void Awake()
	{
		row = int.Parse(this.gameObject.transform.parent.gameObject.name.ToString());
		col = int.Parse(this.gameObject.name);
		Changeable = true;
	}
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{
		print("Tile Clicked");
		GameObject.FindGameObjectWithTag("MiniGameMaster").GetComponent<SymbokuGameMaster>().SetTile(this.gameObject);
	}
}
