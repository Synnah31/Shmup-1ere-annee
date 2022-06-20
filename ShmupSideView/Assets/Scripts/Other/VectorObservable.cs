using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorObservable : IObservable<Vector2> 
{
    private List<IObserver<Vector2>> _observers;
    private Vector2 _position;


    public VectorObservable(float x, float y)
    {
        _position = new Vector2(x, y);
        _observers = new List<IObserver<Vector2>>();
    }

    public Vector2 GetValue()
    {
        return _position;
    }
    public float GetValueY()
    {
        return _position.y;
    }
    public void SetValue(Vector2 newPosition)
    {
        _position = newPosition;
    }

    public void Add(Vector2 deltaValue)
    {
        _position += deltaValue;
        foreach (IObserver<Vector2> observer in _observers)
        {
            observer.OnNext(_position);
        }
    }
    public IDisposable Subscribe(IObserver<Vector2> observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
        return null;
    }
}
