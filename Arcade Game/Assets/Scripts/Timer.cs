using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public Text counterText;
    public float sec, min;
    public bool time_stop = false;
	// Use this for initialization
	void Start () {

        counterText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update () {


        sec = (int)(Time.time % 60f);
        min = (int)(Time.time / 60f);
        counterText.text = min.ToString("00") + ":" + sec.ToString("00");



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Lose_Endless")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            Debug.Log("Lose");
            time_stop = true;
        }

    }
}
