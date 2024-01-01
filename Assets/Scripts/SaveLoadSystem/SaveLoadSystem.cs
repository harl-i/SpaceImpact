using System.Runtime.InteropServices;
using UnityEngine;

public class SaveLoadSystem
{
    [DllImport("__Internal")]
    private static extern void SaveToLocalStorage(string key, string value);

    [DllImport("__Internal")]
    private static extern string LoadFromLocalStorage(string key);

    private string _filePath;

    public SaveLoadSystem(string filePath)
    {
        _filePath = filePath;
    }

    public void Save(PlayerData playerData)
    {
        string json = JsonUtility.ToJson(playerData);
        SaveToLocalStorage(_filePath, json);
    }

    public PlayerData Load()
    {
        string json = LoadFromLocalStorage(_filePath);

        if (!string.IsNullOrEmpty(json))
        {
            return JsonUtility.FromJson<PlayerData>(json);
        }

        return null;
    }
}