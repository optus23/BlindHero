using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhiteQuads : MonoBehaviour {

    float velocity_quads = 0.25f;
    float rebound_velocity_quads;
    private int state = 0;

    public GameObject enemy_particle;
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
        if(collision.transform.tag == "White_Barrier")
        {
            state = Random.Range(1, 3);
            Instantiate(enemy_particle, transform.position, Quaternion.identity);
        }

        if (collision.transform.tag == "Lose")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Debug.Log("Lose");
        }

        if (collision.transform.tag == "Lose_Endless")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            Debug.Log("Lose");
        }

        if (collision.transform.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }
}
