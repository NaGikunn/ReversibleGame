using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explain : MonoBehaviour
{
    Transform ExplainManeger;

    float Scrollx; //ページごとの移動距離（ここにscrMaxを入れるとページが変わる）
    float scrMax = 15.0f; //加算数値の最大値

    bool plasScrollflg;
    bool minusScrollflg;

    // Use this for initialization
    void Start()
    {
        plasScrollflg = false;
        minusScrollflg = false;

        Scrollx = 0.0f;
        ExplainManeger = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Scrollx, 1, 0);

        if (Input.GetKeyDown(KeyCode.A))
        {
            minusScrollflg = true;
        }

        if (minusScrollflg == true)
        {
            if (Scrollx > -scrMax)
            {
                Scrollx--;
            }
            else if (Scrollx == -scrMax)
            {
                scrMax = scrMax + 15.0f;
                minusScrollflg = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            plasScrollflg = true;
        }

        if(plasScrollflg == true)
        {
            if(Scrollx>scrMax)
            {
                Scrollx++;
            }
            else if(Scrollx==scrMax)
            {
                scrMax = scrMax + 15.0f;
                plasScrollflg = false;
            }
        }


        if (Scrollx==60.0f)
        {
            Debug.Log("LastExp");

           if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("Back");
            }
        }

        ExplainManeger.position = new Vector3(Mathf.Clamp(Scrollx, -60, 0), 1,0);

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
