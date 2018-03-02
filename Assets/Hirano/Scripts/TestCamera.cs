using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestCamera : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.rotation = Quaternion.Euler(0,0,0);


		////Targetの移動量分、自分も移動する
		//transform.position += TargetObject.transform.position - TargetPos;
		//TargetPos = TargetObject.transform.position;

		//   //マウスの移動量
		float mouseInputX = Input.GetAxis("Horizontal");
		float mouseInputY = Input.GetAxis("Vertical");
		////targetの位置のY軸を中心に、回転（公転）する
		//transform.RotateAround(TargetPos, Vector3.up, mouseInputX * Time.deltaTime * 200.0f);
		////カメラの垂直移動
		//transform.RotateAround(TargetPos, transform.right, mouseInputY * Time.deltaTime * 200.0f);
	}
}
