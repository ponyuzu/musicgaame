using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    [SerializeField]
    MusicManager musicManager;
    [SerializeField]
    ChangeText changeTex;

    int score;

	void Start () {
        score = 0;
     }
	
	void Update () {
        if (musicManager.GetMusicEnd()){
            Destroy(gameObject);
        }
    }

    //スコア加算
    //引数：加える値
    public void AddScore(int add){
        score += add;
        changeTex.WriteTex("SCORE："+ score);
    }

    public int GetScore() {
        return score;
    }
}
