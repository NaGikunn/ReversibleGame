using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSupportMove : MonoBehaviour
{
	private Vector3 PlayerPos;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		PlayerPos = transform.position;
		if (PlayerPos.x <= 5.0f)
		{
			PlayerPos.x += 1.0f;
			transform.position = PlayerPos;
		}
	}
}
