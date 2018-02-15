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
        alpha = 1.0f;

        FootA.color = new Color(FootA.color.r, FootA.color.g, FootA.color.b, alpha);
    }
	
	// Update is called once per frame
	void Update ()
    {
        alpha -= 0.01f;
        FootA.color = new Color(FootA.color.r, FootA.color.g, FootA.color.b, alpha);
        if (alpha <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
