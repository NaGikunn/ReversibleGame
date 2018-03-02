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
        //左に動かす
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("Next2", true);
            animator.SetBool("Back1", false);
            plasScrollflg = true;
        }


       

        //右に動かす
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("Back1", true);
            animator.SetBool("Next2", false);
            minusScrollflg = true;
        }
      

       


        if (Scrollx==-60.0f)
        {
            //scrNext = -45.0f;
            Debug.Log("LastExp");

           if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Back");
            }
        }
      

        //ExplainManeger.position = new Vector3(Mathf.Clamp(Scrollx, -60, 0), 1,0);

            //二つの間の値にする
            //Transform ExplainManeger;
            //float downPos;
            //float touchPos;
            //// Use this for initialization
            //void Start()
            //{
            //    ExplainManeger = GetComponent<Transform>();
            //}

            //// Update is called once per frame
            //void Update()
            //{

            //    if (Input.GetMouseButton(0))
            //    {
            //        touchPos = Input.mousePosition.x;
            //        //Debug.Log(touchPos);
            //        if (Input.GetMouseButtonDown(0))
            //        {
            //            downPos = Input.mousePosition.x;
            //        }
            //    }
            //    float TouchMove = touchPos - downPos;
            //    ////Debug.Log(TouchPosition());
            //    downPos = touchPos;
            //    //if (IsTouched())
            //    //{

            //    //    //両方
            //    float moveX = ExplainManeger.position.x + TouchMove;

            //    ExplainManeger.position = new Vector2(Mathf.Clamp(moveX, -60, 0), 1);//二つの間の値にする
            //}
    }
}
