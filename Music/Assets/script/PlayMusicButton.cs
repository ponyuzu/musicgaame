using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMusicButton : MonoBehaviour {

    RectTransform rectTransform;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Create(Vector2 pos) {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localPosition = pos;
    } 
}
