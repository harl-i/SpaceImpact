using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Language : MonoBehaviour
{
    public static Language Instance;
    private string _currentLanguage;

    public string CurrentLanguage => _currentLanguage;

    [DllImport("__Internal")]
    private static extern string GetLang();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            _currentLanguage = GetLang();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
