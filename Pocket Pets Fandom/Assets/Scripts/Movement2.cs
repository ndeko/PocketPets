using UnityEngine;
using System.Collections;

public class Movement2 : MonoBehaviour
{

	int idlestate;
	protected Animator animator;
	
	public bool moveLeft;
	public bool waitActive;
	public float movecounter;
	
	void Start()
	{
		moveLeft = true;
		animator = GetComponent<Animator>();
	}

	void Update () 
	{
		CheckPos ();
		sideToSide ();
		if(animator)
		{
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

			if(stateInfo.nameHash == Animator.StringToHash("Base Layer.JohnIdle"))
			{
				if(idlestate == 0)
				{
					animator.SetBool("Clench", true);
				}

				if(idlestate == 1)
				{
					animator.SetBool("Foot", true);
				}

				if(idlestate == 2)
				{
					animator.SetBool("Look", true);
				}
			}
			else
			{
				idlestate = Random.Range(0, 3);
				animator.SetBool("Clench", false);
				animator.SetBool("Foot", false);
				animator.SetBool("Look", false);
				animator.SetBool("MoveR", false);
				animator.SetBool("MoveL", false);
			}
		}
	}

	void CheckPos()
	{
		if(this.gameObject.transform.position.x <= -2)
		{
			moveLeft = false;
		}
		else if (this.gameObject.transform.position.x >=2)
		{
			moveLeft = true;
		}
	}

	void sideToSide()
	{
		movecounter += 1 * Time.deltaTime;
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo (0);
		if(movecounter >= 10f && moveLeft)
		{
			animator.SetBool ("MoveR", true);
			if(animation.IsPlaying("MoveRight"))
			{
				this.gameObject.transform.position = new Vector2(this.transform.position.x - .5f, this.transform.position.y);				
			}

			movecounter = 0;
		}
	}
}
