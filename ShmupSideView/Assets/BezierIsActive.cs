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
    [SerializeField] private ThisObjectFalse objectFils10;
    [SerializeField] private ThisObjectFalse objectFils11;
    [SerializeField] private ThisObjectFalse objectFils12;
    [SerializeField] private ThisObjectFalse objectFils13;
    [SerializeField] private ThisObjectFalse objectFils14;
    [SerializeField] private ThisObjectFalse objectFils15;
    [SerializeField] private ThisObjectFalse objectFils16;
    [SerializeField] private ThisObjectFalse objectFils17;

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
            objectFils10.gameObject.SetActive(true);
            objectFils11.gameObject.SetActive(true);
            objectFils12.gameObject.SetActive(true);
            objectFils13.gameObject.SetActive(true);
            objectFils14.gameObject.SetActive(true);
            objectFils15.gameObject.SetActive(true);
            objectFils16.gameObject.SetActive(true);
            objectFils17.gameObject.SetActive(true);
        }
    }
}
