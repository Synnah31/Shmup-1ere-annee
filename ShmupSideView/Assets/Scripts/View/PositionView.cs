using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionView : MonoBehaviour, IObserver<Vector2>
{

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(Vector2 value)
    {
        transform.position = value;
    }
}
