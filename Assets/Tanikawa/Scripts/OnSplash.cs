using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSplash : MonoBehaviour
{
    GameObject ImaSplash;

<<<<<<< HEAD
=======
    AudioSource HitAs;

>>>>>>> リザルトのあれこれ
    // Use this for initialization
    void Start ()
    {
        ImaSplash = (GameObject)Resources.Load("Prefab/Splash");
<<<<<<< HEAD
=======
        HitAs = GetComponent<AudioSource>();
>>>>>>> リザルトのあれこれ
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ResPleCube"))
        {
            Instantiate(ImaSplash);
<<<<<<< HEAD
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
=======
            HitAs.PlayOneShot(HitAs.clip);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        Destroy(this.gameObject,15.0f);
    }

    //public void Hit()
    //{
    //    if (HitCount == 0)
    //    {
    //        MoveCamera.SetBool("Move0", true);
    //    }
    //}
>>>>>>> リザルトのあれこれ

}
