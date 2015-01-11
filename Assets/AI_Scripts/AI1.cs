using UnityEngine;
using System.Collections;
using System.Threading;

public class AI1 : MonoBehaviour {

	private Vector3 _player;
	private Vector2 _playerDir;
	private float _xDif;
	private float _yDif;
	private int _wall;
	private float _distance;
	private bool _stun;
	private float _stunTime;
	private Animator animator;

	public float Speed;
	/// <summary>
	/// Line of sight of Enemy
	/// </summary>
	public float RayCastDistance;
	/// <summary>
	/// Distance which the enemy notices the player
	/// </summary>
	public float SpotRadius;

	void Start() {
		_wall = 1 << 8; //bit mask to get User Layer 8
		_stun = false;
		_stunTime = 0;
		animator = GetComponent<Animator>();
		animator.SetBool("idle", true);
		animator.SetBool("run", false);
	}

	void Update () {
		_player = GameObject.Find("Player").transform.position;
		_distance = Vector2.Distance(transform.position, _player);
		//animator.bodyRotation

		if(_stunTime > 0) {
			_stunTime -= Time.deltaTime;
		}
		else{
			_stun = false;
		}

		if(_distance < SpotRadius && !_stun) {
			animator.SetBool("idle", false);
			animator.SetBool("run", true);
			_xDif = _player.x - transform.position.x;
			_yDif = _player.y - transform.position.y;
			_playerDir = new Vector2(_xDif, _yDif);
			//Debug.DrawRay(transform.position, _playerDir);

			if(!Physics2D.Raycast(transform.position, _playerDir, RayCastDistance, _wall)) 
			{
				//TODO: find better way - shouldn't have to put mass of 10k on player
				float step = Speed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, _player, step);
			}
		}
		else //AI outside of spot distance - make him idle
		{
			animator.SetBool("idle", true);
			animator.SetBool("run", false);
		}
	}

	void OnCollisionEnter2D(Collision2D objectHit) {
		if(objectHit.gameObject.tag == "Player") {
			_stun = true;
			_stunTime = 1;
			PlayerController pc = (PlayerController)objectHit.gameObject.GetComponent(typeof(PlayerController));

			Vector2 dir = ( objectHit.transform.position - this.transform.position).normalized;
			pc.TakeDamage(0.1f,dir);    
            
			//objectHit.rigidbody.velocity
			//objectHit.rigidbody.velocity = Vector2.zero;
			//objectHit.rigidbody.angularVelocity = 0f;
			animator.SetBool("idle", true);
			animator.SetBool("run", false);
		}
	}
}
