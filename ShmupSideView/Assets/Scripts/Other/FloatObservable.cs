using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatObservable : IObservable<FloatNormalizable>
{
    private List<IObserver<FloatNormalizable>> _observers;

    private FloatNormalizable _value;

    public FloatObservable(float InitValue, float maxValue)
    {
        _value = new FloatNormalizable(InitValue, maxValue);
        _observers = new List<IObserver<FloatNormalizable>>();
    }

    public void Add(float deltaValue)
    {
        _value.SetValue(_value.GetValue() + deltaValue);
        foreach (IObserver<FloatNormalizable> obs in _observers)
        {
            obs.OnNext(_value);
        }
    }

    public IDisposable Subscribe(IObserver<FloatNormalizable> observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
        return null;
    }

    public FloatNormalizable GetValue()
    {
        return _value;
    }
}
