using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	float health = 100, barDisplay = 0;
	Vector2 pos = new Vector2(20, 40), size = new Vector2(60, 20);
	Texture2D progressBarEmpty, progressBarFull;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI () {
		//draw the background
		GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
			GUI.Box(new Rect(0, 0, size.x, size.y), progressBarEmpty);

			//draw the filled-in part
			GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
				GUI.Box(new Rect(0, 0, size.x, size.y), progressBarFull);
			GUI.EndGroup();
		GUI.EndGroup();
	}
}
