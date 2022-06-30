using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobProjectilesController : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.right * Speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ColliderCamera" || collision.gameObject.tag == "Player")
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
