using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCameraMove : MonoBehaviour
{
    public Animator MoveCamera;

    int HitCount;

    // Use this for initialization
    void Start ()
    {
        HitCount = 1;
    }

    void OnTriggerEnter(Collider other)
    {
        if (HitCount == 1)
        {
            MoveCamera.SetBool("Move1", true);
        }

        else if (HitCount == 2)
        {
            MoveCamera.SetBool("Move2", true);
        }

        else if (HitCount == 3)
        {
            MoveCamera.SetBool("Move3", true);
        }

        HitCount += 1;
    }

}
