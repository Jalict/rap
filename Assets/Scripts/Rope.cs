using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Laser))]
public class Rope : MonoBehaviour {

    private Laser laser;
    private LineRenderer line;
    private Dictionary<Laser, float> predists;
    private bool lost;

	void Start () {
        laser = GetComponent<Laser>();
        line = GetComponent<LineRenderer>();
        predists = new Dictionary<Laser, float>();
	}
	
	void Update () {
        Laser[] lasers = GameObject.FindObjectsOfType<Laser>();
        foreach (Laser laser in lasers) {
            if (laser.GetComponent<Rope>() != null) continue;
            LineRenderer other = laser.GetComponent<LineRenderer>();

            Vector3 a = laser.other.position - other.transform.position;
            Vector3 b = this.laser.other.position - transform.position;
            Vector3 c = transform.position - other.transform.position;
            float dist = (Vector3.Dot(c,Vector3.Cross(a,b)))/(Vector3.Cross(a,b).magnitude);

            if (predists.ContainsKey(laser)) {
                if (Mathf.Sign(predists[laser]) != Mathf.Sign(dist)) {
                    lost = true;
                }
            }

            predists[laser] = dist;
        }
	}

    void OnGUI() {
        if(lost)GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "YOU GOT CAUGHT..");
    }
}
