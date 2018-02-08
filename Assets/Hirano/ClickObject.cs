using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObject : MonoBehaviour
{
	public GameObject stone;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log(getClickObject());
	}

	// 左クリックしたオブジェクトを取得する関数(3D)
	public GameObject getClickObject()
	{
		GameObject Clickobj = null;
		Vector3 pos = new Vector3();

		// 左クリックされた場所のオブジェクトを取得
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			if (Physics.Raycast(ray, out hit))
			{
				Clickobj = hit.collider.gameObject;
				pos = Clickobj.transform.position;
				pos.y += 1;
				Instantiate(stone, pos, Quaternion.identity);
			}
		}
		return Clickobj;
	}
}
