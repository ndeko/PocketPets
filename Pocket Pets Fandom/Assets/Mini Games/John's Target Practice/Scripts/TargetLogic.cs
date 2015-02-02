using UnityEngine;
using System.Collections;

public class TargetLogic : MonoBehaviour {


	float counter = .5f;
	public GameObject nextMarker;
	public bool beenOnScreen;
	public AudioClip Hit;
	public AudioClip Bullseye;
	public AudioClip Move;
	AudioSource Aud;
	public Sprite Broken;

	void Start () 
	{
		Aud =  this.GetComponent<AudioSource>();
		Aud.clip = Move;
		beenOnScreen = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(counter <= 0)
		{
			this.gameObject.transform.position = Vector2.MoveTowards(this.transform.position, nextMarker.transform.position, 1f);
			counter = .5f;
			Aud.Play();
		}
		else
		{

			counter -= 1 * Time.deltaTime;
		}
	}
	void OnMouseDown()
	{
		this.collider2D.enabled = false;
		Vector2 mouseScreenPosition = Input.mousePosition;
		//mouseScreenPosition.z = Vector3.Distance(Camera.main.transform.position, this.transform.position);
		Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
		float distanceToCenter = Vector3.Distance(this.transform.position, mouseWorldPosition);

		GameObject GM = GameObject.FindGameObjectWithTag("MiniGameMaster");
		print(distanceToCenter.ToString());
		if(distanceToCenter <= .20)
		{
			GM.GetComponent<TargetGameMaster>().AddToScore();
			GM.GetComponent<TargetGameMaster>().AddToMultiplyer();
			StartCoroutine("BreakAndDestroy");
			AudioSource.PlayClipAtPoint(Bullseye, this.transform.position, .5f);
		}
		else 
		{
			GM.GetComponent<TargetGameMaster>().AddToScore();
			GM.GetComponent<TargetGameMaster>().ResetMultiplyer();
			StartCoroutine("BreakAndDestroy");

			AudioSource.PlayClipAtPoint(Hit, this.transform.position, 1f);
		}
		//GM.GetComponent<TargetGameMaster>().ReduceTargetsOnScreen();

	}
	IEnumerator BreakAndDestroy()
	{
		counter = 2;
		this.GetComponent<SpriteRenderer>().sprite = Broken;
		yield return new WaitForSeconds(.4f);
		GameObject GM = GameObject.FindGameObjectWithTag("MiniGameMaster");
		GM.GetComponent<TargetGameMaster>().ReduceTargetsOnScreen();
		Destroy(this.gameObject);
	}
	public void AddToCounter()
	{
		counter = 1.5f;
	}
	public void Suicide()
	{
		if(beenOnScreen)
		{
			GameObject GM = GameObject.FindGameObjectWithTag("MiniGameMaster");
			GM.GetComponent<TargetGameMaster>().ReduceTargetsOnScreen();
			Destroy(this.gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(!beenOnScreen)
		{
			if(col.gameObject.name == "spnSmallBox")
			{
				nextMarker = col.gameObject.GetComponent<SmallBoxSpawner>().NextMarker;
			}
			else
			{
				nextMarker = col.gameObject.GetComponent<Marker>().NextMarker;
			}
		}
		if(col.gameObject == nextMarker)
		{
			nextMarker = col.gameObject.GetComponent<Marker>().NextMarker;
		}
		beenOnScreen = true;
	}
}
