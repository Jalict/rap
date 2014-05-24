using UnityEngine;
using System.Collections;

public class SpawnLaser : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject one = new GameObject();
        GameObject two = new GameObject();
        RaycastHit hit;
        while (!Physics.Raycast(transform.position, Random.rotation.eulerAngles, out hit)) {
        }
        one.transform.position = hit.point;
        while (!Physics.Raycast(transform.position, Random.rotation.eulerAngles, out hit)) {
        }
        two.transform.position = hit.point;
        one.AddComponent<Laser>();
        one.GetComponent<LineRenderer>().SetWidth(0.1f, 0.1f);
        one.GetComponent<Laser>().other = two.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
