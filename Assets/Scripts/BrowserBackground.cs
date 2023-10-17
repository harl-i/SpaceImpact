using UnityEngine;

public class BrowserBackground : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void OnSceneLoaded()
    {
        Application.ExternalCall("OnLevelLoaded");
    }
}
