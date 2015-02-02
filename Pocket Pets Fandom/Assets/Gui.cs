using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour 
{

	// Use this for initialization
	public GameObject myPet;
	public Texture2D bgImage;
	public Texture2D fgImage;
	public GUIStyle stats = new GUIStyle ();
	public GUIStyle btns = new GUIStyle ();
	float barSize;
	float barSize2;

	//the GUI scale ratio  
	private float guiRatio; 
	private float sHeight; 
	private Vector3 GUIsF;

	void Start ()
	{
		myPet = GameObject.FindGameObjectWithTag("Pet");
		barSize = 150; 

	}
	
	// Update is called once per frame
	void Update () 
	{
		barSize = myPet.GetComponent<Pet>().hunger;
		barSize2 = myPet.GetComponent<Pet>().happy;

		//get the screen's width  
		sHeight = Screen.height;  
		//calculate the scale ratio  
		guiRatio = sHeight/600;  
		//create a scale Vector3 with the above ratio  
		GUIsF = new Vector3(guiRatio,guiRatio,1);

	}

	void OnGUI()
	{
		GUI.matrix = Matrix4x4.TRS(new Vector3(Screen.width/2 - Screen.width/2*GUIsF.x, Screen.height - Screen.height*GUIsF.y,0),Quaternion.identity,GUIsF);


		GUI.BeginGroup (new Rect (Screen.width/2 - 200, Screen.height - 80, 150, 40));
		GUI.DrawTexture (new Rect (0, 0, 150, 40), bgImage);
		GUI.BeginGroup (new Rect (0, 0, barSize, 40));
		GUI.DrawTexture (new Rect (0, 0, 150, 40), fgImage);
		GUI.EndGroup ();
		GUI.EndGroup ();
		GUI.Label (new Rect (Screen.width/2 - 200, Screen.height - 80, 150, 40), "Hunger", stats);

		GUI.BeginGroup (new Rect (Screen.width/2 + 50, Screen.height - 80, 150, 40));
		GUI.DrawTexture (new Rect (0, 0, 150, 40), bgImage);
		GUI.BeginGroup (new Rect (0, 0, barSize2, 40));
		GUI.DrawTexture (new Rect (0, 0, 150, 40), fgImage);
		GUI.EndGroup ();
		GUI.EndGroup ();
		GUI.Label (new Rect (Screen.width/2 + 50, Screen.height - 80, 150, 40), "Happy", stats);


		GUI.matrix = Matrix4x4.TRS (new Vector3 (Screen.width / 2 - Screen.width / 2 * GUIsF.x, GUIsF.y, 0), Quaternion.identity, GUIsF);



		if(GUI.Button(new Rect(10, 10, 200, 100), "Feed", btns))
		{
			myPet.GetComponent<Pet>().Feed();
		}
		if(GUI.Button(new Rect(Screen.width - 210, 10, 200, 100), "Play", btns))
		{
			myPet.GetComponent<Pet>().Play();
		}

		/*
		if(GUI.Button(new Rect(Screen.width - 105, Screen.height - 55, 100, 50), "Save", btns))
		{
			myPet.GetComponent<SavingAndLoading>().SaveData(myPet);
		}
		*/
	}
}
