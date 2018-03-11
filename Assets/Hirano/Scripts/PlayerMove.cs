using System.Collections;
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
	//塗る色のMaterial
	public Material PaintMat;
	//足跡
	public GameObject Footprint;
	//プレイヤーの位置
	private Vector3 PlayerPos;
	//ステージのどこにいるか
	private bool isFront = false;
	private bool isBack = false;
	private bool isRight = false;
	private bool isLeft = false;
	private bool isDown = false;
	//CountPanelを踏んでいるか
	private bool CountHitPanel = false;
	//isDownを止めるフラグ
	private bool Stop = true;
	private bool SecondTime = false;

	// Use this for initialization
	void Start()
	{
		MyName = gameObject.name;
		//SecondTimeCount
		StartCoroutine(SecondCount());
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
		StartCoroutine(InputUpdate());
		//Ray
		PanelRay();
		//回ってなければキー入力されない
		if (!isRolling)
		{
			//Switch
			switch (State)
			{
				case PlayerState.Idol: return;
				case PlayerState.Up: RollUp();  return;
				case PlayerState.Down: RollDown();  return;
				case PlayerState.Right: RollRight(); return;
				case PlayerState.Left: RollLeft(); return;
			}
		}

		//Downにいたときに戻るときの処理（少し複雑）
		StartCoroutine(FalseDown());

		//Downにきたら	
		if (PlayerPos.y <= -4.5f && (isBack || isRight || isLeft || isFront))
		{
			Stop = true;
			//Playerの移動する前にBoolがFalseになってしまうのでコルーチンで遅らせる
			if (Stop)
			{
				if (isFront)
				{
					PlayerPos.z += 2.0f;
					StartCoroutine(TimeisFront());
				}
				else if (isBack)
				{
					PlayerPos.z -= 2.0f;
					StartCoroutine(TimeisBack());
				}
				else if (isRight)
				{
					PlayerPos.x -= 2.0f;
					StartCoroutine(TimeisRight());
				}
				else if (isLeft)
				{
					PlayerPos.x += 2.0f;
					StartCoroutine(TimeisLeft());
				}
				transform.position = PlayerPos;
				if (gameObject.name == "PlayerManger")
				{
					CameraControl.DownSide = true;
				}
				else
				{
					CameraControl2.DownSide = true;
				}
				isDown = true;
				Stop = false;
			}
			else
			{
				return;
			}
		}

	}

	IEnumerator FalseDown()
	{
		yield return new WaitForSeconds(0.1f);
		while (true)
		{
			//Downにいたときに戻るときの処理（少し複雑）
			if (isDown && (PlayerPos.z >= 3.0f || PlayerPos.z <= -3.0f || PlayerPos.x >= 3.0f || PlayerPos.x <= -3.0f))
			{
				//Down側からでたらカメラとそのDownの操作をOFF
				isDown = false;
				if (gameObject.name == "PlayerManger")
				{
					CameraControl.DownSide = false;
				}
				else
				{
					CameraControl2.DownSide = false;
				}
				PlayerPos.y += 1.0f;
				transform.position = PlayerPos;

				//Right側に出た時
				if (PlayerPos.x >= 3.0f)
				{
					if (gameObject.name == "PlayerManger")
					{
						CameraControl.RightSide = true;
					}
					else
					{
						CameraControl2.RightSide = true;
					}
					isRight = true;
				}

				//Back側に出た時
				if (PlayerPos.z >= 3.0f)
				{
					if (gameObject.name == "PlayerManger")
					{
						CameraControl.BackSide = true;
					}
					else
					{
						CameraControl2.BackSide = true;
					}
					isBack = true;
				}

				//Left側に出た時
				if (PlayerPos.x <= -3.0f)
				{
					if (gameObject.name == "PlayerManger")
					{
						CameraControl.LeftSide = true;
					}
					else
					{
						CameraControl2.LeftSide = true;
					}
					isLeft = true;
				}

				//Front側に出た時
				if (PlayerPos.z <= -3.0f)
				{
					if (gameObject.name == "PlayerManger")
					{
						CameraControl.DownSide = false;
					}
					else
					{
						CameraControl2.DownSide = false;
					}
					isFront = true;
				}
			}
			yield return null;
		}
	}

	IEnumerator TimeisFront()
	{
		yield return new WaitForSeconds(0.1f);
		isFront = false;
		yield return null;
	}

	IEnumerator TimeisBack()
	{
		yield return new WaitForSeconds(0.1f);
		isBack = false;
		yield return null;
	}

	IEnumerator TimeisRight()
	{
		yield return new WaitForSeconds(0.1f);
		isRight = false;
		yield return null;
	}

	IEnumerator TimeisLeft()
	{
		yield return new WaitForSeconds(0.1f);
		isLeft = false;
		yield return null;
	}

	private void RollUp()
	{
		//Sideにいるかどうか
		if (isFront)
		{
			StartCoroutine(PlayerRolling(
			   transform.position,
			   transform.position + Vector3.up,
			   new Vector3(90, 0, 0)));
			FootPrint(0, 0);
		}
		else if (isBack)
		{
			StartCoroutine(PlayerRolling(
			   transform.position,
			   transform.position + Vector3.down,
			   new Vector3(90, 0, 0)));
			FootPrint(180, 0);
		}
		else if (isRight)
		{
			StartCoroutine(PlayerRolling(
				transform.position,
				transform.position + Vector3.forward,
				new Vector3(0, -90, 0)));
			FootPrint(0, 90);
		}
		else if (isLeft)
		{
			StartCoroutine(PlayerRolling(
				transform.position,
				transform.position + Vector3.forward,
				new Vector3(0, 90, 0)));
			FootPrint(0, -90);
		}
		else if (isDown)
		{
			StartCoroutine(PlayerRolling(
				transform.position,
				transform.position + Vector3.back,
				new Vector3(-90, 0, 0)));
			FootPrint(90, 0);
		}
		else
		{
			StartCoroutine(PlayerRolling(
			   transform.position,
			   transform.position + Vector3.forward,
			   new Vector3(90, 0, 0)));
			FootPrint(90, 0);
		}
	}

	private void RollDown()
	{
		if (isFront)
		{
			StartCoroutine(PlayerRolling(
			   transform.position,
			   transform.position + Vector3.down,
			   new Vector3(-90, 0, 0)));
			FootPrint(0, 0);
		}
		else if (isBack)
		{
			StartCoroutine(PlayerRolling(
			   transform.position,
			   transform.position + Vector3.up,
			   new Vector3(-90, 0, 0)));
			FootPrint(180, 0);
		}
		else if (isRight)
		{
			StartCoroutine(PlayerRolling(
				transform.position,
				transform.position + Vector3.back,
				new Vector3(0, 90, 0)));
			FootPrint(0, -90);
		}
		else if (isLeft)
		{
			StartCoroutine(PlayerRolling(
				transform.position,
				transform.position + Vector3.back,
				new Vector3(0, -90, 0)));
			FootPrint(0, 90);
		}
		else if (isDown)
		{
			StartCoroutine(PlayerRolling(
				transform.position,
				transform.position + Vector3.forward,
				new Vector3(90, 0, 0)));
			FootPrint(90, 0);
		}
		else
		{
			StartCoroutine(PlayerRolling(
				transform.position,
				transform.position + Vector3.back,
				new Vector3(-90, 0, 0)));
			FootPrint(90, 0);
		}
	}

	private void RollLeft()
	{
		if (isFront)
		{
			StartCoroutine(PlayerRolling(
				transform.position,
				transform.position + Vector3.left,
				new Vector3(0, 90, 0)));
			FootPrint(0, 0);
		}
		else if (isRight)
		{
			StartCoroutine(PlayerRolling(
			   transform.position,
			   transform.position + Vector3.up,
			   new Vector3(0, 0, 90)));
			FootPrint(0, 90);
		}
		else if (isLeft)
		{
			StartCoroutine(PlayerRolling(
				transform.position,
				transform.position + Vector3.down,
				new Vector3(0, 0, 90)));
			FootPrint(0, -90);
		}
		else if(isBack)
		{
			StartCoroutine(PlayerRolling(
				transform.position,
				transform.position + Vector3.left,
				new Vector3(0, -90, 0)));
			FootPrint(90, 0);
		}
		else if (isDown)
		{
			StartCoroutine(PlayerRolling(
				transform.position,
				transform.position + Vector3.left,
				new Vector3(0, 0, -90)));
			FootPrint(0, -90);
		}
		else
		{
			StartCoroutine(PlayerRolling(
				transform.position,
				transform.position + Vector3.left,
				new Vector3(0, 0, 90)));
			FootPrint(90, 0);
		}
	}

	private void RollRight()
	{
		if (isFront)
		{
			StartCoroutine(PlayerRolling(
				transform.position,
				transform.position + Vector3.right,
				new Vector3(0, -90, 0)));
			FootPrint(0, 0);
		}
		else if (isRight)
		{
			StartCoroutine(PlayerRolling(
			   transform.position,
			   transform.position + Vector3.down,
			   new Vector3(0, 0, -90)));
			FootPrint(0, 90);
		}
		else if (isLeft)
		{
			StartCoroutine(PlayerRolling(
				transform.position,
				transform.position + Vector3.up,
				new Vector3(0, 0, -90)));
			FootPrint(0, -90);
		}
		else if(isBack)
		{
			StartCoroutine(PlayerRolling(
				transform.position,
				transform.position + Vector3.right,
				new Vector3(0, 90, 0)));
			FootPrint(90, 0);
		}
		else if (isDown)
		{
			StartCoroutine(PlayerRolling(
				transform.position,
				transform.position + Vector3.right,
				new Vector3(0, 0, 90)));
			FootPrint(90, 0);
		}
		else
		{
			StartCoroutine(PlayerRolling(
				transform.position,
				transform.position + Vector3.right,
				new Vector3(0, 0, -90)));
			FootPrint(90, 0);
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

	IEnumerator SecondCount()
	{
		yield return new WaitForSeconds(22.7f);
		SecondTime = true;
		yield return new WaitForSeconds(10.4f);
		SecondTime = false;
	}

	//InputでStateを設定
	IEnumerator InputUpdate()
	{
		yield return new WaitForSeconds(12.7f);
		while (true)
		{
			if (!SecondTime)
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
			yield return null;
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
		else if (isBack)
		{
			ray = new Ray(transform.position, Vector3.back);
		}
		else if (isDown)
		{
			ray = new Ray(transform.position, Vector3.up);
		}
		//Rayの長さ
		float rayLine = 1.5f;
		//Rayを可視化
		Debug.DrawRay(ray.origin, ray.direction * rayLine, Color.red);
		//Rayが当たったら
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, rayLine))
		{
			//Panelに当たったら
			if (hit.collider.gameObject.CompareTag("Panel"))
			{
				CountHitPanel = false;
			}
			else if (hit.collider.gameObject.CompareTag("CountPanel"))
			{
				CountHitPanel = true;
				//PanelのMaterialを変更
				hit.collider.gameObject.GetComponent<Renderer>().material = PaintMat;
				PointPlace.point = true;
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
				if (gameObject.name == "PlayerManger")
				{
					CameraControl.BackSide = true;
				}
				else
				{
					CameraControl2.BackSide = true;
				}
			}
			else if(PlayerPos.x >= 3.0f) //Rightにきたら
			{
				PlayerPos.y -= 1.0f;
				transform.position = PlayerPos;
				isRight = true;
				if (gameObject.name == "PlayerManger")
				{
					CameraControl.RightSide = true;
				}
				else
				{
					CameraControl2.RightSide = true;
				}
			}
			else if (PlayerPos.x <= -3.0f) //Leftにきたら
			{
				PlayerPos.y -= 1.0f;
				transform.position = PlayerPos;
				isLeft = true;
				Stop = false;
				if (gameObject.name == "PlayerManger")
				{
					CameraControl.LeftSide = true;
				}
				else
				{
					CameraControl2.LeftSide = true;
				}
			}

		}
		//Frontから外にでたら
		if (isFront && PlayerPos.y >= 1.0f)
		{
			isFront = false;
			PlayerPos.z += 1.0f;
			transform.position = PlayerPos;
		}
		//FrontからLeftに行く場合
		if(isFront && PlayerPos.x <= -3.0f)
		{
			isFront = false;
			PlayerPos.z += 1.0f;
			transform.position = PlayerPos;
			isLeft = true;
			if (gameObject.name == "PlayerManger")
			{
				CameraControl.LeftSide = true;
			}
			else
			{
				CameraControl2.LeftSide = true;
			}
		}
		//FrontからRightに行く場合
		if (isFront && PlayerPos.x >= 3.0f)
		{
			isFront = false;
			PlayerPos.z += 1.0f;
			transform.position = PlayerPos;
			isRight = true;
			if (gameObject.name == "PlayerManger")
			{
				CameraControl.RightSide = true;
			}
			else
			{
				CameraControl2.RightSide = true;
			}
		}


		//Backから上にいったら
		if (isBack && PlayerPos.y >= 1.0f)
		{
			isBack = false;
			if (gameObject.name == "PlayerManger")
			{
				CameraControl.BackSide = false;
			}
			else
			{
				CameraControl2.BackSide = false;
			}
			PlayerPos.z -= 1.0f;
			transform.position = PlayerPos;
		}
		//BackからRightに行く場合
		if (isBack && PlayerPos.x >= 3.0f)
		{
			isBack = false;
			PlayerPos.z -= 1.0f;
			transform.position = PlayerPos;
			isRight = true;
			if (gameObject.name == "PlayerManger")
			{
				CameraControl.BackSide = false;
				CameraControl.RightSide = true;
			}
			else
			{
				CameraControl2.BackSide = false;
				CameraControl2.RightSide = true;
			}
		}
		//BackからLeftに行く場合
		if (isBack && PlayerPos.x <= -3.0f)
		{
			isBack = false;
			PlayerPos.z -= 1.0f;
			transform.position = PlayerPos;
			isLeft = true;
			if (gameObject.name == "PlayerManger")
			{
				CameraControl.BackSide = false;
				CameraControl.LeftSide = true;
			}
			else
			{
				CameraControl2.BackSide = false;
				CameraControl2.LeftSide = true;
			}
		}


		//Rightから上に行ったら
		if (isRight && PlayerPos.y >= 1.0f)
		{
			isRight = false;
			if (gameObject.name == "PlayerManger")
			{
				CameraControl.RightSide = false;
			}
			else
			{
				CameraControl2.RightSide = false;
			}
			PlayerPos.x -= 1.0f;
			transform.position = PlayerPos;
		}
		//RightからFrontに行く場合
		if (isRight && PlayerPos.z <= -3.0f)
		{
			isRight = false;
			PlayerPos.x -= 1.0f;
			transform.position = PlayerPos;
			isFront = true;
			if (gameObject.name == "PlayerManger")
			{
				CameraControl.RightSide = false;
			}
			else
			{
				CameraControl2.RightSide = false;
			}
		}
		//RightからBackに行く場合
		if (isRight && PlayerPos.z >= 3.0f)
		{
			isRight = false;
			PlayerPos.x -= 1.0f;
			transform.position = PlayerPos;
			isBack = true;
			if (gameObject.name == "PlayerManger")
			{
				CameraControl.RightSide = false;
				CameraControl.BackSide = true;
			}
			else
			{
				CameraControl2.RightSide = false;
				CameraControl2.BackSide = true;
			}
		}

		//Leftから上にいったら
		if (isLeft && PlayerPos.y >= 1.0f)
		{
			isLeft = false;
			if (gameObject.name == "PlayerManger")
			{
				CameraControl.LeftSide = false;
			}
			else
			{
				CameraControl2.LeftSide = false;
			}
			PlayerPos.x += 1.0f;
			transform.position = PlayerPos;
		}
		//LeftからFrontに行く場合
		if (isLeft && PlayerPos.z <= -3.0f)
		{
			isLeft = false;
			PlayerPos.x += 1.0f;
			transform.position = PlayerPos;
			isFront = true;
			if (gameObject.name == "PlayerManger")
			{
				CameraControl.LeftSide = false;
			}
			else
			{
				CameraControl2.LeftSide = false;
			}
		}
		//LeftからBackに行く場合
		if (isLeft && PlayerPos.z >= 3.0f)
		{
			isLeft = false;
			PlayerPos.x += 1.0f;
			transform.position = PlayerPos;
			isBack = true;
			if (gameObject.name == "PlayerManger")
			{
				CameraControl.LeftSide = false;
				CameraControl.BackSide = true;
			}
			else
			{
				CameraControl2.LeftSide = false;
				CameraControl2.BackSide = true;
			}
		}
	}

	public void FootPrint(float Rx, float Ry)
	{
		if (!CountHitPanel)
		{
			GameObject obj;
			float x = PlayerPos.x;
			float y = PlayerPos.y;
			float z = PlayerPos.z;
			//Panelに足跡をつける
			obj = Instantiate(Footprint, new Vector3(x, y - 0.4f, z), Quaternion.Euler(Rx, Ry, 0));
			Destroy(obj, 0.8f);
		}
	}
}