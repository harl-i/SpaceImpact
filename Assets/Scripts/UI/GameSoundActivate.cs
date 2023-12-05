using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundActivate : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("Muted", 0);
    }
}
