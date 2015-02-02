using UnityEngine;
using System.Collections;

public class MenuButtonScript : MonoBehaviour {

	// Use this for initialization
	public GameObject[] Buttons = new GameObject[6];
	public int SelectedIndex;
	public float InputTimer;
	void Start () 
	{
		InputTimer = .25f;
		SelectedIndex = 0;
		Select();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (InputTimer <= 0)
		{
		 	if(Input.GetAxis("Horizontal") > 0)
			{
				Deselect();
				if(SelectedIndex == 5)
				{
					SelectedIndex = 0;
				}
				else
				{
					SelectedIndex++;
				}
				Select();
			}
			else if(Input.GetAxis("Horizontal") < 0)
			{
				Deselect();
				if(SelectedIndex == 0)
				{
					SelectedIndex = 5;
				}
				else
				{
					SelectedIndex--;
				}
				Select();

			}
			/*else if(Input.GetAxis("HorizontalStick") > 0)
			{
				Deselect();
				if(SelectedIndex == 5)
				{
					SelectedIndex = 0;
				}
				else
				{
					SelectedIndex++;
				}
				Select();

			}
			else if(Input.GetAxis("HorizontalStick") < 0)
			{
				Deselect();
				if(SelectedIndex == 0)
				{
					SelectedIndex = 5;
				}
				else
				{
					SelectedIndex--;
				}
				Select();

			}*/
			else if(Input.GetAxis("HorizontalDpad") > 0)
			{
				Deselect();
				if(SelectedIndex == 5)
				{
					SelectedIndex = 0;
				}
				else
				{
					SelectedIndex++;
				}
				Select();

			}
			else if(Input.GetAxis("HorizontalDpad") < 0)
			{
				Deselect();
				if(SelectedIndex == 0)
				{
					SelectedIndex = 5;
				}
				else
				{
					SelectedIndex--;
				}
				Select();
			}
		}
		else if (InputTimer >= 0)
		{
			InputTimer-= Time.deltaTime;
		}

	}
	public void Select()
	{
		switch (SelectedIndex)
		{
		//Sleep
		case 0:
			Buttons[0].GetComponent<SleepButtonScript>().Select();
			break;
		//Play
		case 1:
			Buttons[1].GetComponent<PlayButtonScripts>().Select();
			break;
		//Eat
		case 2:
			Buttons[2].GetComponent<EatButtonScript>().Select();
			break;
		//Adventure
		case 3:
			Buttons[3].GetComponent<AdventureButtonScript>().Select();
			break;
		//Ships
		case 4:
			Buttons[4].GetComponent<ShipsButtonScript>().Select();
			break;
		//Stats
		case 5:
			Buttons[5].GetComponent<StatsButtonScript>().Select();
			break;
		}
		InputTimer = .4f;
	}
	public void Deselect()
	{
		switch (SelectedIndex)
		{
			//Sleep
		case 0:
			Buttons[0].GetComponent<SleepButtonScript>().Deselect();
			break;
			//Play
		case 1:
			Buttons[1].GetComponent<PlayButtonScripts>().Deselect();
			break;
			//Eat
		case 2:
			Buttons[2].GetComponent<EatButtonScript>().Deselect();
			break;
			//Adventure
		case 3:
			Buttons[3].GetComponent<AdventureButtonScript>().Deselect();
			break;
			//Ships
		case 4:
			Buttons[4].GetComponent<ShipsButtonScript>().Deselect();
			break;
			//Stats
		case 5:
			Buttons[5].GetComponent<StatsButtonScript>().Deselect();
			break;
		}
	}

	void ButtonPress()
	{

	}


}
