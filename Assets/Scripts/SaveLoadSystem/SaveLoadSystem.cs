using System.IO;
using UnityEngine;

public class SaveLoadSystem
{
    private string _filePath;

    public SaveLoadSystem(string filePath)
    {
        _filePath = filePath;
    }

    public void Save(PlayerData playerData)
    {
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(_filePath, json);
    }

    public PlayerData Load()
    {
        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);
            return JsonUtility.FromJson<PlayerData>(json);
        }

        return null;
    }
}