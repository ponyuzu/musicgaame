using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    Data data;
    LoadFile loadFile;

	// Use this for initialization
	void Start () {
        loadFile = new LoadFile();
        data = loadFile.Load("music");

        Debug.Log(data.times[0]);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
