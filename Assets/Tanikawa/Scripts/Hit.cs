using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public GameObject white;

	// Use this for initialization
	void Start ()
    {
        Vector3 StartPos = new Vector3(0.0f, 0.75f, 0.0f);

		white= (GameObject)Resources.Load("Prefab/WhiteHit");

        transform.position = StartPos;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}
}
