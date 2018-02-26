using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Reversi : MonoBehaviour
{
	const int boardSize = 5;

	//パネル
	GameObject[,] Panels = new GameObject[boardSize * 4 + 2, boardSize * 3 + 2];
	//位置検索
	int[,] a = new int[boardSize * 4 + 2, boardSize * 3 + 2];

	public int[,] Board = new int[4,4];

	public SceneLoad LoadScript;

	// Use this for initialization
	void Start ()
	{
		LoadScript.ColOut();

		for(int i = 0; i <= Panels.Length; i++)
		{
			if(i <= 4||i >=10)
			{
				//Panels[i, 0] = null;
			}
			else
			{
				//Panels[i, 0]
			}
		}

		foreach(GameObject name in Panels)
		{
			//Debug.Log(name);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			LoadScript.ColIn();
			Debug.Log("oshita");
		}
	}
}
