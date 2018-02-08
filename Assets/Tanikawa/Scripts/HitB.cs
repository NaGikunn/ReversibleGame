using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitB : MonoBehaviour
{
    public GameObject Black;

    bool OnHit = false;

    // Use this for initialization
    void Start()
    {
        Vector3 StartPos = new Vector3(-1.0f, 0.75f, 0.0f);

        Black = (GameObject)Resources.Load("Prefab/BlackHit");

        transform.position = StartPos;

        OnHit = true;
    }

    public void Effecter()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (OnHit == true)
        {
            Instantiate(Black, transform.position, transform.rotation);
            OnHit = false;
        }
    }
}
