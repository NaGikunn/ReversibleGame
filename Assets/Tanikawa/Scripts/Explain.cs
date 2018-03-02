using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explain : MonoBehaviour
{
    Transform ExplainManeger;

    public float Scrollx; //現在のページ数（0=1ページ目、-15=2ページ目）
    float scrMax = 15.0f;
    float scrMin = -15.0f;
    public float scrNext;

    bool plasScrollflg;
    bool minusScrollflg;

    public int count = 0;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        plasScrollflg = false;
        minusScrollflg = false;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            plasScrollflg = true;

            if (plasScrollflg == true)
            {
                count += 1;
                leftScr();
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
           minusScrollflg = true;

            if (minusScrollflg == true&&count>0)
            {
                count -= 1;
                RightScr();
            }
        }

        if (count == 4)
        {
            Debug.Log("LastExp");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Back");
            }
        }
    }
    void leftScr()
    {
        if (count == 1)
        {
            animator.SetBool("Next2", true);
            animator.SetBool("Back1", false);
            plasScrollflg = false;
        }
        if (count == 2)
        {
            animator.SetBool("Next3", true);
            animator.SetBool("Back2", false);
            animator.SetBool("Next2", false);
            plasScrollflg = false;
        }
        if (count == 3)
        {
            animator.SetBool("Next4", true);
            animator.SetBool("back3", false);
            animator.SetBool("Next3", false);
            plasScrollflg = false;
        }
        if (count == 4)
        {
            animator.SetBool("Next5", true);
            animator.SetBool("Back4", false);
            animator.SetBool("Next4", false);
            plasScrollflg = false;
        }
    }
    void RightScr()
    {
        //右に動かす
        if (count == 0)
        {
            animator.SetBool("Back1", true);
            animator.SetBool("Next2", false);
            animator.SetBool("Back2", false);
            plasScrollflg = false;
        }
        if (count == 1)
        {
            animator.SetBool("Back2", true);
            animator.SetBool("Next3", false);
            animator.SetBool("Back3", false);
            plasScrollflg = false;
        }
        if (count == 2)
        {
            animator.SetBool("Back3", true);
            animator.SetBool("Next4", false);
            animator.SetBool("Back4", false);
            plasScrollflg = false;
        }
        if (count == 3)
        {
            animator.SetBool("Back4", true);
            animator.SetBool("Next5", false);
            animator.SetBool("Back5", false);
            plasScrollflg = false;
        }
    }
}
