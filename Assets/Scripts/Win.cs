using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {
	public bool won;
	public Transform player;

	// Use this for initialization
	void Start () {
		won = false;
	}
	
	// Update is called once per frame
	void Update () {
		//if(transform.
	}

	void OnGUI() {
		if(won)GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "YOU GOT CAUGHT..");
	}
}
