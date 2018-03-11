using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSplash : MonoBehaviour
{
    GameObject ImaSplash;
    AudioSource HitAs;
    // Use this for initialization
    void Start ()
    {
        ImaSplash = (GameObject)Resources.Load("Prefab/Splash");
        HitAs = GetComponent<AudioSource>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ResPleCube"))
        {
            Instantiate(ImaSplash);
			HitAs.PlayOneShot(HitAs.clip);
		}
    }

    //IEnumerator InsSpl()
    //{
    //    while(true)
    //    {
    //        Instantiate(ImaSplash);
    //        yield return new WaitForSeconds(0.5f);
    //        yield return null;
    //    }
    //}
	
	// Update is called once per frame
	void Update ()
    {
		Destroy(this.gameObject, 15.0f);
	}
}
