using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Foot : MonoBehaviour
{
    public SpriteRenderer FootA;

    float alpha;

	// Use this for initialization
	void Start ()
    {
        FootA.color = new Color(FootA.color.r, FootA.color.g, FootA.color.b, alpha);
    }
	
	// Update is called once per frame
	void Update ()
    {
        alpha -= 0.1f;
    }
}
