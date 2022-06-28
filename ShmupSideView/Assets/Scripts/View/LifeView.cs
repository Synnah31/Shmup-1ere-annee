using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LifeView : MonoBehaviour
{


    [SerializeField] public GameObject lifeImage;    //A créer sur la scène

    public void Enable()
    {
        lifeImage.SetActive(true);
    }

    public void Disable()
    {
        lifeImage.SetActive(false);
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
