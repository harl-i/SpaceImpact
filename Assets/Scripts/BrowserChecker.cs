using System.Runtime.InteropServices;
using UnityEngine;

public class BrowserChecker : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void DetectBrowserAndEnableMobileButtons();

    void Start()
    {
#if !UNITY_EDITOR
        DetectBrowserAndEnableMobileButtons();
#endif
    }
}
