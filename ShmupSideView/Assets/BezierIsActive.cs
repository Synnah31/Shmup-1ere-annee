using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierIsActive : MonoBehaviour
{
    [SerializeField] private ThisObjectFalse objectFils;
    [SerializeField] private ThisObjectFalse objectFils2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ColliderCamera")
        {
            objectFils.gameObject.SetActive(true);
            objectFils2.gameObject.SetActive(true);
        }
    }
}
