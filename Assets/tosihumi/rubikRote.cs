using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rubikRote : MonoBehaviour {

    int[,] hairetu;
    public GameObject ga;//盤面にするオブジェクト
    bool Order;//手版を今どちらにあるかを判定する
    float downx,downy;//マウスポジションがどちらにうごいたか（ダウンバージョン）
    float upx,upy;//マウスポジションがどちらにうごいたか（アップバージョン）
    int tposx, tposy;//配列データを取得する際のポジション
    // Use this for initialization
    void Start() {
        /*配列データは‐１はキューブで使わない部分
         ０の部分は駒が現在おかれていない場所
         １が白駒がおかれている場所
         ２が黒駒がおかれている場所
         */
        for (int i = 0; i >= 16; i++)
        {
            for (int j = 0; j >= 12; j++)
            {
                hairetu[j, i] = -1;
                if (4 <= j && j <= 8)
                {
                    hairetu[j, i] = 0;
                }
                if (4 <= i && i <= 8)
                {
                    hairetu[j, i] = 0;
                }

            }
        }
    }
	// Update is called once per frame
	void Update () {
	}
    public void rote()
    {
        /*回る時に配列だけで回してる時に
         * ここから変更している*/
        float moveposx, moveposy;
        moveposx =upx - downx;
        moveposy =upy - downy;
        if (moveposy < moveposx)
        {
            
        }
        else if (moveposy > moveposx)
        {
            //hairetu[,]j+4;
        }
        
    }
    void TouchPos()
    {
        /*盤面をタッチしたpositionを取得してその場所の
         * 配列データを持ってきて何かする*/
        if (Input.GetMouseButtonDown(0))
        {
            
            //downx = mousePositiondown(x);
            //downy = mousePositiondown(y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //upx = mousePositionup(x);
            //upy = mousePositionup(y);
        }
    }
    void Framepos()
    {
        /*盤面をタッチした時にその場所にオブジェクトが置いてるかを
         * 確認して置いてなかったら配列データ内に１か２をいれる*/
        //hairetu[,]=1or2;
    }
}
