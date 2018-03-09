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
		//Downにきたら	
		if (PlayerPos.y <= -4.5f && (isBack || isRight || isLeft || isFront))
		{
			Stop = true;
			if (Stop)
			{
				if (isFront)
				{
					//PlayerPos.z += 1.0f;
					isFront = false;
				}
				else if (isBack)
				{
					//PlayerPos.z -= 1.0f;
					isBack = false;
				}
				else if (isRight)
				{
					//PlayerPos.x -= 1.0f;
					isRight = false;
				}
				else if (isLeft)
				{
					//PlayerPos.x += 1.0f;
					isLeft = false;
				}
				//transform.position = PlayerPos;
				CameraControl.DownSide = true;
				isDown = true;
				Stop = false;
			}
			else
			{
				return;
			}
		}
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
				CameraControl.BackSide = true;
			}
			else if(PlayerPos.x >= 3.0f) //Rightにきたら
			{
				PlayerPos.y -= 1.0f;
				transform.position = PlayerPos;
				isRight = true;
				CameraControl.RightSide = true;
			}
			else if (PlayerPos.x <= -3.0f) //Leftにきたら
			{
				PlayerPos.y -= 1.0f;
				transform.position = PlayerPos;
				isLeft = true;
				Stop = false;
				CameraControl.LeftSide = true;
			}

		}
		//SideにいてSideの1を超えたら
		if (isFront && PlayerPos.y >= 1.0f)
		{
			isFront = false;
			PlayerPos.z += 1.0f;
			transform.position = PlayerPos;
		}

		if(isBack && PlayerPos.y >= 1.0f)
		{
			isBack = false;
			CameraControl.BackSide = false;
			PlayerPos.z -= 1.0f;
			transform.position = PlayerPos;
		}

		if(isRight && PlayerPos.y >= 1.0f)
		{
			isRight = false;
			CameraControl.RightSide = false;
			PlayerPos.x -= 1.0f;
			transform.position = PlayerPos;
		}

		if(isLeft && PlayerPos.y >= 1.0f)
		{
			isLeft = false;
			CameraControl.LeftSide = false;
			PlayerPos.x += 1.0f;
			transform.position = PlayerPos;
		}

		if (isDown && (PlayerPos.z >= 4.0f || PlayerPos.z <= -4.0f || PlayerPos.x >= 4.0f || PlayerPos.x <= -4.0f))
		{
			isDown = false;
			CameraControl.DownSide = false;
			if (PlayerPos.x >= 3.0f)
			{
				CameraControl.RightSide = true;
				isRight = true;
			}
			if(PlayerPos.x <= -3.0f)
			{
				CameraControl.LeftSide = true;
				isLeft = true;
			}
			if(PlayerPos.z >= 3.0f)
			{
				CameraControl.BackSide = true;
				isBack = true;
			}
			if (PlayerPos.z <= -3.0f)
			{
				CameraControl.DownSide = false;
				isFront = true;
			}
			PlayerPos.y += 1.0f;
			transform.position = PlayerPos;
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