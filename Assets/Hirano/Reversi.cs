using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Reversi : MonoBehaviour
{
	int[,] Board = new int[4,4];

	// Use this for initialization
	void Start ()
	{
		for(int i = 0; i <= 3; i++)
		{
			Board[i, 0] += 1;
			Board[i, 1] += 1;
			Board[i, 2] += 1;
			Board[i, 3] += 1;
		}

		foreach (int i in Board)
		{
			Debug.Log(i);
		}


	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}
