using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    GameObject WhiteOsero;
    GameObject BlackOsero;

    // Use this for initialization
    void Start ()
    {
        WhiteOsero = (GameObject)Resources.Load("Prefab/oseroW");
        BlackOsero = (GameObject)Resources.Load("Prefab/oseroB");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(WhiteOsero);

        }	

        if(Input.GetMouseButtonDown(1))
        {
            Instantiate(BlackOsero);
        }
	}
}
