using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    public GameObject LoadManeger; //LoadManegerを設定する

    public Text FirstTimeLabel;   // 最初用TimeText
    public Text SecondTimeLabel;  // 本番用TimeText

    float FirstTime;　　// 最初の10秒（ポイント取り合い）
    float SecondTime;　 // 本番の60秒（キューブが回り始める）

    public static bool secondtimeFlg;　// 本番のTimeを作動させるためflg

    // Use this for initialization
    void Start()
    {
        LoadManeger.SendMessage("ColOut");　// 1番最初にフェードアウトを呼び出す

        secondtimeFlg = false; // 最初の10秒が終わるまで

        FirstTime = 11.0f;  // 残り時間(表示時にintでキャストするため、初期値をFirstTime+1に)
        SecondTime = 61.0f; // 残り時間(表示時にintでキャストするため、初期値をSecondTime+1に)

        // 本番用Timeはじめは非表示
        SecondTimeLabel.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
    }
    // Update is called once per frame
    void Update()
    {
        Invoke("First", 15.0f); //最初用Time遅延

        // 本番用Time開始
        if(FirstTime==0.0f)
        {
            secondtimeFlg = true;
            Invoke("Second", 5.0f);
        }

        // 本番用Time終了時
        if (SecondTime == 0.0f)
        {           
            LoadManeger.SendMessage("ColIn");
            return;
        }

        // 残り時間を2桁で表示
        FirstTimeLabel.text = string.Format("{0:00}", (int)FirstTime);
        SecondTimeLabel.text = string.Format("{0:00}", (int)SecondTime);
    }
    // 最初用Time
    public void First()
    {
        FirstTime -= Time.deltaTime;             // 1フレームにかかる時間を引く
        FirstTime = Mathf.Max(FirstTime, 0.0f);   // マイナス時間にならないように
    }

    // 本番用Time
    public void Second()
    {
        FirstTimeLabel.GetComponent<CanvasRenderer>().SetAlpha(0.0f);//最初用Timeを非表示
        SecondTimeLabel.GetComponent<CanvasRenderer>().SetAlpha(1.0f);// 本番用Timeを表示

        SecondTime -= Time.deltaTime;             // 1フレームにかかる時間を引く
        SecondTime = Mathf.Max(SecondTime, 0.0f);   // マイナス時間にならないように
    }
}
