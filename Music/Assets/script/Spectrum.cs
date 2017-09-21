using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectrum : MonoBehaviour {

    [SerializeField]
    GameObject cube;
    const int MAX_OBJECT = 30;
    const float RADIUS = 4;
    GameObject[] cubes;

	// Use this for initialization
	void Start () {
        for (int i = 0 ; i < MAX_OBJECT ; i++){
            float angle = i * Mathf.PI * 2 / MAX_OBJECT;
            Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * RADIUS;
            Instantiate(cube, pos, Quaternion.identity);
        }
        cubes = GameObject.FindGameObjectsWithTag("cubes");
	}
	
	// Update is called once per frame
	void Update () {
        float[] spectrum = new float[1024];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);

        for (int i = 0; i < MAX_OBJECT; i++) {
            Vector3 scale = cubes[i].transform.localScale;
            scale.y = spectrum[i] * 10;
            scale.x = spectrum[i] * 10;
            cubes[i].transform.localScale = scale;
        }
	}

    public float[] GetWaveData() {
        return AudioListener.GetSpectrumData(1024, 0, FFTWindow.Hamming);
    }
}
