using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSupportMove : MonoBehaviour
{
	private Vector3 PlayerPos;
	private bool stop = false;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		PlayerPos = transform.position;
		if (!stop)
		{
			if (PlayerPos.y <= -4.5f)
			{
				stop = true;
				PlayerPos.z += 1.0f;
				transform.position = PlayerPos;
			}
		}
	}
}
