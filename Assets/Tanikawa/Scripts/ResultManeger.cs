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

    bool Emulateflg;

    public int LastPointB;
    public int LastPointW;

    // Use this for initialization
    void Start ()
    {
       

        LoadManeger2.GetComponent<SceneLoad>().ColOut();
        Emulateflg = false;

        StartCoroutine(ResRoot());
    }

	// Update is called once per frame
	void Update ()
    {
        if(Emulateflg==true)
        {
            if (LastPointB>LastPointW)
            {
                AnimRes[0].SetBool("WinB", true);
                AnimRes[1].SetBool("LoseW", true);
            }
            else if (LastPointB<LastPointW)
            {
                AnimRes[0].SetBool("LoseB", true);
                AnimRes[1].SetBool("WinW", true);
            }
        }

        ImaText[0].text = string.Format("{0:0000}", LastPointB);
        ImaText[1].text = string.Format("{0:0000}", LastPointW);
    }

    IEnumerator ResRoot()
    {
        yield return new WaitForSeconds(3.0f);
        StaMove();
        yield return new WaitForSeconds(7.0f);
        Emulateflg = true;
    }

    public void StaMove()
    {
        AnimRes[0].SetBool("MoveB", true);
        AnimRes[1].SetBool("MoveW", true);
    }

    //ImaAni[0].SetBool("point", true);
}
