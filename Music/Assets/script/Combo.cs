using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour {

    TextMesh tex;
    int combo;

    // Use this for initialization
    void Start () {
        tex = GetComponent<TextMesh>();
        combo = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //コンボ数を足す
    public void AddCombo() {
        combo += 1;
        tex.text = "コンボ：" + combo;
    }

    //コンボをリセットする
    public void ComboReset() {
        combo = 0;
        tex.text = "コンボ：" + combo;
    }

    //Todo：スコア最高記録を保持する＆最後に出す
}
