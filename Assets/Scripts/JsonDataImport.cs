using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class JsonDataImport : MonoBehaviour
{
    public static JsonDataImport instance;
    public TextAsset jsonFile;
    //public MessageData messageData;
    public string[] messages_jsonn;
    public string[] motivation_jsonn;
    public string[] love_jsonn;

    private void OnEnable()
    {
        LoadConfigFromJSON();
        //        if (Instance == null)
        //        {
        //            Instance = this;
        //            LoadConfigFromJSON();
        //        }
        //        else
        //        {
        //            Destroy(gameObject);
        //        }
    }

    [System.Serializable]
    public class MessageParameters
    {
        public string[] messages;
        public string[] motivation;
        public string[] love;
    }

    public void LoadConfigFromJSON()
    {
        string jsonContent = null;
        try
        {
            // Get the path to the "Assets" folder
            string assetsPath = Application.dataPath;
            // Navigate up to the project folder
            string projectPath = Directory.GetParent(assetsPath).FullName;
            // Now you can construct paths relative to your project
            string jsonPathInBuild = Path.Combine(projectPath, "messageDataJson.json");
            // Read the contents of the JSON file
            jsonContent = File.ReadAllText(jsonPathInBuild);
            // Now, jsonContent contains the content of the JSON file as a string
            Debug.Log("Other json content: " + jsonContent);
        }
        catch (Exception e)
        {
            Debug.LogWarning("Error loading JSON from build folder: " + e.Message);
        }

        // If loading from build folder failed or jsonContent is still null, try loading from Resources
        if (string.IsNullOrEmpty(jsonContent))
        {
            // Load default JSON from Resources
            TextAsset jsonFile = Resources.Load<TextAsset>("messageDataJson");
            jsonContent = jsonFile.text;
            Debug.Log("Default json content: " + jsonContent);
        }

        // Parse the JSON data into a GameParametersData object
        MessageParameters messages = JsonUtility.FromJson<MessageParameters>(jsonContent);

        messages_jsonn = messages.messages;
        motivation_jsonn = messages.motivation;
        love_jsonn = messages.love;
    }
}