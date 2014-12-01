using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(animator)
		{
			if(Input.GetKey(KeyCode.A)) //left
			{
				animator.SetBool("run_left", true);
				animator.SetBool("idle", false);
				animator.SetBool("run_right", false);
				animator.SetBool("run_down", false);
				animator.SetBool("run_up", false);
				//Debug.Log ("left");
			}
			else if(Input.GetKey(KeyCode.D)) //right
			{
				animator.SetBool("run_right", true);
				animator.SetBool("idle", false);
				animator.SetBool("run_left", false);
				animator.SetBool("run_down", false);
				animator.SetBool("run_up", false);
				//Debug.Log ("right");
			}
			else if(Input.GetKey(KeyCode.S)) //down
			{
				animator.SetBool("run_down", true);
				animator.SetBool("idle", false);
				animator.SetBool("run_right", false);
				animator.SetBool("run_left", false);
				animator.SetBool("run_up", false);
				//Debug.Log ("down");
			}
			else if(Input.GetKey(KeyCode.W)) //up
			{
				animator.SetBool("run_up", true);
				animator.SetBool("idle", false);
				animator.SetBool("run_right", false);
				animator.SetBool("run_down", false);
				animator.SetBool("run_left", false);
				//Debug.Log ("up");
			}
			else //idle
			{
				animator.SetBool("idle", true);
				animator.SetBool("run_left", false);
				animator.SetBool("run_right", false);
				animator.SetBool("run_down", false);
				animator.SetBool("run_up", false);
				//Debug.Log ("idle");
			}
		}
	}
}
