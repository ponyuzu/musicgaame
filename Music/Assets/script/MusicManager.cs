using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {
    [SerializeField]
    GameObject button;
    [SerializeField]
    AudioClip audioClip;

    Data data;
    FileOperation loadFile;
    const float speed = 1.0f;
    float timeCount;
    int notesCount;
    Collider2D tapCol;
    bool isMusicEnd;

    void Start () {
        loadFile = new FileOperation();
        Debug.Log("読み込み開始");
        data = loadFile.Load(Application.dataPath + "/music/music.txt");
        timeCount = 0;
        notesCount = 0;
        isMusicEnd = false;
    }
	
	void Update () {
        timeCount += speed * Time.deltaTime;

        if (Input.GetKeyDown("return"))  {
            SceneManager.LoadScene("select");
        }

        //音楽が終わったかどうか
        if (timeCount > audioClip.length) {
            isMusicEnd = true;
        }

        //PlayMusicButtonを生成
        if (notesCount < data.maxNotes && timeCount > data.times[notesCount] - 3 / 2) {
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

    public bool GetMusicEnd() {
        return isMusicEnd;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(20, 20, 150, 150), Application.dataPath + "/music/music.txt");
        //GUI.Label(new Rect(20, 150, 150, 300), data.times[0].ToString());
    }
}
