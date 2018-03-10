using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManeger : MonoBehaviour
{
    public GameObject LoadManeger2;

    public Image[] ImaResult = new Image[3];

    public Text[] ImaText = new Text[2];

    public Animator[] AnimRes = new Animator[2];

    bool Winflg;

    int[] LastPoint = new int[2];

	// Use this for initialization
	void Start ()
    {
        //LastPoint[0]=BlackPoint
        //LastPoint[1]=WhitePoint

        LoadManeger2.GetComponent<SceneLoad>().ColOut();
        Winflg = false;
    }

	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            AnimRes[0].SetBool("WinB", true);
            AnimRes[1].SetBool("LoseW", true);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            AnimRes[0].SetBool("LoseB", true);
            AnimRes[1].SetBool("WinW", true);
        }

        //FirstTime.text = string.Format("{0:00}", (int)FirstTime);
        //SecondTimeLabel.text = string.Format("{0:00}", (int)SecondTime);
    }

    //ImaAni[0].SetBool("point", true);
}
