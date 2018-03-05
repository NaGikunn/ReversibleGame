using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    public GameObject LoadManeger2; //LoadManegerを設定する
    public GameObject TextMaster3;

    public Text FirstTimeLabel;   // 最初用TimeText
    public Text SecondTimeLabel;  // 本番用TimeText

    float FirstTime;　　// 最初の10秒（ポイント取り合い）
    float SecondTime;  // 本番の60秒（キューブが回り始める）

    bool firstTimeflg;   //最初のTimeを作動させるためのflg
    bool secondTimeflg;  //本番のTimeを作動させるためのflg

    AudioSource Count;
    AudioSource CountUp;
    AudioSource ResultDrum;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("TimeCoroutine");

        LoadManeger2.GetComponent<SceneLoad>().ColOut();

        TextMaster3 = GameObject.Find("TextMaster3");

        firstTimeflg = false;
        secondTimeflg = false;

        FirstTime = 11.0f;  // 残り時間(表示時にintでキャストするため、初期値をFirstTime+1に)
        SecondTime = 61.0f; // 残り時間(表示時にintでキャストするため、初期値をSecondTime+1に)

        // Timeは最初は非表示
        FirstTimeLabel.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
        SecondTimeLabel.GetComponent<CanvasRenderer>().SetAlpha(0.0f);

        AudioSource[] mainAS = GetComponents<AudioSource>();
        Count = mainAS[0];
        CountUp = mainAS[1];
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (firstTimeflg==true)
        {
            FirstTimeLabel.GetComponent<CanvasRenderer>().SetAlpha(1.0f);//最初用Timeを表示

            FirstTime -= Time.deltaTime;             // 1フレームにかかる時間を引く
            FirstTime = Mathf.Max(FirstTime, 0.0f);   // マイナス時間にならないように

            if (FirstTime == 0.0f)
            {
                FirstTimeLabel.GetComponent<CanvasRenderer>().SetAlpha(0.0f);//最初用Timeを非表示
            }
        } 

       if(secondTimeflg==true)
        {
            SecondTimeLabel.GetComponent<CanvasRenderer>().SetAlpha(1.0f);// 本番用Timeを表示

            SecondTime -= Time.deltaTime;             // 1フレームにかかる時間を引く
            SecondTime = Mathf.Max(SecondTime, 0.0f);   // マイナス時間にならないように

        }

        // 残り時間を2桁で表示
        FirstTimeLabel.text = string.Format("{0:00}", (int)FirstTime);
        SecondTimeLabel.text = string.Format("{0:00}", (int)SecondTime);
    }

    IEnumerator TimeCoroutine()
    {
        TextMaster3.GetComponent<TextManeger>().imaStandby();
        yield return new WaitForSeconds(5.0f);

        TextMaster3.GetComponent<TextManeger>().imaSta();
        firstTimeflg = true;
        Debug.Log("First");

        yield return new WaitForSeconds(11.0f);
        if(FirstTime==0.0f)
        {
            CountUp.PlayOneShot(CountUp.clip);
        }

        TextMaster3.GetComponent<TextManeger>().imaNexSta();
        yield return new WaitForSeconds(2.0f);
        TextMaster3.GetComponent<TextManeger>().imaStandby();

        yield return new WaitForSeconds(2.0f);
        TextMaster3.GetComponent<TextManeger>().imaSta();
        secondTimeflg = true;
        Debug.Log("Second");
        yield return new WaitForSeconds(61.0f);
        if (SecondTime==0.0f)
        {
            CountUp.PlayOneShot(CountUp.clip);
            TextMaster3.GetComponent<TextManeger>().imaEnd();
            LoadManeger2.GetComponent<SceneLoad>().ColIn();
        }
        yield return new WaitForSeconds(3.0f);
        TextMaster3.GetComponent<TextManeger>().imaRes();
        
    }


    //// 最初用Time
    //public void First()
    //{
    //    firstTimeflg = true;
    //    Debug.Log("First");
    //}

    //public void FirstExit()
    //{
    //    CountUp.PlayOneShot(CountUp.clip);
    //    FirstTimeLabel.GetComponent<CanvasRenderer>().SetAlpha(0.0f);//最初用Timeを非表示
    //}

    //// 本番用Time
    //public void Second()
    //{
    //    //TextMaster3.GetComponent<TextManeger>().imaSta();
    //    secondTimeflg = true;
    //    Debug.Log("Second");
    //}
}

   

