using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBoss_3 : Wave
{
    [SerializeField] private GameObject _boss;

    private void OnEnable()
    {
        _boss.SetActive(true);
    }
}
