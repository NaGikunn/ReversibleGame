﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMove : MonoBehaviour
{
	//回るときのフレーム
	public int rollFrame = 6;
	//回ってるかどうか
	private bool isRolling = false;
	//enumからStateへ
	private PlayerState State;
	//自分の名前
	private string MyName;
	//足跡
	public GameObject AsiatoMat;
	//プレイヤーの位置
	private Vector3 PlayerPos;
	//プレイヤーがサイドから戻るときの高さ
	public float SideEndPos;
	//どの状態にいるか
	public static  bool isFront = false;
	public static bool isBack = false;
	public static bool isRight = false;
	public static bool isLeft = false;
	// Use this for initialization
	void Start()
	{
		MyName = gameObject.name;
	}

	public enum PlayerState
	{
		Idol,
		Up,
		Down,
		Right,
		Left,
	}

	// Update is called once per frame
	void Update()
	{
		//Stateメソッド
		InputUpdate();
		//Ray
		PanelRay();
		//回ってなければキー入力されない
		if (!isRolling)
		{
			//Switc
			switch (State)
			{
				case PlayerState.Idol:
					break;
				case PlayerState.Up:
					//Sideにいるかどうか
					if (isFront)
					{
						StartCoroutine(PlayerRolling(
						   transform.position,
						   transform.position + Vector3.up,
						   new Vector3(90, 0, 0)));
						Asiat(0,0);
					}
					else if(isBack)
					{
						StartCoroutine(PlayerRolling(
						   transform.position,
						   transform.position + Vector3.down,
						   new Vector3(-90, 0, 0)));
						Asiat(180,0);
					}
					else if (isRight)
					{
						StartCoroutine(PlayerRolling(
							transform.position,
							transform.position + Vector3.forward,
							new Vector3(0, -90, 0)));
						Asiat(0,90);
					}
					else if (isLeft)
					{
						StartCoroutine(PlayerRolling(
							transform.position,
							transform.position + Vector3.forward,
							new Vector3(0, 90, 0)));
						Asiat(0,-90);
					}
					else
					{
						StartCoroutine(PlayerRolling(
						   transform.position,
						   transform.position + Vector3.forward,
						   new Vector3(90, 0, 0)));
						Asiat(90,0);
					}
					break;
				case PlayerState.Down:
					if (isFront)
					{
						StartCoroutine(PlayerRolling(
						   transform.position,
						   transform.position + Vector3.down,
						   new Vector3(-90, 0, 0)));
						Asiat(0,0);
					}
					else if (isBack)
					{
						StartCoroutine(PlayerRolling(
						   transform.position,
						   transform.position + Vector3.up,
						   new Vector3(90, 0, 0)));
						Asiat(180,0);
					}
					else if (isRight)
					{
						StartCoroutine(PlayerRolling(
							transform.position,
							transform.position + Vector3.back,
							new Vector3(0, 90, 0)));
						Asiat(0,-90);
					}
					else if (isLeft)
					{
						StartCoroutine(PlayerRolling(
							transform.position,
							transform.position + Vector3.back,
							new Vector3(0, -90, 0)));
						Asiat(0,90);
					}
					else
					{
						StartCoroutine(PlayerRolling(
							transform.position,
							transform.position + Vector3.back,
							new Vector3(-90, 0, 0)));
						Asiat(90,0);
					}
					break;
				case PlayerState.Right:
					if (isFront)
					{
						StartCoroutine(PlayerRolling(
						    transform.position,
						    transform.position + Vector3.right,
						    new Vector3(0, -90, 0)));
						Asiat(0,0);
					}
					else if (isRight)
					{
						StartCoroutine(PlayerRolling(
						   transform.position,
						   transform.position + Vector3.down,
						   new Vector3(0, 0, -90)));
						Asiat(0,90);
					}
					else if (isLeft)
					{
						StartCoroutine(PlayerRolling(
							transform.position,
							transform.position + Vector3.up,
							new Vector3(0, 0, -90)));
						Asiat(0,-90);
					}
					else
					{
						StartCoroutine(PlayerRolling(
							transform.position,
							transform.position + Vector3.right,
							new Vector3(0, 0, -90)));
						Asiat(90,0);
					}
					break;
				case PlayerState.Left:
					if (isFront)
					{
						StartCoroutine(PlayerRolling(
						    transform.position,
						    transform.position + Vector3.left,
						    new Vector3(0, 90, 0)));
						Asiat(0,0);
					}
					else if (isRight)
					{
						StartCoroutine(PlayerRolling(
						   transform.position,
						   transform.position + Vector3.up,
						   new Vector3(0, 0, 90)));
						Asiat(0,90);
					}
					else if (isLeft)
					{
						StartCoroutine(PlayerRolling(
							transform.position,
							transform.position + Vector3.down,
							new Vector3(0, 0, 90)));
						Asiat(0,-90);
					}
					else
					{
						StartCoroutine(PlayerRolling(
							transform.position,
							transform.position + Vector3.left,
							new Vector3(0, 0, 90)));
						Asiat(90,0);
					}
					break;
			}

		}
	}

	//回転移動処理
	IEnumerator PlayerRolling(Vector3 sv, Vector3 ev, Vector3 r)
	{
		isRolling = true;
		for (int i = 1; i <= rollFrame; i++)
		{
			transform.position = Vector3.Lerp(sv, ev, (float)i / rollFrame);
			transform.Rotate(r / rollFrame, Space.World);
			yield return null;
		}
		isRolling = false;
	}

	//Stateを設定
	public void InputUpdate()
	{
		//最初はIdol
		State = PlayerState.Idol;

		if (MyName == "PlayerManger")
		{
			if (Input.GetKeyDown(KeyCode.D))
			{
				State = PlayerState.Right;
			}

			if (Input.GetKeyDown(KeyCode.S))
			{
				State = PlayerState.Down;
			}

			if (Input.GetKeyDown(KeyCode.A))
			{
				State = PlayerState.Left;
			}

			if (Input.GetKeyDown(KeyCode.W))
			{
				State = PlayerState.Up;
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				State = PlayerState.Right;
			}

			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				State = PlayerState.Down;
			}

			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				State = PlayerState.Left;
			}

			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				State = PlayerState.Up;
			}
		}
	}

	void PanelRay()
	{
		//Playerの位置を保管
		PlayerPos = transform.position;
		//Rayを飛ばす方向
		var ray = new Ray(transform.position, Vector3.down);
		//Sideに行った場合はRayの方向を変える
		if (isFront)
		{
			ray = new Ray(transform.position, Vector3.forward);
		}
		else if (isRight)
		{
			ray = new Ray(transform.position, Vector3.left);
		}
		else if (isLeft)
		{
			ray = new Ray(transform.position, Vector3.right);
		}
		//Rayの長さ
		int rayLine = 1;
		//Rayを可視化
		Debug.DrawRay(ray.origin, ray.direction * rayLine, Color.red);
		//Rayが当たったら
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, rayLine))
		{
			//Panelに当たったら
			if (hit.collider.gameObject.CompareTag("Panel"))
			{
				//GameObject obj;
				////Panelに足跡をつける
				//obj = Instantiate(AsiatoMat,new Vector3(0,0.6f,0),Quaternion.Euler(90,0,0));
				//obj.transform.position = gameObject.transform.position;
				//Destroy(obj, 0.5f);
			}
			else if(PlayerPos.z <= -2.5f)//Frontにきたら
			{
				PlayerPos.y -= 1.0f;
				transform.position = PlayerPos;
				isFront = true;
			}
			else if(PlayerPos.z >= 2.5f)//Backにきたら
			{
				PlayerPos.y -= 1.0f;
				transform.position = PlayerPos;
				isBack = true;
				Debug.Log("back");
			}
			else if(PlayerPos.x >= 3.0f)
			{
				PlayerPos.y -= 1.0f;
				transform.position = PlayerPos;
				isRight = true;
			}
			else if (PlayerPos.x <= -2.5f)
			{
				PlayerPos.y -= 1.0f;
				transform.position = PlayerPos;
				isLeft = true;
			}
		}
		//SideにいてSideの1を超えたら
		if(isFront && PlayerPos.y >= SideEndPos)
		{
			isFront = false;
			PlayerPos.z += 1.0f;
			transform.position = PlayerPos;
		}

		if(isBack && PlayerPos.y >= SideEndPos)
		{
			isBack = false;
			PlayerPos.z -= 1.0f;
			transform.position = PlayerPos;
		}

		if(isRight && PlayerPos.y >= SideEndPos)
		{
			isRight = false;
			PlayerPos.x -= 1.0f;
			transform.position = PlayerPos;
		}

		if(isLeft && PlayerPos.y >= SideEndPos)
		{
			isLeft = false;
			PlayerPos.x += 1.0f;
			transform.position = PlayerPos;
		}
	}

	public void Asiat(float Rx,float Ry)
	{
		GameObject obj;
		PlayerPos = transform.position;
		float x = PlayerPos.x;
		float y = PlayerPos.y;
		float z = PlayerPos.z;
		//Panelに足跡をつける
		obj = Instantiate(AsiatoMat, new Vector3(x, y-0.4f, z), Quaternion.Euler(Rx, Ry, 0));
		Destroy(obj, 0.5f);
	}
}