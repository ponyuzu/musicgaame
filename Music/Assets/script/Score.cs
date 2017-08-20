﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    TextMesh tex;
    int score;

	// Use this for initialization
	void Start () {
        tex = GetComponent<TextMesh>();
        score = 0;
     }
	
	// Update is called once per frame
	void Update () {
		
	}

    //スコア加算
    //引数：加える値
    public void AddScore(int add){
        score += add;
        tex.text = "スコア："+ score;
    }
}
