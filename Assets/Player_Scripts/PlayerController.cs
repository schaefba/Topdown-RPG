using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float Speed;


	void Update()
	{

		if(Input.GetKey(KeyCode.A)) //left
		{
			transform.Translate(-Vector2.right * Speed);
		}
		else if(Input.GetKey(KeyCode.D)) //right
		{
			transform.Translate(Vector2.right * Speed);
		}
		else if(Input.GetKey(KeyCode.S)) //down
		{
			transform.Translate(-Vector2.up * Speed);
		}
		else if(Input.GetKey(KeyCode.W)) //up
		{
			transform.Translate(Vector2.up * Speed);
		}
	}
}

