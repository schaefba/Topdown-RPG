using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Depth : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		SpriteRenderer sp1 = transform.GetComponent<SpriteRenderer>();
		SpriteRenderer sp2 = collider.transform.GetComponent<SpriteRenderer>();

		if(transform.position.y > collider.transform.position.y) {
			sp1.sortingOrder = 0; //in back
			sp2.sortingOrder = 1; //in front
		}
		else
		{
			sp1.sortingOrder = 1; //in front
			sp2.sortingOrder = 0; //in back
		}

		/*List<Transform> tList = new List<Transform>();
		tList.Add(transform);
		tList.Add(collider.transform);

		tList.Sort(delegate(Transform sprite1, Transform sprite2) {
			return sprite1.position.y.CompareTo(sprite2.position.y);
		});

		for(int i = tList.Length - 1; i >= 0 ; i--){
			SpriteRenderer sp = tList[i].GetComponent<SpriteRenderer>();
			sp.sortingOrder = i;
		}*/

		/*foreach(Transform t in tList) {
			SpriteRenderer sp = t.GetComponent<SpriteRenderer>();
			sp.sortingOrder = tList.IndexOf(t);
		}*/
		//transform.position = new Vector3(transform.position.x, transform.position.y, collider.rigidbody.position.z + 1);
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		Debug.Log("on trigger exit");
		//transform.position = new Vector3(transform.position.x, transform.position.y, collider.rigidbody.position.z - 1);
	}
}
