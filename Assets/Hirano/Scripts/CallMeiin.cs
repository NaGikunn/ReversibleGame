using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMeiin : MonoBehaviour
{
	public SceneLoad Load;
	// Use this for initialization
	void Start ()
	{
		Load.GetComponent<SceneLoad>().ColOut();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
