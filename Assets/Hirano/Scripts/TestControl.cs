using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestControl : MonoBehaviour
{
	[SerializeField, Range(0, 10)]
	float time = 1;

	[SerializeField]
	Vector3 endPosition;
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(TimeZone());
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	IEnumerator TimeZone()
	{
		int i = 0;
		while (true)
		{
			i += 1;
			yield return new WaitForSeconds(3.5f);
			break;
		}
	}
}
