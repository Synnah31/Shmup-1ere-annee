using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierIsActive : MonoBehaviour
{
    [SerializeField] private ThisObjectFalse objectFils;
    [SerializeField] private ThisObjectFalse objectFils2;
    [SerializeField] private ThisObjectFalse objectFils3;
    [SerializeField] private ThisObjectFalse objectFils4;
    [SerializeField] private ThisObjectFalse objectFils5;
    [SerializeField] private ThisObjectFalse objectFils6;
    [SerializeField] private ThisObjectFalse objectFils7;
    [SerializeField] private ThisObjectFalse objectFils8;
    [SerializeField] private ThisObjectFalse objectFils9;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ColliderCamera")
        {
            objectFils.gameObject.SetActive(true);
            objectFils2.gameObject.SetActive(true);
            objectFils3.gameObject.SetActive(true);
            objectFils4.gameObject.SetActive(true);
            objectFils5.gameObject.SetActive(true);
            objectFils6.gameObject.SetActive(true);
            objectFils7.gameObject.SetActive(true);
            objectFils8.gameObject.SetActive(true);
            objectFils9.gameObject.SetActive(true);
        }
    }
}
