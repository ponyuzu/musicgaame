using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileOperation : MonoBehaviour {

    //戻り値：Data.csの配列(ノーツが出てくる時間と場所)
    //引数：txtファイルのパス（Assets内のResourcesフォルダからの相対パス）
    //内容：指定されたファイルをロードし、値を返します
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
        data.maxNotes = i;

        reader.Close();
        return data;
    }

    public void Write(string filePass , Data data){
        StreamWriter sw;
        FileInfo fi;

        fi = new FileInfo(filePass);
        sw = fi.AppendText();
        for (int i = 0; i < data.times.Length; i++) {
            sw.WriteLine(data.times[i] + "," + data.positions[i].x + "," + data.positions[i].y);
        }
        sw.Flush();
        sw.Close();

        Debug.Log("セーブ");
    }
}
