using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicEditor : MonoBehaviour {
    [SerializeField]
    GameObject EditUI;
    [SerializeField]
    AudioClip audioClip;

    string touchName;

    Data data = new Data();
    int dataCount;
    float timeCount;
    const float speed = 1.0f;

    // Use this for initialization
    void Start () {
        dataCount = 0;
        timeCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
        timeCount += speed * Time.deltaTime;
        if (Input.GetMouseButtonDown(0)) {
        
            //タッチした名前持ってくる
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Camera.main.transform.forward * 10);
            Collider2D collition2d = Physics2D.OverlapPoint(pos);

            touchName = null;
            if (collition2d) {
                touchName = collition2d.gameObject.name.ToString();
                Debug.Log(collition2d.gameObject.name.ToString());
            }

            if (touchName == null){
                Instantiate(EditUI).transform.position = pos;
                data.times[dataCount] = timeCount;
                data.positions[dataCount] = pos;
                dataCount++;
            }
        }

        if (timeCount > audioClip.length) {
            Save();
        }
    }

    public void Save() {
        FileOperation fileOption = new FileOperation();
        fileOption.Write(Application.dataPath + "/music/music.txt", data);
        Destroy(gameObject);
        SceneManager.LoadScene("select");
    }
}
