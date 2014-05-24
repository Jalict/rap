using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour {

    public Transform other;

    private LineRenderer line;

	void Start () {
        line = GetComponent<LineRenderer>();
        if (other != null) {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, other.position);
        }
	}
	
	void Update () {
	    
	}

    void OnDrawGizmos() {
        line = GetComponent<LineRenderer>();
        if (other != null) {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, other.position);
        }
    }
}
