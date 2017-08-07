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
    Collider2D tapCol;

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
        Debug.Log(timeCount);

        //PlayMusicButtonを生成
        if (notesCount < data.maxNotes && timeCount > data.times[notesCount] - 3) {
            Instantiate(button).transform.position = data.positions[notesCount];
            notesCount++;
        }

        //タップした場所のcollider２Dを取得
        tapCol = null;
        if (Input.GetMouseButtonDown(0)) {
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition + Camera.main.transform.forward * 10);
            tapCol = Physics2D.OverlapPoint(point);
        }
    }

    public Collider2D GetTapCol() {
        return tapCol;
    }
}
