using System;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public event Action destroy;

    public void Subscribe(Action action) => destroy += action;
    public void Unsubscribe(Action action) => destroy -= action;
    public void Invoke() => destroy?.Invoke();
}
