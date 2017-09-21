using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour {
    [SerializeField]
    MusicManager musicManager;
    [SerializeField]
    ChangeText changeTex;

    Score score;
    Combo combo;

    void Start () {
        score = GameObject.Find("Score").GetComponent<Score>();
        combo = GameObject.Find("Combo").GetComponent<Combo>();
    }
	
	void Update () {
        if (musicManager.GetMusicEnd()) {
            changeTex.WriteTex( "SCORE：" + score.GetScore() + "\nMAX COMBO：" + combo.GetMaxCombo());
        }
	}
}
