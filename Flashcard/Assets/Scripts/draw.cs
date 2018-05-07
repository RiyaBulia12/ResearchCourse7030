using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draw : MonoBehaviour {

	public float depth = 10.0f;
	public Transform pencil;

	// Use this for initialization
	void  Start (){
		Cursor.visible = true;
	}

	// Update is called once per frame
	void  Update (){
		transform.position= Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x,Input.mousePosition.y, depth));
	}

	void  FixedUpdate (){
		if(Input.GetMouseButtonDown(0)){
			Instantiate (pencil, transform.position, transform.rotation);
		}
	}
}
