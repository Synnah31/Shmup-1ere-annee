using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesPulling : MonoBehaviour
{
    //prefab
    public GameObject CharacterProjectile;
    public int pooledAmount = 30;

    private float nextFire;

    List<GameObject> pooledProjectiles;
    // Start is called before the first frame update
    void Start()
    {
        pooledProjectiles = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(CharacterProjectile);
            obj.SetActive(false);
            //CharacterProjectile.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
