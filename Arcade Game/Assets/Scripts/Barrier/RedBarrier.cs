﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBarrier : MonoBehaviour {

    public float offset_x = 60;

    public GameObject my_object;
    public bool active_barrier = false;

    public AudioClip Sfx_ChangeBarrier;
    public AudioSource Sfx_ChangeBarrier_Source;

    // Use this for initialization
    void Start()
    {
        Sfx_ChangeBarrier_Source.clip = Sfx_ChangeBarrier;
    }

    // Update is called once per frame
    void Update()
    {
        my_object.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(my_object.transform.position.x + offset_x, Input.mousePosition.y, 10));

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Changing Barrier Color");
            active_barrier = !active_barrier;
            Sfx_ChangeBarrier_Source.Play();
        }

        if (active_barrier)
            my_object.SetActive(true);
        else
            my_object.SetActive(false);
    }
}
