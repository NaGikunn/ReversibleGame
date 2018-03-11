using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffWall : MonoBehaviour
{
    public Animator OffCamera;

    AudioSource WinAs;

	// Use this for initialization
	void Start ()
    {
        WinAs = GetComponent<AudioSource>();	
	}
	
    void OnTriggerEnter(Collider other)
    {
        OffCamera.SetBool("MoveB", true);
        WinAs.PlayOneShot(WinAs.clip);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
