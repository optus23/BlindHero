using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour {

    public GameObject level1;
    public GameObject level2;

    public bool level_1 = true;
    public bool level_2 = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (level_1)
            level1.SetActive(true);
        else if (level_2)
            level2.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Red_Barrier" || collision.transform.tag == "White_Barrier")
        {

            if(level_1 == true)
            {
                level_2 = true;
                level_1 = false;
            }
            else if(level_2 == true)
            {
                level_1 = true;
                level_2 = false;
            }
        }
    }
}
