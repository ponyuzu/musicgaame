using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicEditer : MonoBehaviour {
    [SerializeField]
    GameObject EditUI;

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
        Vector3 pos;
        if (Input.GetMouseButtonDown(0)) {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Camera.main.transform.forward * 10);

            Instantiate(EditUI).transform.position = pos;
            data.times[dataCount] = timeCount;
            data.positions[dataCount] = pos;
            dataCount++;
        }

        Debug.Log(timeCount);
        //Todo：音楽の時間取得する
        if (timeCount > 10) {
            FileOperation fileOption = new FileOperation();
            fileOption.Write(Application.dataPath + "/Resources/music.txt", data);
            Destroy(gameObject);
        }
    }
}
