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

    // Use this for initialization
    void Start () {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
        isfade = false;
        color = sr.color;
    }
	
	// Update is called once per frame
	void Update () {
         if (musicManager.GetTapCol() == col) {
            note.jugment();
            isfade = true;
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
