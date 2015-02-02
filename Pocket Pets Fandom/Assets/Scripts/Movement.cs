using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


	public bool moveleft;
	public float movecounter;
	float LeftWall;
	float RightWall;
	GameObject Background;
	void Start () 
	{
		Background = GameObject.FindGameObjectWithTag("Wall");
		LeftWall = Background.transform.position.x - (Background.renderer.bounds.size.x / 3);
		RightWall = Background.transform.position.x + (Background.renderer.bounds.size.x / 3);
		moveleft = true;
		movecounter = 0;
	}
	
	void FixedUpdate () 
	{
		SideToSide();
		CheckPos();
	}
	void CheckPos()
	{
		if(this.gameObject.transform.position.x <= LeftWall || this.gameObject.transform.position.x >= RightWall)
		{
			flip();
			Wait();
		}
	}
	void SideToSide()
	{
		movecounter += 1 * Time.deltaTime;
		if (movecounter >= .99f)
		{
			//Transform newPos = this.transform.position;
			if(moveleft)
			{
				this.gameObject.transform.position = new Vector2(this.transform.position.x - .5f, this.transform.position.y) ;
			}
			else
			{
				this.gameObject.transform.position = new Vector2(this.transform.position.x + .5f, this.transform.position.y) ;
			}
			movecounter = 0;
		}
	}
	void flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		moveleft = !moveleft;
		if(moveleft)
		{
			this.gameObject.transform.position = new Vector2(this.transform.position.x - .5f, this.transform.position.y) ;
		}
		else
		{
			this.gameObject.transform.position = new Vector2(this.transform.position.x + .5f, this.transform.position.y) ;
		}
	}


	IEnumerator Wait() 
	{
		yield return new WaitForSeconds(1);
	}
}
