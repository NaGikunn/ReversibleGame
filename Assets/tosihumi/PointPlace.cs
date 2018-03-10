using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPlace : MonoBehaviour {
    Renderer ren;//自身のレンダラ―を取得するため
    StageMake StageM;//StageMakeを読み込む準備枠
    string names;//materialの名前を入れる
    bool SustainalePoint;//継続点を定期的に呼び出すため
    public static bool point;//プレイヤーがマテリアルを変更した時に呼び出される
	
	// Use this for initialization
	void Start () {
        point = false;//プレイヤーがマテリアルを変更した時にtrueになる
        StageM = GameObject.Find("StageMake").GetComponent<StageMake>();
        ren = GetComponent<Renderer>();
        SustainalePoint = true;//継続点を定期的に呼び出す
	}
	// Update is called once per frame
	void Update () {
        if(ren.material.name== "PrintMatPlayer1"&&point==true)
        {
            StageM.Bpoint+=1;//ポイントマスを獲得した回数を入れている
            point = false;
        }
        else if(ren.material.name == "PrintMatPlayer2"&& point == true)
        {
            StageM.Wpoint += 1;//ポイントマスを獲得した回数を入れている
            point = false;
        }
        if (SustainalePoint)
        {
            SustainalePoint = false;
            StartCoroutine("ContinuationPoint");
        }
    }
    IEnumerator ContinuationPoint()//持続点を定期的にプラスしたりマイナスしたりする
    {
        yield return new WaitForSeconds(5);
        if(ren.material.name== "PrintMatPlayer1")//黒のとき
        {
            if (names == ren.material.name)//現在のマテリアルの名前比較
            {
                StageM.BpointContinuation += 1;//一緒だったら継続ポイントにプラスする
            }
            else if (names != ren.material.name)
            {
                names = ren.material.name;//違ったらnamesに名前を入れる
                StageM.WpointContinuation -= 1;//白色の継続ポイントをマイナスにする
            }
        }else if(ren.material.name == "PrintMatPlayer2")//白のとき
        {
            if (names == ren.material.name)
            {
                StageM.WpointContinuation += 1;
            }
            else if (names != ren.material.name)
            {
                names = ren.material.name;
                StageM.BpointContinuation -= 1;
            }
        }
        SustainalePoint = true;
    }
}
