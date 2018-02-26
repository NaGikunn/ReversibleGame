using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
	private GameObject player = null;

	private Vector3 offset = Vector3.zero;

	public string TargetTagName;

	public GameObject RightPosition;
	public GameObject LeftPosition;
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag(TargetTagName);
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 newPosition = transform.position;
		newPosition.x = player.transform.position.x + offset.x;
		newPosition.y = player.transform.position.y + offset.y;
		newPosition.z = player.transform.position.z + offset.z;
		transform.position = Vector3.Lerp(transform.position, newPosition, 5.0f * Time.deltaTime);
	}
}
