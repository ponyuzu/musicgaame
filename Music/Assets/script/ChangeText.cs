using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeText : MonoBehaviour {

    TextMesh tex;
    
	void Start () {
        tex = GetComponent<TextMesh>();
    }
	
	void Update () {
		
	}

    public void WriteTex(string changeTex) {
        tex.text = changeTex;
    }
}
