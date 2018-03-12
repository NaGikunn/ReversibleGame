using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explain : MonoBehaviour
{
    bool plasScrollflg; //ページを進めるために使うflg
    bool minusScrollflg;//ページを戻すために使うflg

    public int count = 0;//増えることで左に、減ることで右に移動する。

    Animator animator;

    AudioSource LoadFlick;

    // Use this for initialization
    void Start()
    {
        plasScrollflg = false;
        minusScrollflg = false;

        animator = GetComponent<Animator>();

        LoadFlick = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            plasScrollflg = true;

            if (plasScrollflg == true&&count<4)
            {
                count += 4;
                leftScr();
            }
        }

        //if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //   minusScrollflg = true;

        //    if (minusScrollflg == true&&count>0)
        //    {
        //        count -= 1;
        //        //RightScr();
        //    }
        //}

        if (count == 4)
        {
            Debug.Log("LastExp");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainScene");
            }
        }
    }

    //ページ進む
    void leftScr()
    {
        if (count == 4)
        {
            LoadFlick.PlayOneShot(LoadFlick.clip);
            animator.SetBool("Next2", true);
            //animator.SetBool("Back1", false);
            plasScrollflg = false;
        }
    }

}
