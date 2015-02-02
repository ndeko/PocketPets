using UnityEngine;
using System.Collections;
using System;
public class SavingAndLoading : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void loadOrSetup(GameObject currentPet)
	{
		if(PlayerPrefs.HasKey("hunger") && PlayerPrefs.HasKey("happy"))
		{
			LoadData(currentPet);
		}
		else
		{
			//fix later
			Setup(currentPet, 150);
		}
	}


	public void Setup(GameObject currentPet, float Max)
	{
		if(PlayerPrefs.HasKey("hunger") && PlayerPrefs.HasKey("happy"))
		{
			 currentPet.GetComponent<Pet>().hunger = PlayerPrefs.GetFloat("hunger");
			currentPet.GetComponent<Pet>().happy = PlayerPrefs.GetFloat("happy" );
		}
		else
		{
			currentPet.GetComponent<Pet>().hunger = Max;
			PlayerPrefs.SetFloat("hunger", Max);

			currentPet.GetComponent<Pet>().happy = Max;
			PlayerPrefs.SetFloat("happy", Max);
		}
	}



	public void SaveData(GameObject currentPet)
	{
		PlayerPrefs.SetFloat("hunger", currentPet.GetComponent<Pet>().hunger);
		PlayerPrefs.SetFloat("happy", currentPet.GetComponent<Pet>().happy);
		PlayerPrefs.SetString("timeSinceLastPlay", System.DateTime.Now.ToString());
		PlayerPrefs.Save();
	}



	public void LoadData(GameObject currentPet)
	{
			DateTime lastPlay = Convert.ToDateTime(PlayerPrefs.GetString("timeSinceLastPlay"));
			TimeSpan timeDifference = DateTime.Now.Subtract(lastPlay);
			int difference = Convert.ToInt32(timeDifference.TotalSeconds);
			currentPet.GetComponent<Pet>().hunger = (PlayerPrefs.GetFloat("hunger") - ((float)difference / 10));
			currentPet.GetComponent<Pet>().happy = PlayerPrefs.GetFloat("happy") - ((float)difference / 10);
	}



	public void OnApplicationQuit()
	{
		SaveData(this.gameObject);
	}

}
