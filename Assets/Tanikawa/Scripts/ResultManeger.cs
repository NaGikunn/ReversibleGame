using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManeger : MonoBehaviour
{
    public GameObject LoadManeger2;

    public Image[] ImaResult = new Image[3];

    public Text[] ImaText = new Text[2];

    GameObject[] ImaSplash = new GameObject[2];

	// Use this for initialization
	void Start ()
    {
        ImaSplash[0] = (GameObject)Resources.Load("Prefab/BlackSplash");
        ImaSplash[1] = (GameObject)Resources.Load("Prefab/WhiteSplash");

        LoadManeger2.GetComponent<SceneLoad>().ColOut();
    }

	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(ImaSplash[0]);
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            Instantiate(ImaSplash[1]);
        }
	}
}
