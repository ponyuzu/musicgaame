using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileOperation : MonoBehaviour {
    //戻り値：Data.csの配列(ノーツが出てくる時間と場所)
    //引数：txtファイルのパス（Assets内のResourcesフォルダからの相対パス）
    //内容：指定されたファイルをロードし、値を返します
    public Data Load(string filePass) {
        try{
            StreamReader reader = (new StreamReader(filePass, System.Text.Encoding.GetEncoding("UTF-8")));

            Data data = new Data();

            int i = 0;
            while (reader.Peek() > -1)
            {

                string line = reader.ReadLine();
                string[] values = line.Split(',');

                for (int j = 0; j < values.Length; j++)
                {
                    data.times[i] = float.Parse(values[0]);
                    data.positions[i].x = float.Parse(values[1]);
                    data.positions[i].y = float.Parse(values[2]);
                }
                i++;
            }
            data.maxNotes = i;

            reader.Close();
            Debug.Log("パス通ったで");
            return data;

        }
        catch (InvalidCastException e){
            Debug.Log(e);
            Debug.Log("パス通ってないで");
            return null;
        }
    }

   public void Write(string filePass , Data data){
        StreamWriter sw;

		sw = new StreamWriter (filePass, false);
        //Todo:いい書き方にする
        for (int i = 0; i < data.times.Length; i++){
            if (data.times[i] != 0){
                sw.WriteLine(data.times[i] + "," + data.positions[i].x + "," + data.positions[i].y);
            }
        }

        sw.Flush();
        sw.Close();

        Debug.Log("更新完了");
    }
}
