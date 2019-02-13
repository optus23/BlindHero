using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhiteTriangles : MonoBehaviour
{

    float velocity_triangles;
    float rebound_velocity_triangles;
    int state = 0;

    // Use this for initialization
    void Start()
    {
        velocity_triangles = transform.GetComponentInParent<Triangles>().velocity;

    }

    // Update is called once per frame
    void Update()
    {

        rebound_velocity_triangles = velocity_triangles + 0.2F;

        switch (state)
        {
            case 0:
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - velocity_triangles, gameObject.transform.position.y, 0);
                break;

            case 1:
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + rebound_velocity_triangles, gameObject.transform.position.y - rebound_velocity_triangles, 0);
                break;
            case 2:
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + rebound_velocity_triangles, gameObject.transform.position.y + rebound_velocity_triangles, 0);
                break;

            case 3:
                var rot = transform.rotation;
                rot.x += Time.deltaTime * 10;
                transform.rotation = rot;

                if (gameObject.transform.tag == "TriangleDown")
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x - velocity_triangles, gameObject.transform.position.y - velocity_triangles / 2, 0);
                else if  (gameObject.transform.tag == "TriangleUp")
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x - velocity_triangles, gameObject.transform.position.y + velocity_triangles / 2, 0);
                break;

            default:
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - velocity_triangles, gameObject.transform.position.y, 0);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "White_Barrier")
        {
            state = Random.Range(1, 3);
            Debug.Log(state);
        }

        if (collision.transform.tag == "Triangle_Stop")
        {
            state = 3;
            Debug.Log(state);
        }

        if (collision.transform.tag == "Lose")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Debug.Log("Lose");
        }

        if (collision.transform.tag == "Finish")
        {
            Destroy(gameObject);
        }


    }
}

