﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.Rotate(0, (Input.GetAxis("Horizontal") * 1), 0);
	}
}
