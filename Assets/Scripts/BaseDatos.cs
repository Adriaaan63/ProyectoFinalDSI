using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Lab5c_namespace
{
    public class BaseDatos
    {
        public string data = "";
        public string name = "";
        string path = "Assets/Resources/save.json";
        public (string, StyleBackground) getData()
        {
            StreamReader reader = new StreamReader(path);
            if (reader == null)
                return (name, new StyleBackground(AssetDatabase.LoadAssetAtPath<Sprite>(data)));
            this.data = reader.ReadToEnd();
            BaseDatos jsonToBackground = JsonUtility.FromJson<BaseDatos>(this.data);
            //this.data = jsonToBackground.data;
            //this.name = jsonToBackground.name;
            reader.Close();
            return (jsonToBackground.name, new StyleBackground(AssetDatabase.LoadAssetAtPath<Sprite>(jsonToBackground.data)));
        }
        public void saveData(string data, string name)
        {
            Debug.Log(data);
            this.data = data;
            this.name = name;
            StreamWriter writer = new StreamWriter(path);
            string jsonImage = JsonUtility.ToJson(this);
            writer.Write(jsonImage);
            writer.Close();
        }
    }
}
