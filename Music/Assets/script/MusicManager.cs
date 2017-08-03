using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    [SerializeField]
    GameObject PlayMusicButton;

    Data data;
    LoadFile loadFile;
    const float speed = 1.0f;
    float timeCount;
    int notesCount;

    // Use this for initialization
    void Start () {
        loadFile = new LoadFile();
        data = loadFile.Load("music");
        timeCount = 0;
        notesCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
        timeCount += speed * Time.deltaTime;
        Debug.Log(timeCount);

        if (notesCount < data.maxNotes && timeCount > data.times[notesCount]) {
            GameObject InstantObj = Instantiate(PlayMusicButton);
            InstantObj.transform.SetParent(GameObject.Find("Canvas").transform, false);
            PlayMusicButton playerMusicButton = InstantObj.GetComponent<PlayMusicButton>();
            playerMusicButton.Create(data.positions[notesCount]);
            notesCount++;
        }
    }
}
