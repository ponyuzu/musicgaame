﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour {

    Text tex;
    
	// Use this for initialization
	void Start () {
        tex = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WriteTex(string changeTex) {
        tex.text = changeTex;
    }
}
