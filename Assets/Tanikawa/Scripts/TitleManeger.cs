using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManeger : MonoBehaviour {

    public GameObject LoadManeger2;

    public Animator paint1;
    public Animator paint2;

    bool Standbyflg1;
    bool Standbyflg2;
    bool StandbyOk;

    AudioSource standbyAS;

    void Start()
    {
        LoadManeger2.GetComponent<SceneLoad>().ColOut();

        Standbyflg1 = false;
        Standbyflg2 = false;
        StandbyOk = true;

        standbyAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Standbyflg1==false)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                paint1.SetBool("move", true);
                standbyAS.PlayOneShot(standbyAS.clip);
                Standbyflg1 = true;
                Debug.Log("1P_StandBy");
            }
        }
        if(Standbyflg2==false)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                paint2.SetBool("Move", true);
                standbyAS.PlayOneShot(standbyAS.clip);
                Standbyflg2 = true;
                Debug.Log("2P_StandBy");
            }
        }
        if(StandbyOk==true)
        {
            if (Standbyflg1 == true && Standbyflg2 == true)
            {
                Invoke("TitleFade", 2.5f);
                StandbyOk = false;
            }
        }
    }

    public void TitleFade()
    {
        LoadManeger2.GetComponent<SceneLoad>().ColIn();
    }
}
