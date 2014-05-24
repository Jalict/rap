using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rope))]
public class Player : MonoBehaviour {

    private GameObject wallobj;

	void Start () {
	}
	
	void Update () {
        float change = Input.GetAxis("Vertical") * Time.deltaTime * 1;
        transform.position -= (transform.position-GetComponent<Laser>().other.position).normalized * change;
        
        if (wallobj) {
            float scroll = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 10;
            transform.position += (transform.position - wallobj.transform.position).normalized * scroll;
        }

        if (Input.GetButtonDown("Fire1") && !wallobj) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Camera.main.transform.forward, out hit)) {
                wallobj = new GameObject();
                wallobj.transform.position = hit.point;
                wallobj.AddComponent<Rope>();
                wallobj.GetComponent<Laser>().other = transform;
                wallobj.GetComponent<LineRenderer>().material = GetComponent<LineRenderer>().material;
                wallobj.GetComponent<LineRenderer>().SetWidth(0.1f, 0.1f);
                wallobj.GetComponent<LineRenderer>().SetColors(Color.black, Color.black);
            }
        }
        if (Input.GetButtonDown("Fire2") && wallobj) {
            GameObject joint = new GameObject();
            joint.transform.position = transform.position;
            joint.AddComponent<Rope>();
            joint.GetComponent<Laser>().other = GetComponent<Laser>().other;
            joint.GetComponent<LineRenderer>().material = GetComponent<LineRenderer>().material;
            joint.GetComponent<LineRenderer>().SetWidth(0.1f, 0.1f);
            joint.GetComponent<LineRenderer>().SetColors(Color.black, Color.black);
            wallobj.GetComponent<Laser>().other = joint.transform;
            GetComponent<Laser>().other = joint.transform;
            transform.position -= Vector3.down * 0.01f;
            wallobj = null;
        }
	}
}
