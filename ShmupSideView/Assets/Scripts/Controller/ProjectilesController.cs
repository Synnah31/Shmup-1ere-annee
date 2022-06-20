using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesController : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            Destroy(gameObject);
    }

   private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
