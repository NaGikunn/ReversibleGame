using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    public GameObject LoadManeger2; //LoadManeger2を設定する
    public GameObject TextMaster3;  //TextMaster3を設定する
    public GameObject cCube;　　　　//回転を呼び出すcCubeを設定する

    public Text FirstTimeLabel;   // 最初用TimeText
    public Text SecondTimeLabel;  // 本番用TimeText

    float FirstTime;　　// 最初の10秒（ポイント取り合い）
    public static float SecondTime;  // 本番の60秒（キューブが回り始める）
    float RoteTime;　　//cCubeを呼び出すためのカウント

    bool firstTimeflg;   //最初のTimeを作動させるためのflg
    bool secondTimeflg;  //本番のTimeを作動させるためのflg

    AudioSource Count;　　　 //残り10秒になったら鳴る音
    AudioSource CountUp;　　 //0秒になったらなる音
    AudioSource ResultDrum;　//リザルトに移動する前になる音
    AudioSource BGM2;  //メインBGM
    AudioSource BGM3;　//残り10秒のBGM

    // Use this for initialization
    void Start()
    {
        LoadManeger2.GetComponent<SceneLoad>().ColOut();//最初はフェードアウトから

        StartCoroutine("TimeCoroutine");

        TextMaster3 = GameObject.Find("TextMaster3");//TextMaster3を呼び出す

        // flg最初はfalse
        firstTimeflg = false;
        secondTimeflg = false;

        FirstTime = 11.0f;  // 残り時間(表示時にintでキャストするため、初期値をFirstTime+1に)
        SecondTime = 61.0f; // 残り時間(表示時にintでキャストするため、初期値をSecondTime+1に)
        RoteTime = 0.0f;

        // Timeは最初は非表示
        FirstTimeLabel.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
        SecondTimeLabel.GetComponent<CanvasRenderer>().SetAlpha(0.0f);

        //mainASにサウンドを設定
        AudioSource[] mainAS = GetComponents<AudioSource>();
        Count = mainAS[0];
        CountUp = mainAS[1];
        ResultDrum = mainAS[2];
        BGM2 = mainAS[3];
        BGM3 = mainAS[4];
       }
    
    
    // Update is called once per frame
    void Update()
    {
        // 最初用Time
        if (firstTimeflg==true)
        {
            FirstTimeLabel.GetComponent<CanvasRenderer>().SetAlpha(1.0f);//最初用Timeを表示

            FirstTime -= Time.deltaTime;             // 1フレームにかかる時間を引く
            FirstTime = Mathf.Max(FirstTime, 0.0f);   // マイナス時間にならないように
        }
        // 最初用Time終了時
        if (FirstTime == 0.0f)
        {
            FirstTimeLabel.GetComponent<CanvasRenderer>().SetAlpha(0.0f);//最初用Timeを非表示
        }

        // 本番用Time
        if (secondTimeflg==true)
        {
            SecondTimeLabel.GetComponent<CanvasRenderer>().SetAlpha(1.0f);// 本番用Timeを表示

            SecondTime -= Time.deltaTime;             // 1フレームにかかる時間を引く
            SecondTime = Mathf.Max(SecondTime, 0.0f);   // マイナス時間にならないように
            if (SecondTime >= 9.0f)
            {
                RoteTime -= Time.deltaTime;
                RoteTime = Mathf.Max(RoteTime, 0.0f);
                if (RoteTime == 0.0f)
                {
                    cCube.GetComponent<StageMake>().RandomRote();
                    RoteTime = 10.0f;
                    Debug.Log("RoteTime");
                }
            }
        }

        // 残り時間を2桁で表示
        FirstTimeLabel.text = string.Format("{0:00}", (int)FirstTime);
        SecondTimeLabel.text = string.Format("{0:00}", (int)SecondTime);
    }

    IEnumerator TimeCoroutine()
    {
        yield return new WaitForSeconds(3.0f);
        BGM2.Play();

        //移動直後の準備用処理
        yield return new WaitForSeconds(3.0f);
        TextMaster3.GetComponent<TextManeger>().imaStandby();
        yield return new WaitForSeconds(5.0f);
        TextMaster3.GetComponent<TextManeger>().imaStandby();

        // 最初用Time発動
        yield return new WaitForSeconds(0.2f);
        TextMaster3.GetComponent<TextManeger>().imaSta();
        yield return new WaitForSeconds(0.2f);
        TextMaster3.GetComponent<TextManeger>().playername();
        yield return new WaitForSeconds(0.2f);
        TextMaster3.GetComponent<TextManeger>().PlayerPoint();
        yield return new WaitForSeconds(1.0f);
        firstTimeflg = true;
        Debug.Log("First");
        yield return new WaitForSeconds(0.1f);
        TextMaster3.GetComponent<TextManeger>().imaSta();
        yield return new WaitForSeconds(FirstTime);

        // 最初用Time終了時
        if (FirstTime==0.0f)
        {
            FirstTimeLabel.GetComponent<CanvasRenderer>().SetAlpha(0.0f);//最初用Timeを非表示
            CountUp.PlayOneShot(CountUp.clip);
        }
        TextMaster3.GetComponent<TextManeger>().imaNexSta();
        yield return new WaitForSeconds(7.0f);
        TextMaster3.GetComponent<TextManeger>().imaNexSta();
        yield return new WaitForSeconds(0.2f);
        TextMaster3.GetComponent<TextManeger>().imaStandby();

        // 本番用Time発動
        yield return new WaitForSeconds(2.0f);
        TextMaster3.GetComponent<TextManeger>().imaStandby();
        yield return new WaitForSeconds(0.2f);
        TextMaster3.GetComponent<TextManeger>().imaSta();
        yield return new WaitForSeconds(1.0f);
        TextMaster3.GetComponent<TextManeger>().imaSta();
        secondTimeflg = true;
        Debug.Log("Second");
        yield return new WaitForSeconds(30.0f);
        TextMaster3.GetComponent<TextManeger>().PlayerPoint();
        yield return new WaitForSeconds(20.0f);
        BGM2.Stop();
        yield return new WaitForSeconds(1.0f);
        BGM3.Play();
        yield return new WaitForSeconds(SecondTime);

        // 本番用Time終了時
        if (SecondTime==0.0f)
        {
            CountUp.PlayOneShot(CountUp.clip);
            TextMaster3.GetComponent<TextManeger>().imaEnd();
            LoadManeger2.GetComponent<SceneLoad>().ColIn();
            BGM3.Stop();
        }

        // リザルト移動前の処理
        yield return new WaitForSeconds(3.0f);
        TextMaster3.GetComponent<TextManeger>().imaEnd();
        yield return new WaitForSeconds(0.2f);
        TextMaster3.GetComponent<TextManeger>().imaRes();
        ResultDrum.PlayOneShot(ResultDrum.clip);
        yield return new WaitForSeconds(8.0f);
        TextMaster3.GetComponent<TextManeger>().imaRes();
    }
}

   

