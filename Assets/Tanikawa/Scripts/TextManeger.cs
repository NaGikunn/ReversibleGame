using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManeger : MonoBehaviour {

    
    public Image ImageRes;    //結果発表Image
    public Image ImageEnd;    //終了Image
    public Image ImageDanger; //回転注意Image

    public GameObject TextMaster3; //親子関係を結ぶCanvas

    float Speed = 5.0f; //Imageのスピード乗算用数値

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            imaRes();
        }
    }

    //結果発表Image呼び出し
    public void imaRes()
    {
        Image ImePre1 = (Image)Instantiate(ImageRes);
        ImePre1.transform.SetParent(TextMaster3.transform, false);
        //ImePre1.transform.Translate(-1 * Speed, 0, 0);
    }

    //終了Image呼び出し
    public void imaEnd()
    {
        Image ImePre2 = (Image)Instantiate(ImageEnd);
        ImePre2.transform.SetParent(TextMaster3.transform, false);
        //ImePre2.transform.Translate(0, -1 * Speed, 0);
    }

    //回転注意Image呼び出し
    public void imaDanger()
    {
        Image ImePre3 = (Image)Instantiate(ImageDanger);
        ImePre3.transform.SetParent(TextMaster3.transform, false);
        //ImePre3.transform.Translate(1 * Speed, 0, 0);
    }

}
