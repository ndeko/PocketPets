using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour 
{

	// Use this for initialization
	public GameObject myPet;
	public Texture2D fgImage;
	public GUIStyle stats = new GUIStyle ();
	public GUIStyle btns = new GUIStyle (); 
	float EnergyBarSize;
	float MoodBarSize;
	float hungerBarSize;
	//the GUI scale ratio  
	private float guiRatio; 
	private float sHeight; 
	private Vector3 GUIsF;

	void Start ()
	{
		myPet = GameObject.FindGameObjectWithTag("Pet");
		hungerBarSize = myPet.GetComponent<Pet>().hunger;
		MoodBarSize = myPet.GetComponent<Pet>().happy;
		EnergyBarSize = myPet.GetComponent<Pet>().sleep;

	}
	
	// Update is called once per frame
	void Update () 
	{
		hungerBarSize = myPet.GetComponent<Pet>().hunger;
		MoodBarSize = myPet.GetComponent<Pet>().happy;
		EnergyBarSize = myPet.GetComponent<Pet>().sleep;

		//get the screen's width  
		sHeight = Screen.height;  
		//calculate the scale ratio  
		guiRatio = sHeight/600;  
		//create a scale Vector3 with the above ratio  
		GUIsF = new Vector3(guiRatio,guiRatio,1);

	}

	void OnGUI()
	{
		//GUI.matrix = Matrix4x4.TRS(new Vector3(0f,0f, 0f),Quaternion.identity,GUIsF);

		GUI.matrix = Matrix4x4.TRS(new Vector3(Screen.width/2f - Screen.width/2f * GUIsF.x, Screen.height  - Screen.height * GUIsF.y, 0f)
		                           ,Quaternion.identity,
		                           GUIsF);
		
		


		GUI.BeginGroup (new Rect (Screen.width/2 - 136, Screen.height - 507, 150, 12));
		GUI.BeginGroup (new Rect (0, 0, 140, 12));
		GUI.DrawTexture (new Rect (0, 0, EnergyBarSize -18, 12), fgImage);
		GUI.EndGroup ();
		GUI.EndGroup ();

		
		GUI.BeginGroup (new Rect (Screen.width/2 + 20,Screen.height - 507, 150, 12));
		GUI.BeginGroup (new Rect (0, 0, 140, 12));
		GUI.DrawTexture (new Rect (0, 0, MoodBarSize -18, 12), fgImage);
		GUI.EndGroup ();
		GUI.EndGroup ();

		GUI.BeginGroup (new Rect (Screen.width/2 + 197,Screen.height - 507, 150, 12));
		GUI.BeginGroup (new Rect (0, 0, 140, 12));
		GUI.DrawTexture (new Rect (0, 0, hungerBarSize -18, 12), fgImage);
		GUI.EndGroup ();
		GUI.EndGroup ();

		
		/*if(GUI.Button(new Rect(Screen.width/2 - 240, 10, 200, 100), "Feed", btns))
		{
			myPet.GetComponent<Pet>().Feed();
		}
		if(GUI.Button(new Rect(Screen.width/2 + 50, 10, 200, 100), "Play", btns))
		{
			myPet.GetComponent<Pet>().Play();
		}*/
	}
}
