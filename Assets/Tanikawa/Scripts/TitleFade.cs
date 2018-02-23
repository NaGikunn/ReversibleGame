using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFade : MonoBehaviour
{
    public GameObject LoadManeger;

    bool InsInFlg = false;

    void Start()
    {
        LoadManeger.SendMessage("ColOut");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            InsInFlg = true;
            if (InsInFlg == true)
            {
                LoadManeger.SendMessage("ColIn");
                InsInFlg = false;
            }
        }
    }
}
