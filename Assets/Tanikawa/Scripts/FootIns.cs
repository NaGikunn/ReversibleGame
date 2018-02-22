using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootIns : MonoBehaviour
{
    public GameObject FootB,FootW;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            GameObject obj = Instantiate(FootB) as GameObject;
            Debug.Log("kuro");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //Instantiate(FootW);
            GameObject obj = Instantiate(FootW) as GameObject;
            Debug.Log("shiro");
        }
    }
}
