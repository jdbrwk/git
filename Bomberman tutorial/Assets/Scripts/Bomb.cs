﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {


    public float countdown;
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;

        if (countdown <= 0f)
        {
            FindObjectOfType<MapDestroyer>().Explode(transform.position);
            Destroy(gameObject);
        }
	}
}