﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManeger : MonoBehaviour
{
	public GameObject LoadManeger2;

	public Image[] ImaResult = new Image[3];

	public Text[] ImaText = new Text[2];

	public Animator[] AnimRes = new Animator[2];

	bool TitleMoveflg;

	public int LastPointB;
	public int LastPointW;
	// Use this for initialization
	void Start()
	{
		LoadManeger2.GetComponent<SceneLoad>().ColOut();
		TitleMoveflg = false;

		StartCoroutine(ResRoot());

		LastPointB = PointPlace.CountW;
		LastPointW = PointPlace.CountB;
	}

	// Update is called once per frame
	void Update()
	{
		//if (Emulateflg == true)
		//{
		//	if (LastPointB > LastPointW)
		//	{
		//		AnimRes[0].SetBool("WinB", true);
		//		AnimRes[1].SetBool("LoseW", true);
		//	}
		//	else if (LastPointB < LastPointW)
		//	{
		//		AnimRes[0].SetBool("LoseB", true);
		//		AnimRes[1].SetBool("WinW", true);
		//	}
		//}

		if (TitleMoveflg == true)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				LoadManeger2.GetComponent<SceneLoad>().ColIn();
			}
		}

		ImaText[0].text = string.Format("{0:0000}", LastPointB);
		ImaText[1].text = string.Format("{0:0000}", LastPointW);
	}


	IEnumerator ResRoot()
	{
		yield return new WaitForSeconds(3.0f);
		StaMove();
		yield return new WaitForSeconds(5.0f);
		Emulate();
		yield return new WaitForSeconds(2.0f);
		MoveWin();
		yield return new WaitForSeconds(2.0f);
		AnimOn();
		yield return new WaitForSeconds(1.0f);
		TitleMoveflg = true;
		yield return new WaitForSeconds(0.1f);
		AnimRes[2].SetBool("titleGo", true);
	}

	public void StaMove()
	{
		AnimRes[0].SetBool("MoveB", true);
		AnimRes[1].SetBool("MoveW", true);
	}
	public void Emulate()
	{
		if (LastPointB > LastPointW)
		{
			AnimRes[0].SetBool("WinB", true);
			AnimRes[1].SetBool("LoseW", true);
		}
		else if (LastPointB < LastPointW)
		{
			AnimRes[0].SetBool("LoseB", true);
			AnimRes[1].SetBool("WinW", true);
		}
	}


	public void MoveWin()
	{
		AnimRes[0].SetBool("OnWinB", true);
		AnimRes[1].SetBool("OnWinW", true);
	}

	public void AnimOn()
	{
		if (LastPointB > LastPointW)
		{
			AnimRes[3].SetBool("ResTexGo", true);
		}
		else if (LastPointB < LastPointW)
		{
			AnimRes[4].SetBool("ResTexGo", true);
		}
		AnimRes[5].SetBool("ResTexGo", true);
		AnimRes[6].SetBool("ResTexGo", true);
	}
}