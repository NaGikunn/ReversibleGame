using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoad2 : MonoBehaviour
{
    private int SquareCount_H = 2;//敷詰横
    private int SquareCount_V = 2;//敷詰縦

    public Image[] RoteTile;
    private Image[,] Squares;

    // Use this for initialization
    void Start()
    {
        //配列宣言
        Squares = new Image[SquareCount_H, SquareCount_V];

        //配列にImage代入
        int Num = 0;
        for (int i = 0; i < SquareCount_H; i++)
        {
            for (int j = 0; j < SquareCount_V; j++)
            {
                Squares[i, j] = RoteTile[Num];
                Num++;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}
}
