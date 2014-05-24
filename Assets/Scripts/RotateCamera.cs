using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour {
	public Transform player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (player.position, Vector3.up, Input.GetAxis ("Horizontal"));
		transform.LookAt (player.position);
		transform.position = new Vector3 (transform.position.x, player.position.y, transform.position.z);
	}
}
