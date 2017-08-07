using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {
    [SerializeField]
    ChangeText changeText;

    Score score;
    const float speed = 1.0f;
    Vector3 scale;

    // Use this for initialization
    void Start () {
        score = GameObject.Find("Score").GetComponent<Score>();
        transform.localScale = new Vector3(4, 4, 1);
        scale = transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
        scale.x -= speed * Time.deltaTime;
        scale.y -= speed * Time.deltaTime;
        transform.localScale = scale;
    }

    //scaleで判定を作成(noteButtonタップで呼び出される)
    public void jugment() {
        if (transform.localScale.x <= 1.2f && transform.localScale.x >= 0.8f){
            //excellent
            changeText.WriteTex("excellent");
            score.AddScore(100);
        }
        else if (transform.localScale.x <= 1.6f && transform.localScale.x > 1.2f ||
                 transform.localScale.x < 0.8f && transform.localScale.x >= 0.4f) {
            //great
            changeText.WriteTex("great");
            score.AddScore(50);
        }
        else if (transform.localScale.x <= 2.0f && transform.localScale.x > 1.6f ||
                 transform.localScale.x < 0.4f && transform.localScale.x > 0.0f){
            //good
            changeText.WriteTex("good");
            score.AddScore(10);
        }
        else {
            //bad
            changeText.WriteTex("bad");
        }
        Destroy(gameObject);
    }
}
