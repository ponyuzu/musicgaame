using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantTapArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Vector3 LeftUp = Camera.main.ScreenToWorldPoint(Vector3.zero);
        LeftUp.Scale(new Vector3(1f, -1f, 1f));
        LeftUp.x = LeftUp.x + 3;
        LeftUp.y = LeftUp.y - 1;
        transform.position = LeftUp;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
