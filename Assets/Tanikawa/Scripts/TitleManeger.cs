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

    AudioSource standbyAS;

    void Start()
    {
        LoadManeger2.GetComponent<SceneLoad>().ColOut();

        Standbyflg1 = false;
        Standbyflg2 = false;

        standbyAS = GetComponent<AudioSource>();
       
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Standbyflg1 = true;
            paint1.SetBool("move", true);
            standbyAS.PlayOneShot(standbyAS.clip);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Standbyflg2 = true;
            paint2.SetBool("Move", true);
            standbyAS.PlayOneShot(standbyAS.clip);
        }

        if(Standbyflg1==true&&Standbyflg2==true)
        {
            Invoke("TitleFade", 2.5f);
        }
            
    }

    public void TitleFade()
    {
        LoadManeger2.GetComponent<SceneLoad>().ColIn();
    }
}
