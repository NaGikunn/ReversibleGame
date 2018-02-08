using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitW : MonoBehaviour
{
    public GameObject white;

    bool OnHit = false;

	// Use this for initialization
	void Start ()
    {
        Vector3 StartPos = new Vector3(0.0f, 0.75f, 0.0f);

		white= (GameObject)Resources.Load("Prefab/WhiteHit");

        transform.position = StartPos;

        OnHit =true;
    }

    public void Effecter()
    {
        
    }

    // Update is called once per frame
    void Update ()
    {
       if(OnHit==true)
        {
            Instantiate(white, transform.position, transform.rotation);
            OnHit = false;
        }
    }
}
