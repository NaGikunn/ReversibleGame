using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotat : MonoBehaviour {
    Transform target;
    bool down = false;
    float limit = 10.0f;
    private float inertia = 0.0f;
    private Vector2 prev;
    private Vector2 delta = new Vector2(0.0f, 0.0f);
    // Use this for initialization
    private void Awake()
    {
        if (target == null)
        {
            target = transform;
        }
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            delta.x = 0.0f;
            delta.y = 0.0f;
            prev = Input.mousePosition;
            down = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            down = false;
            if (delta.magnitude > 8.0f)
            {
                float v = Mathf.Clamp(delta.sqrMagnitude, 0.0f, limit);
                delta.Normalize();
                delta *= v;
                inertia = 1.0f;
            }
        }
        if (down)
        {
            delta.x = prev.x - Input.mousePosition.x;
            delta.y = prev.y - Input.mousePosition.y;
            prev = Input.mousePosition;
            Vector3 euler = new Vector3(-delta.y, delta.x, 0.0f);
            target.Rotate(euler, Space.World);
        }else if (inertia >= 0.0f)
        {
            inertia *= 0.97f;
            if (inertia > 0.05f)
            {
                Vector3 euler = new Vector3(-delta.y * inertia, delta.x * inertia, 0.0f);
                Debug.Log(delta*inertia);
                target.Rotate(euler, Space.World);
            }
            else
            {
                inertia = 0.0f;
            }
        }
	}
}
