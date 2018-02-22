using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFade : MonoBehaviour
{
    public GameObject LoadManeger;

    bool InsInFlg = false;

    void Start()
    {
        LoadManeger.SendMessage("CorOut");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            InsInFlg = true;
            if (InsInFlg == true)
            {
                LoadManeger.SendMessage("CorIn");
                InsInFlg = false;
            }
        }
    }
}
