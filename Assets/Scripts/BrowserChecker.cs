using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BrowserChecker : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void DetectBrowserAndEnableJoystick();

    void Start()
    {
#if !UNITY_EDITOR
        DetectBrowserAndEnableJoystick();
#endif
    }
}
