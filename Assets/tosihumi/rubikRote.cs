using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rubikRote : MonoBehaviour {

    int[,] hairetu;
    public GameObject ga;
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
                if (hairetu[j, i] >= 0)
                {
                    // Instantiate(ga).transform.position(x+ i, y+ j);
                }
            }
        }
    }
	// Update is called once per frame
	void Update () {
	}
    public void rote()
    {

    }
}
