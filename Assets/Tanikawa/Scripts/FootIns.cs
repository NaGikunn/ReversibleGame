using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootIns : MonoBehaviour
{
    GameObject FootB;
    GameObject FootW;

	// Use this for initialization
	void Start ()
    {
        FootB = (GameObject)Resources.Load("Prefab/P_Tex_Foot(B)");
        FootW = (GameObject)Resources.Load("Prefab/P_Tex_Foot(W)");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Instantiate(FootB);
            Debug.Log("kuro");
        }

        if (Input.GetKey(KeyCode.A))
        {
            Instantiate(FootW);
            Debug.Log("shiro");
        }
    }
}
