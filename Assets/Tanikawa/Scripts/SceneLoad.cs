using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    private int SquareCount_H = 5;//敷詰横
    private int SquareCount_V = 5;//敷詰縦

    //消滅位置
    private int[,] SquarePos;

    public int FadeEndTiles;

    public bool IsFadeIn = false;
    public bool IsFadeOut = false;

    //消滅間隔
    private float FadeInterval = 0.1f;
    
    // 現在のシーン名
    private string SceneName;
    //次のシーン
    public string NextSceneName;
    //Tile
    public Image[] Tiles;
    private Image[,] Squares;

    //Fade待ち時間
    float LoadInterval = 0.0f;

    AudioSource Fade1;

    void Start()
    {
		FadeEndTiles = 0;
        LoadInterval = 1.0f;
        SceneName = SceneManager.GetActiveScene().name;
        Fade1 = GetComponent<AudioSource>();
		SquareCount_H = 5;//敷詰横
	    SquareCount_V = 5;//敷詰縦
	}

    void Update()
    {
        
    }
    //FadeOut
    public IEnumerator FadeOut()
    {
        IsFadeOut = true;
        //順番にFadeを始める
        int FadeCount = 1;
        while (FadeCount <= SquareCount_H * SquareCount_V)
        {
            for (int i = 0; i < SquareCount_H; i++)
            {
                for (int j = 0; j < SquareCount_V; j++)
                {
                    if (SquarePos[i, j] == FadeCount)
                    {
                        Squares[i, j].GetComponent<FadePanel>().FadeOutStart();
                        FadeCount++;
                        yield return new WaitForSeconds(FadeInterval);
                    }
                }
            }
        }
        while (true)
        {
            if (FadeEndTiles >= SquareCount_H * SquareCount_V)
            {
                IsFadeOut = false;
                FadeEndTiles = 0;
                break;
            }

            yield return new WaitForSeconds(Time.deltaTime);

        }
    }

    public IEnumerator FadeIn()
    {
        IsFadeIn = true;
        //順番にFadeを始める
        int FadeCount = 1;
        while (FadeCount <= SquareCount_H * SquareCount_V)
        {
            for (int i = 0; i < SquareCount_H; i++)
            {
                for (int j = 0; j < SquareCount_V; j++)
                {
                    if (SquarePos[i, j] == FadeCount)
                    {
                        Squares[i, j].GetComponent<FadePanel>().FadeInStart();
                        FadeCount++;
                        yield return new WaitForSeconds(FadeInterval);
                    }
                }
            }
        }
        while (true)
        {
            if (FadeEndTiles >= SquareCount_H * SquareCount_V)
            {
                IsFadeIn = false;
                FadeEndTiles = 0;
                if(SceneName == "MainScene")
                {
                    LoadInterval = 6.5f;
                    yield return new WaitForSeconds(LoadInterval);
                    SceneManager.LoadScene(NextSceneName);
                }
                else
                {
                    LoadInterval = 1.0f;
                }
                yield return new WaitForSeconds(LoadInterval);
                SceneManager.LoadScene(NextSceneName);   // 次のシーンへ
               break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    void Awake()
    {
        //配列宣言
        Squares = new Image[SquareCount_H, SquareCount_V];
        SquarePos = new int[SquareCount_H, SquareCount_V];

        //配列にImage代入
        int Num = 0;
        for (int i = 0; i < SquareCount_H; i++)
        {
            for (int j = 0; j < SquareCount_V; j++)
            {
                Squares[i, j] = Tiles[Num];
                Num++;
            }
        }

        //Fade順決定
        Num = 1;
        while (Num <= SquareCount_H * SquareCount_V)
        {
            int Rand_H = Random.Range(0, SquareCount_H);
            int Rand_V = Random.Range(0, SquareCount_V);

            //配列に先客がいたらやり直し
            if (SquarePos[Rand_H, Rand_V] > 0)
            {
                continue;
            }

            SquarePos[Rand_H, Rand_V] = Num;
            Num++;
        }

    }

    public void ColIn()
    {
        StartCoroutine(FadeIn()); //FadeIn開始
        Fade1.PlayOneShot(Fade1.clip);
    }

    public void ColOut()
    {
        StartCoroutine(FadeOut()); //FadeOut開始
    }
}
