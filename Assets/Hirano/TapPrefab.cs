using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPrefab : MonoBehaviour
{
	public GameObject stone;

	private Vector3 tapPosition;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			tapPosition = Input.mousePosition;
			tapPosition.z = 6.0f;
			Instantiate(stone, Camera.main.ScreenToWorldPoint(tapPosition), stone.transform.rotation);
		}
	}
}
