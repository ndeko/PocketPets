using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


	public bool moveleft;
	public float movecounter;

	void Start () 
	{
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
		if(this.gameObject.transform.position.x <= -2 || this.gameObject.transform.position.x >=2)
		{
			flip();
			Wait();
		}
	}
	void SideToSide()
	{
		movecounter += 1 * Time.deltaTime;
		if (movecounter >= .82f)
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

	/*void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Wall")
		{
			flip();
		}
	}*/
	IEnumerator Wait() 
	{
		yield return new WaitForSeconds(2);
	}
}
