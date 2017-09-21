using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorUI : MonoBehaviour {

    const float feadSpeed = 1;
    SpriteRenderer sr;
    Color color;

    // Use this for initialization
    void Start () {
        sr = GetComponent<SpriteRenderer>();
        color = sr.color;
    }
	
	// Update is called once per frame
	void Update () {
        color.a -= feadSpeed * Time.deltaTime;
        sr.color = color;

        if (color.a < 0) {
            Destroy(gameObject);
        }
    }
}
