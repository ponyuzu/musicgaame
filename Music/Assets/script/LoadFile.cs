using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadFile : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Data Load(string filePass) {

        TextAsset txt = Resources.Load(filePass) as TextAsset;
        StringReader reader = new StringReader(txt.text);
        Data data = new Data();

        int i = 0;
        while (reader.Peek() > -1) {

            string line = reader.ReadLine();
            string[] values = line.Split(',');

            for (int j = 0; j < values.Length; j++){
                data.times[i] = float.Parse(values[0]);
                data.positions[i].x = float.Parse(values[1]);
                data.positions[i].y = float.Parse(values[2]);
            }
            i++;
        }

        return data;
    }
}
