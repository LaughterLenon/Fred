﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenchange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
            Application.LoadLevel("Game");
    }
}
