using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameMaster : MonoBehaviour {
	public GameObject LoadOption;
	// Use this for initialization
	SavingAndLoading SAL;
	//public Dictionary<string, string> book = new Dictionary<string, string>();
	public List<SavingAndLoading.PetObject> PetList = new List<SavingAndLoading.PetObject>();
	void Start () 
	{
		SAL = this.GetComponent<SavingAndLoading>();
		if(SAL.CheckForSave())
		{
			print ("File Found");
		}
		else
		{
			print ("File Not Found");
			Destroy(LoadOption);
		}
		DontDestroyOnLoad(this);
	}
	public void StartNewGame()
	{
		SAL.StartNewFile(PetList);
		SAL.Save(PetList);
		foreach(SavingAndLoading.PetObject Pet in PetList)
		{
			print(Pet.Name);
		}
		//Application.LoadLevel("Main");
	}

	public void ContinueGame()
	{
		PetList.Clear();
		SAL.Load(PetList);
		foreach(SavingAndLoading.PetObject Pet in PetList)
		{
			print(Pet.Name);
		}

	}
	// Update is called once per frame
	void Update () {
	
	}
}
