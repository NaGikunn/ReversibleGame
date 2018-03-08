using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManeger : MonoBehaviour
{
    public GameObject LoadManeger2;

    public Image[] ImaResult = new Image[3];

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
