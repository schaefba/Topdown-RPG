using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float Speed;
	public float MaxHealth;
	public float Health { get; private set; }
	public bool IsDead { get; private set; }
	private GUIBarScript healthBar;
	bool hit = false;
	Vector2 hitDir = Vector2.zero;
	int hits = 0;

	void Awake()
	{
		Health = MaxHealth;
		GameObject go = GameObject.Find("HeartsBar");
        healthBar = (GUIBarScript)go.GetComponent(typeof(GUIBarScript));
	}

	void Update()
	{
		healthBar.Value = Health;
		if(hit == true){
			transform.Translate(hitDir * Speed);
			hits++;
			if (hits > 12){
				hits=0;
				hit=false;

			}
			else{
				return;
			}
		}
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

	public void TakeDamage(float damage, Vector2 dir)
	{
		Health -= damage;
		hit = true;
		hitDir = dir;
		if(Health <= 0)
		{

		}
	}
}

