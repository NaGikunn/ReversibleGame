using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubik : MonoBehaviour {
    Vector2 spos;//タッチした時の座標
    Vector2 dpos;//動かしている時の座標
    Quaternion srot;//タッチした時の回転
    float wid, hei, diag;  //スクリーンサイズ
    float tx, ty;    //変数
    // Use this for initialization
    void Start () {
        wid = Screen.width;//スクリーンサイズ取得
        hei = Screen.height;//スクリーンサイズ取得
        diag = Mathf.Sqrt(Mathf.Pow(wid, 2) + Mathf.Pow(hei, 2));
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetMouseButton(0)){
            spos = Input.mousePosition;//座標取得
            srot = transform.rotation;
            if (Input.GetMouseButtonDown(0)){
                dpos = Input.mousePosition;//座標取得
            }
        }
        tx = (dpos.x - spos.x)/ wid;//X座標同士を引いてスクリーンサイズで÷
        ty = (dpos.y - spos.y)/ hei;//ｙ座標同士を引いてスクリーンサイズで÷
        transform.rotation = srot;
        transform.Rotate(new Vector3(-20 * ty, 20 * tx,0), Space.World);
    }
}
