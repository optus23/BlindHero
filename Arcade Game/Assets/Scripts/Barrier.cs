using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour {

    public float offset_x = 60;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(gameObject.transform.position.x + offset_x, Input.mousePosition.y, 10));
	}
}
