using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessGenerator : MonoBehaviour {

    public GameObject[] obj;
    public float time;
    public float time_now;
	// Use this for initialization
	void Start () {
        Generator();
	}
	
	// Update is called once per frame
	void Update () {
        time -= Mathf.Log(time+0.6f)/800;
        /*time -= 0.0003f;*/
        time_now = Time.time;
    }

    void Generator()
    {
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(transform.position.x, Random.Range(-3.5f, 3.5f), 0), Quaternion.identity);
        Invoke("Generator", time);
    }
}
