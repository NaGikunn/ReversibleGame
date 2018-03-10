using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSplash : MonoBehaviour
{
    GameObject ImaSplash;

    // Use this for initialization
    void Start ()
    {
        ImaSplash = (GameObject)Resources.Load("Prefab/Splash");
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ResPleCube"))
        {
            Instantiate(ImaSplash);
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
        Destroy(this.gameObject,10.0f);
    }

}
