using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManeger : MonoBehaviour {
    
    public Image ImageStandby;//よーいImage
    public Image ImageSta;    //始めImage
    public Image ImageNexSta; //ここからImage
    public Image ImageDanger; //回転注意Image
    public Image ImageEnd;    //終了Image 
    public Image ImageRes;    //結果発表Image

    public GameObject TextMaster3; //親子関係を結ぶCanvas

    float Speed = 5.0f; //Imageのスピード乗算用数値

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    //よーいImage呼び出し
    public void imaStandby()
    {
        Image ImePre1 = (Image)Instantiate(ImageStandby);
        ImePre1.transform.SetParent(TextMaster3.transform, false);
        //ImePre1.transform.Translate(1 * Speed, 0, 0);
    }

    //始めImage呼び出し
    public void imaSta()
    {
        Image ImePre2 = (Image)Instantiate(ImageSta);
        ImePre2.transform.SetParent(TextMaster3.transform, false);
        //ImePre3.transform.Translate(1 * Speed, 0, 0);
    }

    //ここからImage呼び出し
    public void imaNexSta()
    {
        Image ImePre3 = (Image)Instantiate(ImageNexSta);
        ImePre3.transform.SetParent(TextMaster3.transform, false);
        //ImePre3.transform.Translate(1 * Speed, 0, 0);
    }

    //回転注意Image呼び出し
    public void imaDanger()
    {
        Image ImePre4 = (Image)Instantiate(ImageDanger);
        ImePre4.transform.SetParent(TextMaster3.transform, false);
        //ImePre3.transform.Translate(1 * Speed, 0, 0);
    }

    //終了Image呼び出し
    public void imaEnd()
    {
        Image ImePre5 = (Image)Instantiate(ImageEnd);
        ImePre5.transform.SetParent(TextMaster3.transform, false);
        ImePre5.transform.Translate(0, -1 * Speed, 0);
    }

    //結果発表Image呼び出し
    public void imaRes()
    {
        Image ImePre6 = (Image)Instantiate(ImageRes);
        ImePre6.transform.SetParent(TextMaster3.transform, false);
        //ImePre1.transform.Translate(-1 * Speed, 0, 0);
    }
}
