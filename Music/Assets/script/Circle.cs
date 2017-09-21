using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Circle : MonoBehaviour {

    [SerializeField]
    Spectrum spectrum;
    float[] data;
    int myNumber;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update(){
        data = spectrum.GetWaveData();
        var volume = data.Select(x => x * x).Sum() / data.Length;
        transform.localScale = Vector3.one * volume * 10000;
    }
}
