using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobelinLourdModel
{
    public FloatObservable healthPoints;
    public float maxHealthPoints = 5f;
    // Start is called before the first frame update
    public GobelinLourdModel()
    {
        healthPoints = new FloatObservable(maxHealthPoints, maxHealthPoints);
    }

    public void AddLife(float deltaLife)
    {
        healthPoints.Add(deltaLife);
    }
    // Update is called once per frame

}
