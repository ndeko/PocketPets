using UnityEngine;
using System.Collections;
public class Pet : MonoBehaviour 
{
	public const float STATMAX = 100;
	public const float addToStat = 10;
	public const float multiplier = .1f;

	public float hunger;
	public float sleep;
	public float happy;
	// Use this for initialization
	void Start () 
	{
		if(hunger < 0)
		{
			hunger = 50;
		}
		if(happy < 0)
		{
			happy = 50;
		}
	}
	// Update is called once per frame
	void Update () 
	{
		ApplyTime();
	}

	void ApplyTime()
	{
		if(hunger > 15)
		{
			hunger -=  multiplier * Time.deltaTime;
		}
		if(sleep > 15)
		{
			sleep -=  multiplier * Time.deltaTime;
		}
		if(happy > 15)
		{
			happy -= multiplier * Time.deltaTime;
		}
	} 

	private void GetDictionary()
	{
		GameObject GM = GameObject.FindGameObjectWithTag("GameMaster");

	}
	public void Feed()
	{
		if((hunger + addToStat) < STATMAX)
		{
			hunger += addToStat;
		}
		else if((hunger + addToStat) >= STATMAX)
		{
			hunger = STATMAX;
		}
	}


	public void Play()
	{
		if((happy + addToStat) < STATMAX)
		{
			happy += addToStat;
		}
		else if((happy + addToStat) >= STATMAX)
		{
			happy = STATMAX;
		}
	}
	public void Sleep()
	{
		if((sleep + addToStat) < STATMAX)
		{
			sleep += addToStat;
		}
		else if((sleep + addToStat) >= STATMAX)
		{
			sleep = STATMAX;
		}

	}
}
