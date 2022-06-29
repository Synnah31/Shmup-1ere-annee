using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BarthaSzabolcs.Tutorial_SpriteFlash;
public class EnnemiController : MonoBehaviour
{
    private EnnemisModel ennemisModel;

    //Changement couleur quand touché
    private SpriteRenderer RendererColorHit;

    // Start is called before the first frame update
    void Start()
    {
        ennemisModel = new EnnemisModel();

        //Changement couleur quand touché
        RendererColorHit = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeHit(float damage)
    {
        Debug.Log(ennemisModel == null);
        ennemisModel.healthPoints.Add(-damage);
        //coloredFlash.Flash(Color.red);

        //GetValue1 est lié au Float Observable,GetValue1 est lié au Float Normalizable 
        if (ennemisModel.healthPoints.GetValue().GetValue() <= 0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Character Projectil")
        {
            //Changement couleur quand touché
            RendererColorHit.color = Color.red;
            Invoke("ChangeColor", 0.10f);
            TakeHit(1);
            //Détruit directement. N'utilise pas encore un systeme de HP
            //Destroy(gameObject);
        }

        if (collision.gameObject.tag == "CharacterShield")
        {
            Debug.Log("collision shield");
            TakeHit(10);
        }
    }

    public void ChangeColor()
    {
        RendererColorHit.color = Color.white;
    }
}
