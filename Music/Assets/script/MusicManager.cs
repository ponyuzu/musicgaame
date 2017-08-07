using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    [SerializeField]
    GameObject button;

    Data data;
    FileOperation loadFile;
    const float speed = 1.0f;
    float timeCount;
    int notesCount;

    // Use this for initialization
    void Start () {
        loadFile = new FileOperation();
        data = loadFile.Load("music");
        timeCount = 0;
        notesCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
        timeCount += speed * Time.deltaTime;
        //Debug.Log(timeCount);

        //PlayMusicButtonをCanvasの下に生成
        if (notesCount < data.maxNotes && timeCount > data.times[notesCount] - 3) {
            Instantiate(button).transform.position = data.positions[notesCount];
            notesCount++;
        }
    }
}
