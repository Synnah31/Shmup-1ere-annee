using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisModel
{
    public FloatObservable healthPoints;
    public float maxHealthPoints = 3f;
    // Start is called before the first frame update
    public EnnemisModel()
    {
        healthPoints = new FloatObservable(maxHealthPoints, maxHealthPoints);
    }

    public void AddLife(float deltaLife)
    {
        healthPoints.Add(deltaLife);
    }
    // Update is called once per frame

}
