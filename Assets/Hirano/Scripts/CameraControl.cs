using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
	//カメラの位置を空のオブジェクトに
	public Transform RightPoint;
	public Transform BackPoint;
	public Transform LeftPoint;
	public Transform DownPoint;

	private Vector3 PlayerPosition;
	private Quaternion PlayerRotate;
	//カメラのState
	private CameraState State;
	//Stateを管理しているフラグ
	public static bool RightSide = false;
	public static bool LeftSide = false;
	public static bool BackSide = false;
	public static bool DownSide = false;
	public enum CameraState
	{
		Idol,
		Right,
		Back,
		Left,
		Down,
	}
	// Use this for initialization
	void Start ()
	{
		PlayerPosition = transform.position;
		PlayerRotate = transform.rotation;
	}
	
	
	// Update is called once per frame
	void Update ()
	{
		switch (State)
		{
			case CameraState.Idol: //最初の状態
				FirstPosition();
				break;
			case CameraState.Right: //右の状態
				CameraRight();
				break;
			case CameraState.Back: //後ろの状態
				CameraBack();
				break;
			case CameraState.Left: //左の状態
				CameraLeft();
				break;
			case CameraState.Down: //下に行った時
				CameraDown();
				break;
		}
		StateControl();
	}

	void StateControl()
	{
		if (RightSide)
		{
			State = CameraState.Right;
		}
		else if (LeftSide)
		{
			State = CameraState.Left;
		}
		else if (BackSide)
		{
			State = CameraState.Back;
		}
		else if (DownSide)
		{
			State = CameraState.Down;
		}
		else
		{
			State = CameraState.Idol;
		}
	}


	void FirstPosition()
	{
		transform.position = PlayerPosition;
		transform.rotation = PlayerRotate;
	}

	void CameraRight()
	{
		//RightSideにきたらカメラを移動
		transform.position = RightPoint.position;
		transform.rotation = Quaternion.Euler(0, 0, -90);
		//上にいったらIdolに戻る
		if (!RightSide)
		{
			State = CameraState.Idol;
		}
		else if (DownSide)
		{
			RightSide = false;
			State = CameraState.Down;
		}
	}

	void CameraLeft()
	{
		//LeftSideにきたらカメラを移動
		transform.position = LeftPoint.position;
		transform.rotation = Quaternion.Euler(0, 0, 90);
		//上にいったらIdolに戻る
		if (!LeftSide)
		{
			State = CameraState.Idol;
		}
		else if (DownSide)
		{
			LeftSide = false;
			State = CameraState.Down;
		}

	}

	void CameraBack()
	{
		//BackSideに来たらカメラを移動
		transform.position = BackPoint.position;
		transform.rotation = Quaternion.Euler(180, 0, 0);
		//上に行ったらIdolに戻る
		if (!BackSide)
		{
			State = CameraState.Idol;
		}
		else if (DownSide)
		{
			BackSide = false;
			State = CameraState.Down;
		}
	}

	void CameraDown()
	{
		//BackSideに来たらカメラを移動
		transform.position = DownPoint.position;
		transform.rotation = Quaternion.Euler(-80, 0, 0);
		//上に行ったらRight,Left,Sideに戻る
		if (!DownSide)
		{
			State = CameraState.Idol;
		}
	}
}
