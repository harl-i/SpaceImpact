using System.Collections;
using UnityEngine;

public abstract class Move : MonoBehaviour
{
    public abstract IEnumerator StartMove();

    public abstract void SetSpeed(float speed);
}
