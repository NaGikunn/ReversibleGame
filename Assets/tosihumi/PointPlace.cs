using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPlace : MonoBehaviour {
	Renderer ren;//自身のレンダラ―を取得するため
	StageMake StageM;//StageMakeを読み込む準備枠
	string names;//materialの名前を入れる
	bool SustainalePoint;//継続点を定期的に呼び出すため
	public static bool Bpoint;//プレイヤーがマテリアルを変更した時に呼び出される
	public static bool Wpoint;
	private int i = 0;
	public static int CountB;
	public static int CountW;
	// Use this for initialization
	void Start()
	{
		Bpoint = false;//プレイヤーがマテリアルを変更した時にtrueになる
		Wpoint = false;
		StageM = GameObject.Find("StageMake").GetComponent<StageMake>();
		ren = GetComponent<Renderer>();
		SustainalePoint = true;//継続点を定期的に呼び出す
		names = ren.material.name;
	}
	// Update is called once per frame
	void Update()
	{
		CountB = StageM.Bpoint;
		CountW = StageM.Wpoint;

		if (ren.material.name == "PrintMatPlayer1 (Instance)" && Bpoint == true)
		{
			if (i == 0 || i == 2)
			{
				StageM.Bpoint += 1;//ポイントマスを獲得した回数を入れている
				Bpoint = false;
				i = 1;
			}
		}
		if (ren.material.name == "PrintMatPlayer2 (Instance)" && Wpoint == true)
		{
			if (i == 0 || i == 1)
			{
				StageM.Wpoint += 1;//ポイントマスを獲得した回数を入れている
				Wpoint = false;
				i = 2;
			}
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
		if (ren.material.name == "PrintMatPlayer1 (Instance)")//黒のとき
		{
			if (names == ren.material.name)//現在のマテリアルの名前比較
			{
				StageM.Bpoint += 1;//一緒だったら継続ポイントにプラスする
			}
			else if (names == "PrintMatPlayer2 (Instance)")
			{
				names = ren.material.name;//違ったらnamesに名前を入れる
				StageM.Wpoint -= 1;//白色の継続ポイントをマイナスにする
			}
			else if (names == "CountMaterial (Instance)")
			{
				names = ren.material.name;//違ったらnamesに名前を入れる
			}
		}
		else if (ren.material.name == "PrintMatPlayer2 (Instance)")//白のとき
		{
			if (names == ren.material.name)
			{
				StageM.Wpoint += 1;
			}
			else if (names == "PrintMatPlayer1 (Instance)")
			{
				names = ren.material.name;
				StageM.Bpoint -= 1;
			}
			else if (names == "CountMaterial (Instance)")
			{
				names = ren.material.name;//違ったらnamesに名前を入れる
			}
		}
		SustainalePoint = true;
	}
}
