using UnityEngine;
using System.Collections;
using System;
using System.IO;
//using System.Data;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
using System.Security.Cryptography;
public class SavingAndLoading : MonoBehaviour
{
	public class PetObject
	{
		public string Name;
		public int Energy;
		public int Hunger;
		public int Mood;
		public int Health;
		public int Attack;
		public int Speed;
		public Dictionary<string, int> Relationships;
		public string ShippedWith;

		
		public PetObject()
		{
			Name = "";
			Energy = 0;
			Hunger = 0;
			Mood = 0;
			Health = 0;
			Attack = 0;
			Speed = 0;
			//make on a second line under the pet. The loop will read 2 lines at a time
			//then with the split function it can seperate the name and stat again reading 2 at a time (i and i+1)
			Relationships = new Dictionary<string, int>();
			//ShippedWith = "";
		}
	}

	private string NewFile;
	private string SavedFile;
	private string UnENFile;
	byte[] DefaultKey = new byte[8] { 106, 211, 220, 200, 192, 104, 56, 146 };
	void Awake()
	{
		//must be put in awake to beat out GameMaster
		SavedFile = Application.streamingAssetsPath.ToString() + "/SaveFile.txt";
		NewFile = Application.streamingAssetsPath.ToString() + "/NewFile.txt";
		UnENFile = Application.streamingAssetsPath.ToString() + "/SaveFileTemplate.txt";
	}
	void Start()
	{
	}
	public bool CheckForSave()
	{
		//if file exists return true
		if(File.Exists(SavedFile))
		{
			return true;
		}
		return false;
	}
	//Will always load from "SavedFile"
	public void Load(List<PetObject> Pets)
	{
		//Gets a filestream to open and access the savefile
		using (FileStream fsInput = new FileStream(SavedFile, FileMode.Open, FileAccess.Read))
		{
			//Decrypts the encrypted file
			using (DESCryptoServiceProvider DES = new DESCryptoServiceProvider())
			{
				//Forces the Key and IV
				DES.Key = DefaultKey;
				DES.IV = DefaultKey;
				//the decryptor
				ICryptoTransform desencrypt = DES.CreateDecryptor();
				//now opens a stream wrapped in a filestream to read and decode the file
				using (CryptoStream cryptostream = new CryptoStream(fsInput, desencrypt, CryptoStreamMode.Read))
				{
					//creates a stream reader to read the actual data
					using (StreamReader STRead = new StreamReader(cryptostream))
					{
						//makes a string out of the current line
						string line;
						while((line = STRead.ReadLine()) != null)
						{
							//splits the line by 
							string[] spLines = line.Split(",".ToCharArray());
							PetObject NewPet = new PetObject();
							NewPet.Name = spLines[0].ToString();
							NewPet.Energy = int.Parse(spLines[1]);
							NewPet.Hunger = int.Parse(spLines[2]);
							NewPet.Mood= int.Parse(spLines[3]);
							NewPet.Health = int.Parse(spLines[4]);
							NewPet.Attack = int.Parse(spLines[5]);
							NewPet.Speed = int.Parse(spLines[6]);
							line = STRead.ReadLine();
							string[] PetRelationships = line.Split(",".ToCharArray());
							for (int i = 0; i < PetRelationships.Length -1 ; i++)
							{
								string[] relationship = PetRelationships[i].Split(":".ToCharArray());
								NewPet.Relationships.Add(relationship[0], int.Parse(relationship[1]));
							}
							Pets.Add(NewPet);
						}

					}
				}
			}
		}
	}
	//Will always Load from "NewFile"
	public void StartNewFile(List<PetObject> Pets)
	{
		print(NewFile);
		using (FileStream fsInput = new FileStream(NewFile, FileMode.Open, FileAccess.Read))
		{
			using (DESCryptoServiceProvider DES = new DESCryptoServiceProvider())
			{
				DES.Key = DefaultKey;
				DES.IV = DefaultKey;
				ICryptoTransform desencrypt = DES.CreateDecryptor();
				using (CryptoStream cryptostream = new CryptoStream(fsInput, desencrypt, CryptoStreamMode.Read))
				{
					using (StreamReader STRead = new StreamReader(cryptostream))
					{
						//makes a string out of the current line
						string line;
						while((line = STRead.ReadLine()) != null)
						{
							string[] spLines = line.Split(",".ToCharArray());
							PetObject NewPet = new PetObject();
							NewPet.Name = spLines[0].ToString();
							NewPet.Energy = int.Parse(spLines[1]);
							NewPet.Hunger = int.Parse(spLines[2]);
							NewPet.Mood= int.Parse(spLines[3]);
							NewPet.Health = int.Parse(spLines[4]);
							NewPet.Attack = int.Parse(spLines[5]);
							NewPet.Speed = int.Parse(spLines[6]);
							
							line = STRead.ReadLine();
							string[] PetRelationships = line.Split(",".ToCharArray());
							for (int i = 0; i < PetRelationships.Length - 1; i++)
							{
								string[] relationship = PetRelationships[i].Split(":".ToCharArray());
								NewPet.Relationships.Add(relationship[0], int.Parse(relationship[1]));
							}
							Pets.Add(NewPet);
						}
					}
				}
			}
		}
	}
	//Will always save to "SavedFile"
	public void Save(List<PetObject> Pets)
	{
		using (FileStream fsInput = new FileStream(SavedFile, FileMode.Create, FileAccess.Write))
		{

			using (DESCryptoServiceProvider DES = new DESCryptoServiceProvider())
			{

				DES.Key = DefaultKey;
				DES.IV = DefaultKey;
				ICryptoTransform desencrypt = DES.CreateEncryptor();
				using (CryptoStream cryptostream = new CryptoStream(fsInput, desencrypt, CryptoStreamMode.Write))
				{
					using(StreamWriter STWrite = new StreamWriter(cryptostream))
					{
						foreach (PetObject ThisPet in Pets)
						{

							STWrite.WriteLine("{0},{1},{2},{3},{4},{5},{6}",
							                  ThisPet.Name, ThisPet.Energy, ThisPet.Hunger,
							                  ThisPet.Mood, ThisPet.Health, ThisPet.Attack,
							                  ThisPet.Speed);
							string Relations= "";
							foreach(KeyValuePair<string, int> rel in ThisPet.Relationships)
							{
								Relations += rel.Key + ":" + rel.Value + ",";
							}
							STWrite.WriteLine(Relations);
						}   
					}
				}
			}
		}
	}
	//this is being used to read the new unencrypted save file. Should probably be saved for later
	public void CreateNewSave()
	{
		print(UnENFile);
		List<PetObject> Pets = new List<PetObject>();
		using (FileStream fsInput = new FileStream(UnENFile, FileMode.Open, FileAccess.Read))
		{
			using (StreamReader STRead = new StreamReader(fsInput))
			{
				//makes a string out of the current line
				string line;
				while((line = STRead.ReadLine()) != null)
				{
					//splits the line by 
					string[] spLines = line.Split(",".ToCharArray());
					PetObject NewPet = new PetObject();
					NewPet.Name = spLines[0].ToString();
					NewPet.Energy = int.Parse(spLines[1]);
					NewPet.Hunger = int.Parse(spLines[2]);
					NewPet.Mood= int.Parse(spLines[3]);
					NewPet.Health = int.Parse(spLines[4]);
					NewPet.Attack = int.Parse(spLines[5]);
					NewPet.Speed = int.Parse(spLines[6]);
					
					line = STRead.ReadLine();
					string[] PetRelationships = line.Split(",".ToCharArray());
					for (int i = 0; i < PetRelationships.Length -1; i++)
					{
						string[] relationship = PetRelationships[i].Split(":".ToCharArray());
						print (relationship[0] + " " + relationship[1]);
						NewPet.Relationships.Add(relationship[0], int.Parse(relationship[1]));
					}
					Pets.Add(NewPet);
				}
				Save(Pets);
				SaveToNew(Pets);
			}
		}
	}
	public void SaveToNew(List<PetObject> Pets)
	{
		using (FileStream fsInput = new FileStream(NewFile, FileMode.Create, FileAccess.Write))
		{
			using (DESCryptoServiceProvider DES = new DESCryptoServiceProvider())
			{
				DES.Key = DefaultKey;
				DES.IV = DefaultKey;
				ICryptoTransform desencrypt = DES.CreateEncryptor();
				using (CryptoStream cryptostream = new CryptoStream(fsInput, desencrypt, CryptoStreamMode.Write))
				{
					using(StreamWriter STWrite = new StreamWriter(cryptostream))
					{
						foreach (PetObject ThisPet in Pets)
						{
							
							STWrite.WriteLine("{0},{1},{2},{3},{4},{5},{6}",
							                  ThisPet.Name, ThisPet.Energy, ThisPet.Hunger,
							                  ThisPet.Mood, ThisPet.Health, ThisPet.Attack,
							                  ThisPet.Speed);
							string Relations= "";
							foreach(KeyValuePair<string, int> rel in ThisPet.Relationships)
							{
								Relations += rel.Key + ":" + rel.Value + ",";
							}
							STWrite.WriteLine(Relations);
						}   
					}
				}
			}
		}
	}

}