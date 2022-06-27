using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCharacter : MonoBehaviour
{
    //[SerializeField] private LifeView lifeView;
    [SerializeField] private PositionView positionView;
    private CharacterModel characterModel;

    [SerializeField] private MenuController menuController;

    //Gestion des projectiles
    public GameObject CharacterProjectile;
    // GameObject CharacterProjectile2;
    public Transform ProjectileSpawn;
    public Transform ProjectileSpawn2;

    private bool isSecondProjectil;

    //Gestion du tir
    public bool _weaponUp = false;
    private float _canFire = -1f;
    [SerializeField] private float _fireRate = 0.2f;

    [SerializeField] private float speed = 10;
    [SerializeField] private float speedCam = 4.5f;

    public Transform camera;

    [SerializeField] private float deltaX;
    [SerializeField] private float deltaY;

    Animator animator;
    bool HasGun = false;

    // Start is called before the first frame update
    void Start()
    {
        characterModel = new CharacterModel(2, 5, 3, 3);
        //characterModel.GetLife().Subscribe(lifeView);
        characterModel.GetPosition().Subscribe(positionView);

        animator = gameObject.GetComponent<Animator>();

        //menuController = new MenuController();
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
        float deltaPositionX = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float deltaPositionY = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ennemi" || collision.gameObject.tag == "EnemyProjectil")
        {
            OnDamage();
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

        if (collision.gameObject.tag == "PowerUpProjectils")
        {
            isSecondProjectil = true;
        }

        if (collision.gameObject.tag == "PowerUpInvincibilite")
        {
            StartCoroutine(ShieldPowerUp());
            Debug.Log("PowerUpShiel taken");
        }
    }

    IEnumerator ShieldPowerUp()
    {
        Debug.Log("coroutine de tes morts");
        animator.SetBool("HasShield", true);
        _weaponUp = false;
        yield return new WaitForSeconds(15f);
        animator.SetBool("HasShield", false);
        //animator.SetBool("ShieldSoonDown", true);
        //yield return new WaitForSeconds(5f);
        //animator.SetBool("ShieldSoonDown", false);
        animator.SetBool("HasGun", true);
        _weaponUp = true;
    }
}
