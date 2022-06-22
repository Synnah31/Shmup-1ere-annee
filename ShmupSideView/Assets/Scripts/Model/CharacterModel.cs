using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel 
{
    public VectorObservable _position;
    private FloatObservable _life;

    //private float speed = 10;

    public CharacterModel(float x, float y, float initLife, float maxValue)
    {
        _position = new VectorObservable(x, y);
        _life = new FloatObservable(initLife, maxValue);
    }

    public void AddPosition(Vector2 deltaPosition)
    {
        _position.Add(deltaPosition);
    }

    public void AddLife(float deltaLife)
    {
        _life.Add(deltaLife);
    }

    public VectorObservable GetPosition()
    {
        return _position;
    }

    public FloatObservable GetLife()
    {
        return _life;
    }

}
