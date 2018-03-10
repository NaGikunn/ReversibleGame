using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManeger : MonoBehaviour {
    
    public GameObject[] ImaTex = new GameObject[10];

    public Animator[] ImaAni = new Animator[2];

    public GameObject TextMaster3; //親子関係を結ぶCanvas

    int imaCount = 0;
    int pointCount = 0;

    // Use this for initialization
    void Start ()
    {
        ImaTex[0].SetActive(false);
        ImaTex[1].SetActive(false);
        ImaTex[2].SetActive(false);
        ImaTex[3].SetActive(false);
        ImaTex[4].SetActive(false);
        ImaTex[5].SetActive(false);
        ImaTex[6].SetActive(true);
        ImaTex[7].SetActive(true);
        ImaTex[8].SetActive(false);
        ImaTex[9].SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    //よーいImage呼び出し
    public void imaStandby()
    {
        if(imaCount==0)
        {
            ImaTex[0].SetActive(true);
            imaCount += 1;
        }
        else if(imaCount==1)
        {
            ImaTex[0].SetActive(false);
            imaCount -= 1;
        }
    }

    //始めImage呼び出し
    public void imaSta()
    {
        if (imaCount == 0)
        {
            ImaTex[1].SetActive(true);
            imaCount += 1;
        }
        else if (imaCount == 1)
        {
            ImaTex[1].SetActive(false);
            imaCount -= 1;
        }
    }

    //ここからImage呼び出し
    public void imaNexSta()
    {
        if (imaCount == 0)
        {
            ImaTex[2].SetActive(true);
            imaCount += 1;
        }
        else if (imaCount == 1)
        {
            ImaTex[2].SetActive(false);
            imaCount -= 1;
        }
    }

    //回転注意Image呼び出し
    public void imaDanger()
    {
        if (imaCount == 0)
        {
            ImaTex[3].SetActive(true);
            imaCount += 1;
        }
        else if (imaCount == 1)
        {
            ImaTex[3].SetActive(false);
            imaCount -= 1;
        }
    }

    //終了Image呼び出し
    public void imaEnd()
    {
        if (imaCount == 0)
        {
            ImaTex[4].SetActive(true);
            imaCount += 1;
        }
        else if (imaCount == 1)
        {
            ImaTex[4].SetActive(false);
            imaCount -= 1;
        }
    }

    //結果発表Image呼び出し
    public void imaRes()
    {
        if (imaCount == 0)
        {
            ImaTex[5].SetActive(true);
            imaCount += 1;
        }
        else if (imaCount == 1)
        {
            ImaTex[5].SetActive(false);
            imaCount -= 1;
        }
    }

    public void playername()
    {
        ImaTex[6].SetActive(false);
        ImaTex[7].SetActive(false);
    }

    public void PlayerPoint()
    {
        if (pointCount == 0)
        {
            ImaTex[8].SetActive(true);
            ImaTex[9].SetActive(true);
            pointCount += 1;
        }
        else if (pointCount == 1)
        {
            ImaAni[0].SetBool("point", true);
            ImaAni[1].SetBool("point", true);

            pointCount -= 1;
        }
    }
}
