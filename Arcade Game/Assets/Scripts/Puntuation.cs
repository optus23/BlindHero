using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuation : MonoBehaviour {

    public static Puntuation state;

    private void Awake()
    {
        if(state == null)
        {
            state = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("gameObject saved correctly");

        }
        else if(state != this)
        {
            Destroy(gameObject);
            Debug.Log("A gameObject already exist, Autodestroying gameObject that we don't need");
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
