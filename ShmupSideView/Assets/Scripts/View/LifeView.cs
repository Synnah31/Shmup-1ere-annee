using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LifeView : MonoBehaviour, IObserver<FloatNormalizable>
{


    [SerializeField] public Image lifeImage;    //A créer sur la scène

    public void OnCompleted()
    {
        //throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        //throw new NotImplementedException();
    }

    public void OnNext(FloatNormalizable value)
    {
        lifeImage.fillAmount = value.Normalize();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
