using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCharacter : MonoBehaviour
{
    //[SerializeField] private LifeView lifeView;
    [SerializeField] private PositionView positionView;
    private CharacterModel characterModel;

    //Changement couleur quand touché
    private SpriteRenderer RendererColorHit;

    [SerializeField] private MenuController menuController;

    [SerializeField] LifeView lifeViewHP1;
    [SerializeField] LifeView lifeViewHP2;
    [SerializeField] LifeView lifeViewHP3;

    //Gestion des projectiles
    public GameObject CharacterProjectile;
    // GameObject CharacterProjectile2;
    public Transform ProjectileSpawn;
    public Transform ProjectileSpawn2;

    public GameObject TriggerShield1;
    public GameObject TriggerShield2;
    public GameObject TriggerShield3;
    public GameObject TriggerShield4;

    private bool isSecondProjectil;

    //Gestion du tir
    public bool _weaponUp = false;
    private float _canFire = -1f;
    [SerializeField] private float _fireRate = 0.2f;

    private bool isShielded = false;

    //Gestion déplacement
    [SerializeField] private float speed = 10;
    [SerializeField] private float speedCam = 4.5f;

    public Transform camera;

    [SerializeField] private float deltaX;
    [SerializeField] private float deltaY;

    Animator animator;
    bool HasGun = false;



    // Detection Murs
    // Points de détection de collision inférieurs gauche et droit
    public Transform downLeft;
    public Transform downRight;

    //Points de détection de collision supérieurs gauche et droit 
    public Transform upLeft;
    public Transform upRight;


    //Points de détection de collision gauche Haut et bas
    public Transform leftUp;
    public Transform leftDown;

    //Points de détection de collision droit Haut et bas
    public Transform rightUp;
    public Transform rightDown;

    public LayerMask groundLayerMask;
    private bool isCollisonDown = false;
    private bool isCollisonUp = false;
    private bool isCollisonLeft = false;
    private bool isCollisonRight = false;

    public float rayLength = 0.5f;







    // Start is called before the first frame update
    void Start()
    {
        characterModel = new CharacterModel(2, 5, 3, 3);
        //characterModel.GetLife().Subscribe(lifeView);
        characterModel.GetPosition().Subscribe(positionView);

        //Changement couleur quand touché
        RendererColorHit = GetComponent<SpriteRenderer>();

        animator = gameObject.GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        //CharacterModel.AddPosition(new Vector2(speedCam * Time.deltaTime, 0));
        //InertiaUp
        //characterModel.AddPosition(new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime));
        //InertiaDown MARCHE INITIALEMENT
        //characterModel.AddPosition(new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime));
        //Déplacement
        DetectionCollisionMur();
        float deltaPositionX = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float deltaPositionY = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        if (deltaPositionY < 0 && isCollisonDown)
        {
            deltaPositionY = 0;
        }
        if (deltaPositionY > 0 && isCollisonUp)
        {
            deltaPositionY = 0;
        }
        if (deltaPositionX < 0 && isCollisonLeft)
        {
            deltaPositionX = 0;

        }
        if (deltaPositionX > 0 && isCollisonRight)
        {
            deltaPositionX = 0;
            speedCam = 0;

        }
        Vector2 deltaPosition = new Vector2(deltaPositionX, deltaPositionY);
        //Character ne peux pas sortir de la camera
        if (characterModel.GetPosition().GetValue().y + deltaPosition.y >= camera.transform.position.y + deltaY)
        {
            deltaPosition.y = 0F;
        }
        if (characterModel.GetPosition().GetValue().y + deltaPosition.y <= camera.transform.position.y - deltaY)
        {
            deltaPosition.y = 0F;
        }

        //Gestion des wall
        /*if (characterModel.GetPosition().GetValue().y + deltaPosition.y >= WallBoxColliderLeft.transform.position.y + deltaY)
        {
            deltaPosition.y = 0F;
        }
        if (characterModel.GetPosition().GetValue().y + deltaPosition.y <= camera.transform.position.y - deltaY)
        {
            deltaPosition.y = 0F;
        }*/

        //Same Speed as camera
        characterModel.AddPosition(new Vector2(speedCam * Time.deltaTime, 0f) + deltaPosition);

        //Gestion du tir
        if (_weaponUp == true)
        {
            if (Time.time > _canFire)
            {
                _canFire = Time.time + _fireRate;
                Instantiate(CharacterProjectile, ProjectileSpawn.position, transform.rotation);

                if(isSecondProjectil==true)
                {
                    Instantiate(CharacterProjectile, ProjectileSpawn2.position, transform.rotation);
                }
            }
        }

        //Gestion LifeView
        if (characterModel.GetLife().GetValue().GetValue() == 3)
        { 
          lifeViewHP1.Enable();
          lifeViewHP2.Enable();
          lifeViewHP3.Enable();
        }
        if (characterModel.GetLife().GetValue().GetValue() == 2)
        {
            lifeViewHP1.Enable();
            lifeViewHP2.Enable();
            lifeViewHP3.Disable();
        }
        if (characterModel.GetLife().GetValue().GetValue() == 1)
        {
            lifeViewHP1.Enable();
            lifeViewHP2.Disable();
            lifeViewHP3.Disable();
        }
        if (characterModel.GetLife().GetValue().GetValue() == 0)
        {
            lifeViewHP1.Disable();
            lifeViewHP2.Disable();
            lifeViewHP3.Disable();
        }

    }

    

    public void OnDamage()
    {
        Debug.Log("-1HP");
        characterModel.AddLife(-1);

        if (characterModel.GetLife().GetValue().GetValue() <= 0f)
        {
            Destroy(gameObject);
            //menuController.Pause(); //Et ouvrir menu pause
            menuController.Pause(); 
        }
    }
    
    //public void Disable(Input.mouse)

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ennemi" || collision.gameObject.tag == "EnnemiProjectil")
        {
            if (isShielded == false)
            {
                //Changement couleur quand touché
                RendererColorHit.color = Color.red;
                Invoke("ChangeColor", 0.15f);
                
                OnDamage();
                
            }
        }

        if (collision.gameObject.tag == "Wall")
        {
            
        }

        //PowerUp Weapon unlocked
            if (collision.gameObject.tag == "PowerUpWeapon")
        {
            _weaponUp = true;

            animator.SetBool("HasGun", true);
        }

        //PowerUp Heal
        if (collision.gameObject.tag == "PowerUpHeal")
        {
            if (characterModel.GetLife().GetValue().GetValue() < 3f || characterModel.GetLife().GetValue().GetValue() > 0f)
            {
                characterModel.AddLife(+1);
                Debug.Log(characterModel.GetLife().GetValue().GetValue() + "HP");
            }
        }

        //PowerUp projectil
        if (collision.gameObject.tag == "PowerUpProjectils")
        {
            isSecondProjectil = true;
        }

        //PowerUp Custom: Shield/Invincibility
        if (collision.gameObject.tag == "PowerUpInvincibilite")
        {
            StartCoroutine(ShieldPowerUp());
            
            Debug.Log("PowerUpShiel taken");
        }

        //Test gestion mur
        if (collision.gameObject.tag == "WallUp")
        {
            Input.GetKeyDown(KeyCode.G);
        }
    }

    //Changement couleur quand touché
    public void ChangeColor()
    {
        RendererColorHit.color = Color.white;
    }

    /*IEnumerator IsTouchedFlash()
    {
        Debug.Log("coroutine charac touched");

        animator.SetBool("IsHurt", true);
        yield return new WaitForSeconds(0.5f);
        //animator.SetBool("IsHurt", false);

    }*/

    //Coroutine PowerUp Shield/Invincibility
    IEnumerator ShieldPowerUp()
    {
        Debug.Log("coroutine Shield");
        animator.SetBool("HasShield", true);
        TriggerShield1.SetActive(true);
        TriggerShield2.SetActive(true);
        TriggerShield3.SetActive(true);
        TriggerShield4.SetActive(true);
        isShielded = true;
        _weaponUp = false;
        yield return new WaitForSeconds(15f);
        animator.SetBool("ShieldBlink", true);
        yield return new WaitForSeconds(5f);
        animator.SetBool("ShieldBlink", false);
        animator.SetBool("HasShield", false);
        isShielded = false;
        animator.SetBool("HasGun", true);
        TriggerShield1.SetActive(false);
        TriggerShield2.SetActive(false);
        TriggerShield3.SetActive(false);
        TriggerShield4.SetActive(false);
        _weaponUp = true;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawLine(downLeft.position, new Vector2(downLeft.position.x, downLeft.position.y - rayLength));
        Gizmos.DrawLine(downRight.position, new Vector2(downRight.position.x, downRight.position.y - rayLength));

        Gizmos.DrawLine(upLeft.position, new Vector2(upLeft.position.x, upLeft.position.y + rayLength));
        Gizmos.DrawLine(upRight.position, new Vector2(upRight.position.x, upRight.position.y + rayLength));

        Gizmos.DrawLine(leftUp.position, new Vector2(leftUp.position.x - rayLength, leftUp.position.y));
        Gizmos.DrawLine(leftDown.position, new Vector2(leftDown.position.x - rayLength, leftDown.position.y));

        Gizmos.DrawLine(rightUp.position, new Vector2(rightUp.position.x + rayLength, rightUp.position.y));
        Gizmos.DrawLine(rightDown.position, new Vector2(rightDown.position.x + rayLength, rightDown.position.y));
    }

    private void DetectionCollisionMur()
    {
        RaycastHit2D downLeftHit = Physics2D.Raycast(downLeft.position, Vector2.down, rayLength, groundLayerMask);
        RaycastHit2D downRightHit = Physics2D.Raycast(downRight.position, Vector2.down, rayLength, groundLayerMask);
        if (downLeftHit.collider != null || downRightHit.collider != null)
        {
            isCollisonDown = true;

        }
        else
        {
            isCollisonDown = false;
        }

        RaycastHit2D upLeftHit = Physics2D.Raycast(upLeft.position, Vector2.up, rayLength, groundLayerMask);
        RaycastHit2D upRightHit = Physics2D.Raycast(upRight.position, Vector2.up, rayLength, groundLayerMask);
        if (upLeftHit.collider != null || upRightHit.collider != null)
        {
            isCollisonUp = true;
        }
        else
        {
            isCollisonUp = false;
        }

        RaycastHit2D leftUpHit = Physics2D.Raycast(leftUp.position, Vector2.left, rayLength, groundLayerMask);
        RaycastHit2D leftDownHit = Physics2D.Raycast(leftDown.position, Vector2.left, rayLength, groundLayerMask);
        if (leftUpHit.collider != null || leftDownHit.collider != null)
        {
            isCollisonLeft = true;
        }
        else
        {
            isCollisonLeft = false;
        }

        RaycastHit2D rightUpHit = Physics2D.Raycast(rightUp.position, Vector2.right, rayLength, groundLayerMask);
        RaycastHit2D rightDownHit = Physics2D.Raycast(rightDown.position, Vector2.right, rayLength, groundLayerMask);
        if (rightUpHit.collider != null || rightDownHit.collider != null)
        {
            isCollisonRight = true;
            speedCam = 0;
        }
        else
        {
            isCollisonRight = false;
            speedCam = 4.5f;
        }
    }
}
