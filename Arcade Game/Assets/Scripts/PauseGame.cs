using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {

	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.timeScale == 1)
            {
                Debug.Log("PAUSE");
                Time.timeScale = 0f;
            }
            else
            {
                Debug.Log("NOT PAUSE");
                Time.timeScale = 1f;
            }
        }
    }
}
