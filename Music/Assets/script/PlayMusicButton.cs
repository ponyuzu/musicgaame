using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicButton : MonoBehaviour {
    [SerializeField]
    Note note;

    MusicManager musicManager;
    SpriteRenderer sr;
    Color color;
    const float feadSpeed = 2;
    bool isfade;
    Collider2D col;

    void Start () {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        isfade = false;
        color = sr.color;
    }
	
	void Update () {

        //タップしたときに判定を呼び出す
         if (musicManager.GetTapCol() == col) {
            note.jugment();
         }

        //noteが無くなったらボタンをフェードを開始
        if (!note) {
            isfade = true;
        }

        //フェード処理
        if (isfade) {
            color.a -= feadSpeed * Time.deltaTime;
            sr.color = color;
        }

        //フェードしきったら消去
        if (color.a < 0) {
            Destroy(gameObject);
        }
    }
}
