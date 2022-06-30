using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BDBehavior : MonoBehaviour
{
    public GameObject BD1;
    public GameObject BD2;
    public GameObject BD3;
    public GameObject BD4;
    public GameObject BD5;
    public GameObject BD6;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BandeDessinee());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator BandeDessinee()
    {
        BD1.SetActive(true);
        yield return new WaitForSeconds(3f);
        BD2.SetActive(true);
        yield return new WaitForSeconds(3f);
        BD3.SetActive(true);
        yield return new WaitForSeconds(3f);
        BD4.SetActive(true);
        yield return new WaitForSeconds(3f);
        BD5.SetActive(true);
        yield return new WaitForSeconds(3f);
        BD6.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
