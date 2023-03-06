using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Move : MonoBehaviour
{
    public abstract IEnumerator StartMove();

    public abstract void SetSpeed(float speed);
}
