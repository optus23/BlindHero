using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Capsule : MonoBehaviour
{

    float velocity = 0.25f;
    float rebound_velocity;
    int state = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       //Rotation
        transform.Rotate(350 * Time.deltaTime, 0, 0);

        rebound_velocity = velocity - 0.1F;

        switch (state)
        {
            case 0:
                
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - velocity, gameObject.transform.position.y, 0);

                break;

            case 1:
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + rebound_velocity, gameObject.transform.position.y, 0);
                break;
          
            default:
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - velocity, gameObject.transform.position.y, 0);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "White_Barrier" || collision.transform.tag == "Red_Barrier")
        {
            state = 1;
            Debug.Log(state);
        }

        if (collision.transform.tag == "Lose")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Debug.Log("Lose");
        }

        if (collision.transform.tag == "Triangle_Stop")
        {
            Destroy(gameObject);
        }


    }
}


