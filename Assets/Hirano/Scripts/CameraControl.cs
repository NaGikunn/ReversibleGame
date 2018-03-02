using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
	private GameObject player = null;

	private Vector3 offset = Vector3.zero;

	public string TargetTagName;

	public Transform RightPoint;
	public Transform BackPoint;
	private Quaternion PlayerRotation;

	private CameraState State;

	public enum CameraState
	{
		Idol,
		Right,
		Back,
		Left,
	}
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag(TargetTagName);
		offset = transform.position - player.transform.position;
		transform.rotation = Quaternion.identity;
	}
	
	// Update is called once per frame
	void Update ()
	{
		PlayerRotation = transform.rotation;
		Debug.Log(PlayerRotation.y);
		switch (State)
		{
			case CameraState.Idol:
				State = CameraState.Right;
					break;
			case CameraState.Right:
				StartCoroutine(CameraRight());
				break;
			case CameraState.Back:
				StartCoroutine(CameraBack());
				break;
			case CameraState.Left:
				break;
		}


		//Vector3 newPosition = transform.position;
		//newPosition.x = player.transform.position.x + offset.x;
		//newPosition.y = player.transform.position.y + offset.y;
		//newPosition.z = player.transform.position.z + offset.z;
		//transform.position = Vector3.Lerp(transform.position, newPosition, 5.0f * Time.deltaTime);
	}

	IEnumerator CameraRight()
	{
		while (true)
		{
			PlayerRotation = transform.rotation;
			float y = -1.3f;
			transform.position += (RightPoint.position - transform.position).normalized * Time.deltaTime * 5;
			if(PlayerRotation.y > -0.7)
			{
				transform.Rotate(0, y, 0);
			}
			yield return new WaitForSeconds(1.5f);
			State = CameraState.Back;
			break;
		}
	}

	IEnumerator CameraBack()
	{
		while (true)
		{
			PlayerRotation = transform.rotation;
			float y = -1f;
			transform.position += (BackPoint.position - transform.position).normalized * Time.deltaTime * 5;
			if(PlayerRotation.y > -1)
			{
				transform.Rotate(0, y, 0);
			}
			yield return new WaitForSeconds(1.5f);
			State = CameraState.Left;
			break;
		}
	}
}
