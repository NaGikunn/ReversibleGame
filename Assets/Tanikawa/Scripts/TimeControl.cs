using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public GameObject LoadManeger;

    bool InsOutFlg = false;

    float FirstTime;
    float SecondTime;

    // Use this for initialization
    void Start()
    {
        LoadManeger.SendMessage("CorOut");

        FirstTime = 11.0f;  // 残り時間(表示時にintでキャストするため、初期値をFirstTime+1に)
        SecondTime = 61.0f; // 残り時間(表示時にintでキャストするため、初期値をSecondTime+1に)
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            LoadManeger.SendMessage("CorIn");
        } 
    }
}
