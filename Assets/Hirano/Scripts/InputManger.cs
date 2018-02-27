using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManger : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}
	enum AnyKey
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetAxis("Horizontal")!=0)
		{
			Debug.Log(Input.GetAxis("Horizontal"));
		}
	}

	KeyCode ScanKeyCode()
	{
		foreach (KeyCode code in AnyKey.GetValues(typeof(KeyCode)))
		{
			if (Input.GetKeyDown(code))
			{
				return code;
			}
		}
		return KeyCode.None;
    }
}
