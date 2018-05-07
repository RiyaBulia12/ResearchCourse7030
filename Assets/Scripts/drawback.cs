using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawback : MonoBehaviour {

	public int depth = 10;

	// Use this for initialization
	void Start () {
		Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
				transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0f));;
		
		}
		if(Input.GetMouseButtonUp(0)){
			Destroy (this);
		}
	}
}