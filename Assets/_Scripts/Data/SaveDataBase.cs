using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Data
{
    public abstract class SaveDataBase<T> where T: new()
    {
        private string _json = "";
        private string _path = "";
        protected abstract string FileName { get; }
        protected abstract T saveObject();
        public void Save()
        {
            Debug.Log("File is saving...: " + saveObject());
            _json = JsonUtility.ToJson(saveObject());
            WriteToFile(FileName, _json);
            Debug.Log("File is saved successfully: " + saveObject());

        }
        public void Load()
        {
            _json = ReadFromFile(FileName);
            JsonUtility.FromJsonOverwrite(_json, saveObject());
        }
        private void WriteToFile(string fileName, string data)
        {
            _path = GetFilePath(FileName);
            FileStream fileStream = new FileStream(_path, FileMode.Create);
            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.Write(_json);
            }
        }
        private string ReadFromFile(string fileName)
        {
            _path = GetFilePath(fileName);
            if (File.Exists(_path))
            {
                using (StreamReader streamReader = new StreamReader(_path))
                {
                    string currentJson = streamReader.ReadToEnd();
                    return currentJson;
                }
            }
            else
            {
                Debug.Log("File doesn't exist!");
            }
            return "";
        }
        string GetFilePath(string fileName)
        {
            return Application.persistentDataPath + "/" + fileName;
        }
    }
}