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
            
            this.data = reader.ReadToEnd();
            BaseDatos jsonToBackground = JsonUtility.FromJson<BaseDatos>(this.data);
            this.data = jsonToBackground.data;
            this.name = jsonToBackground.name;
            reader.Close();
            return (this.name, new StyleBackground(AssetDatabase.LoadAssetAtPath<Sprite>(this.data)));
        }
        public void saveData(string data, string name)
        {
            this.data = data;
            this.name = name;
            StreamWriter writer = new StreamWriter(path);
            string jsonImage = JsonUtility.ToJson(this.data);
            string jsonName = JsonUtility.ToJson(this.name);
            writer.Write(jsonImage);
            writer.Write(jsonName);
            writer.Close();
        }
    }
}
