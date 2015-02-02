using UnityEngine;
using System.Collections;

public class TargetGameMaster : MonoBehaviour 
{
	private const int TOTAL_TARGETS = 10;
	public float RoundTimer = 3;
	public int Multiplyer;
	public int Score;
	public int TargetsOnScreen;
	public int TargetsLeft;
	public GameObject[] Spawners = new GameObject[5];
	AudioSource Aud;
	public AudioClip Shot;
	// Use this for initialization
	void Start () 
	{
		print("test");
		Aud =  this.GetComponent<AudioSource>();
		Aud.clip = Shot;
		Spawners = GameObject.FindGameObjectsWithTag("Spawner");
		TargetsLeft = TOTAL_TARGETS;
		TargetsOnScreen = 0;
		Multiplyer = 1;
		Score = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(TargetsOnScreen == 0)
		{
			if(RoundTimer <= 0)
			{
				while(TargetsOnScreen < 2)
				{
					GameObject ChosenSpawner = Spawners[Random.Range(0,Spawners.Length -1)];
					if(!ChosenSpawner.GetComponent<TargetSpawner>().HasTarget())
					{
						ChosenSpawner.GetComponent<TargetSpawner>().Spawn();
						TargetsOnScreen++;
					}
					RoundTimer = 3;
				}
			}
			else
			{
				RoundTimer -= 1 * Time.deltaTime;
			}
		}
		if(Input.GetMouseButtonDown(0))
		{
			Aud.Play();
		}

	}
	public void AddToScore()
	{
		Score += 10 * Multiplyer;
		this.GetComponent<TargetGui>().UpdateScore(Score, Multiplyer);
	}
	public void AddToMultiplyer()
	{
		Multiplyer++;
		this.GetComponent<TargetGui>().UpdateScore(Score, Multiplyer);
	}
	public void ResetMultiplyer()
	{
		Multiplyer = 1;
		this.GetComponent<TargetGui>().UpdateScore(Score, Multiplyer);
	}
	public void ReduceTargetsOnScreen()
	{
		TargetsOnScreen--;
	}
}
