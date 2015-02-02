using UnityEngine;
using System.Collections;
public class Pet : MonoBehaviour 
{
	public const float STATMAX = 150;
	public const float addToStat = 10;
	public const float multiplier = .1f;

	public float hunger;
	public float sleep;
	public float happy;
	// Use this for initialization
	void Start () 
	{
		this.GetComponent<SavingAndLoading>().loadOrSetup(this.gameObject);
		if(hunger < 15)
		{
			hunger = 15;
		}
		if(happy < 15)
		{
			happy = 15;
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

	/*Baisc Feed function. Checks when feeding that the "fullness"
	 * Doesn't exceed the Max
	 * 
	 */
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
}
