using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatNormalizable
{
    private float _value;
    private float _max;

    public FloatNormalizable(float initValue, float initMax)
    {
        _value = initValue;
        _max = initMax;
    }

    public float GetValue()
    {
        return _value;
    }

    public void SetValue(float newValue)
    {
        if (_value > _max)
        {
            _value = _max;
        }
        else
        {
            _value = newValue;
        }

    }

    public float Normalize()
    {
        if (_max == 0)
        {
            return 1;
        }
        return _value / _max;
    }
}
