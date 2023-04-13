using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    private string key = "mypassword123"; //my password to access the encryption stuff

    public static SaveLoadManager Instance { get; private set; }

    private SaveData saveData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        saveData = new SaveData();
        saveData.playerPosition = ThePlayerController.Instance.transform.position;

        // string json = JsonUtility.ToJson(saveData);
        // File.WriteAllText(Application.persistentDataPath + "/save.json", json);

        string jsonData = "Some data to be encrypted.";

        string encryptedData = EncryptDecryptXOR(jsonData, key);

        File.WriteAllText(Application.persistentDataPath + "/save.json", encryptedData);
    }

    public void Load(string filePath)
    {
        if (File.Exists(Application.persistentDataPath + "/save.json"))
        {
         
            string json = File.ReadAllText(Application.persistentDataPath + "/save.json"); // i gotta make a filepath for this game
            saveData = JsonUtility.FromJson<SaveData>(json);

            ThePlayerController.Instance.transform.position = saveData.playerPosition;

            string encryptedData = File.ReadAllText(filePath);
            string decryptedData = EncryptDecryptXOR(encryptedData, key);

            Debug.Log("Decrypted data: " + decryptedData);
        }
        else
        {
            Debug.LogError("File not found at path: " + filePath);
        }
    }

    string EncryptDecryptXOR(string data, string key)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
           
            char c = (char)(data[i] ^ key[i % key.Length]);
            sb.Append(c);
        }

        return sb.ToString();
    }
}

[System.Serializable]
public class SaveData
{
    public Vector3 playerPosition;
}


// no idea how to implement this into the current state of the game right now though