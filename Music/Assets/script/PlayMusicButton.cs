using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicButton : MonoBehaviour {
    [SerializeField]
    Note note;

    SpriteRenderer sr;
    Color color;
    const float feadSpeed = 2;
    bool isfade;
    Collider2D col;

    // Use this for initialization
    void Start () {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        isfade = false;
        color = sr.color;
    }
	
	// Update is called once per frame
	void Update () {
        //Todo:この処理はここでいいのか検討
        if (Input.GetMouseButtonDown(0)){
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition + Camera.main.transform.forward * 10);
            Collider2D collider2d = Physics2D.OverlapPoint(point);
            if (collider2d == col) {
                note.jugment();
                isfade = true;
            }
        }

        if (isfade) {
            color.a -= feadSpeed * Time.deltaTime;
            sr.color = color;
        }

        if (color.a < 0) {
            Destroy(gameObject);
        }
    }
}
