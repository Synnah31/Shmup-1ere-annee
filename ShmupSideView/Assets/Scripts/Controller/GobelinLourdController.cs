using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobelinLourdController : MonoBehaviour
{
    private GobelinLourdModel gobelinLourdModel;


    // Start is called before the first frame update
    void Start()
    {
        gobelinLourdModel = new GobelinLourdModel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeHit(float damage)
    {
        Debug.Log(gobelinLourdModel == null);
        gobelinLourdModel.healthPoints.Add(-damage);
        //GetValue1 est li� au Float Observable,GetValue1 est li� au Float Normalizable 
        if (gobelinLourdModel.healthPoints.GetValue().GetValue() <= 0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Character Projectil")
        {
            TakeHit(1);
            //D�truit directement. N'utilise pas encore un systeme de HP
            //Destroy(gameObject);
        }
    }
}
