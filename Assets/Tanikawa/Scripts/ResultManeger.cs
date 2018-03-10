using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManeger : MonoBehaviour
{
    public GameObject LoadManeger2;

    public Image[] ImaResult = new Image[3];

    public Text[] ImaText = new Text[2];

    public Animator[] ResCube = new Animator[2];

    bool Winflg;



	// Use this for initialization
	void Start ()
    {

        LoadManeger2.GetComponent<SceneLoad>().ColOut();
        Winflg = false;
    }

	// Update is called once per frame
	void Update ()
    {
        //FirstTime.text = string.Format("{0:00}", (int)FirstTime);
        //SecondTimeLabel.text = string.Format("{0:00}", (int)SecondTime);
    }

    //ImaAni[0].SetBool("point", true);
}
