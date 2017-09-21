using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayScene() {
        SceneManager.LoadScene("game");
    }

    public void EditerScene() {
        SceneManager.LoadScene("editer");
    }
}
