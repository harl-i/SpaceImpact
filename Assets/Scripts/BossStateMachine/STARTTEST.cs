using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STARTTEST : MonoBehaviour
{
    [SerializeField] private Move move;

    private void Start()
    {
        move = GetComponent<LinearMove>();

        move.SetSpeed(2f);
    }


}
