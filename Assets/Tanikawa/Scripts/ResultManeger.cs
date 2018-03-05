using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManeger : MonoBehaviour
{
    public GameObject LoadManeger2;

	// Use this for initialization
	void Start ()
    {
        LoadManeger2.GetComponent<SceneLoad>().ColOut();
    }

	// Update is called once per frame
	void Update ()
    {
        
	}
}
