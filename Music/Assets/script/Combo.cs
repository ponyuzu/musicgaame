using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour {
    [SerializeField]
    MusicManager musicManager;
    [SerializeField]
    ChangeText changeTex;

    int combo;
     int maxCombo;

    void Start () {
        combo = 0;
    }
	
	void Update () {
        if (musicManager.GetMusicEnd()) {
            Destroy(gameObject);
        }
	}

    //コンボ数を足す
    public void AddCombo() {
        combo += 1;
        MaxCombo();
        changeTex.WriteTex("COMBO：" + combo);
    }

    //コンボをリセットする
    public void ComboReset() {
        combo = 0;
        changeTex.WriteTex("COMBO：" + combo);
    }

    //スコア最高記録を保持する
    void MaxCombo() {
        if (combo > maxCombo) {
            maxCombo = combo;
        }
    }

    //最高記録を渡す
    public int GetMaxCombo() {
        return maxCombo;
    }
}
