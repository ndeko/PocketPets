using UnityEngine;
using System.Collections;

public class TargetGui : MonoBehaviour {

	// Use this for initialization
	public Texture2D bgImage;
	public Texture2D fgImage;
	public GUIStyle stats = new GUIStyle ();
	int score;
	int multiplyer;

	//the GUI scale ratio  
	private float guiRatio; 
	private float sHeight; 
	private Vector3 GUIsF;
	void Start () 
	{
		score = 0;
		multiplyer = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//get the screen's width  
		sHeight = Screen.height;  
		//calculate the scale ratio  
		guiRatio = sHeight/600;  
		//create a scale Vector3 with the above ratio  
		GUIsF = new Vector3(guiRatio,guiRatio,1);
	}
	void OnGUI()
	{
		GUI.matrix = Matrix4x4.TRS(new Vector3(Screen.width/2f - Screen.width/2f * GUIsF.x, Screen.height - Screen.height*GUIsF.y - Screen.height/30f, 0f)
		                           ,Quaternion.identity,
		                           GUIsF);
		
		
		GUI.BeginGroup (new Rect (Screen.width/2 - 350, Screen.height - 80, 200, 80));
		GUI.DrawTexture (new Rect (0, 0, 200, 50), bgImage);
		GUI.Label (new Rect (12, 5, 150, 40), "Score: " + score.ToString(), stats);
		GUI.Label (new Rect (10, 25, 150, 40), "Multiplyer: " + multiplyer.ToString(), stats);
		GUI.EndGroup ();
		//GUI.matrix = Matrix4x4.TRS (new Vector3 (Screen.width / 2 - Screen.width / 2 * GUIsF.x, GUIsF.y, 0), Quaternion.identity, GUIsF);

	}
	public void UpdateScore(int NewScore, int NewMultiplier)
	{
		score = NewScore;
		multiplyer = NewMultiplier;
	}
}
