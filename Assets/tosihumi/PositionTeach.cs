using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTeach : MonoBehaviour {
    int x, y, z;
    StageMake stmk;
    // Use this for initialization
    void Start ()
	{
        stmk = GameObject.Find("StageMake").GetComponent<StageMake>();//スクリプト読み込み
    }
	
	// Update is called once per frame
	void Update () {
        //自身のposition取得なぜかメソット読み出しで取得できないオブジェクトがあったのでアップデートに書いた
        x = (int)Mathf.Round(transform.position.x);
        y = (int)Mathf.Round(transform.position.y);
        z = (int)Mathf.Round(transform.position.z);
    }
    public void ArrayChange()
    {
        stmk.kariRubuk[x+2, y+4, z+2] = gameObject;
    }
}
