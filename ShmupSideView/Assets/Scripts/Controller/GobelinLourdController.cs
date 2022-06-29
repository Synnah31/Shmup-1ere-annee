using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobelinLourdController : MonoBehaviour
{
    private GobelinLourdModel gobelinLourdModel;

    //Changement couleur quand touch�
    private SpriteRenderer RendererColorHit;


    // Start is called before the first frame update
    void Start()
    {
        gobelinLourdModel = new GobelinLourdModel();

        //Changement couleur quand touch�
        RendererColorHit = GetComponent<SpriteRenderer>();
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
            //Changement couleur quand touch�
            RendererColorHit.color = Color.red;
            Invoke("ChangeColor", 0.10f);
            TakeHit(1);
            //D�truit directement. N'utilise pas encore un systeme de HP
            //Destroy(gameObject);
        }
    }

    public void ChangeColor()
    {
        RendererColorHit.color = Color.white;
    }
}
