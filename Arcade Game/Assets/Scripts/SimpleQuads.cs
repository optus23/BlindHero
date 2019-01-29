using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleQuads : MonoBehaviour {

    public float velocity_quads = 0.4F;
    float rebound_velocity_quads;
    private int state = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        rebound_velocity_quads = velocity_quads + 0.2F;

        switch(state)
        {
            case 0:
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - velocity_quads, gameObject.transform.position.y, 0);
                break;

            case 1:
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + rebound_velocity_quads, gameObject.transform.position.y - rebound_velocity_quads, 0);
                break;
            case 2:
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + rebound_velocity_quads, gameObject.transform.position.y + rebound_velocity_quads, 0);
                break;

            default:
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - velocity_quads, gameObject.transform.position.y, 0);
                break;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Hit")
        {
            state = Random.Range(1, 3);
            Debug.Log(state);
        }
    }
}
