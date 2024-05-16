using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveDirection;
    public Vector2 shootDirection;
    private float shootingAngle;

    [SerializeField]
    public float moveSpeed = 4f;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarScript healthBar;


    public Rigidbody2D rb;

    private float timeBtwShots;
    private float startTimeBtwShots = 0.9f;

    public Animator animator;
    private string currentState;
    public GameObject projectilePrefab;
    public GameObject itemDrop;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        timeBtwShots = startTimeBtwShots;

    }
    private float attackDelay = 0.5f;
    private bool isAttackPressed;
    private bool isAttacking;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        shootDirection = context.ReadValue<Vector2>();
    }


    private void Update()
    {
        if(currentHealth > 0)
        {
            if (shootDirection != Vector2.zero)
            {
                ChangeAnimationState("Shooting");

                shootingAngle = 0.7f;
                if (shootDirection == Vector2.down)
                {
                    shootingAngle = 1.1f;
                }

                animator.SetFloat("HorizontalShooting", shootDirection.x);
                animator.SetFloat("VerticalShooting", shootDirection.y);
                isAttackPressed = true;

            }
            else
            {
                ChangeAnimationState("Moviment");

                animator.SetFloat("Horizontal", moveDirection.x);
                animator.SetFloat("Vertical", moveDirection.y);
                animator.SetFloat("Speed", moveDirection.sqrMagnitude);
            }
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(moveSpeed * Time.deltaTime * moveDirection);

        AimShoot();

    }
    void AimShoot()
    {

        if (shootDirection != Vector2.zero && timeBtwShots < 0)
        {
            Launch();
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void Launch()
    {
        if (isAttackPressed)
        {
            isAttackPressed = false;

            if (!isAttacking)
            {
                isAttacking = true;

                GameObject projectileObject = Instantiate(projectilePrefab, rb.position + (shootDirection * shootingAngle), Quaternion.identity);

                ProjectileController projectile = projectileObject.GetComponent<ProjectileController>();
                projectile.Launch(shootDirection, 500);

                Invoke("AttackComplete", attackDelay);
                //AttackComplete();
            }
        }

    }

    void AttackComplete()
    {
        timeBtwShots = startTimeBtwShots;
        isAttacking = false;
    }

    void ChangeAnimationState(string newState)
    {

        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }

    void OnCollisionEnter2D(Collision2D target)
    {

        switch (target.transform.tag)
        {
            case "CoffeeShot":
                moveSpeed += 3;
                Invoke("RegularSpeed", 5);
                break;

            case "Triangle": //"SubmachineGun"
                attackDelay = 0.1f;
                startTimeBtwShots = .3f;
                Invoke("RegularWeapon", 10);
                break;
            case "HealthAppleRotten": //sprite smaller then Item collider 
                ModifyHealth(30);
                break;
            case "Enemy":
                ModifyHealth(-20);
                break;
            case "Boss":
                ModifyHealth(-50);
                break;
            }
                //if (other.tag == "Enemy" || other.tag == "EnemyBullet")
                //{
                //    // Enemy damages player
                //    //TakeDamage(20);

                //    //Spawn power up
                //    itemDrop.GetComponent<ItemDrop>().Death();

                //}
                //if (other.tag == "Boss" || other.tag == "BossBullet")
                //{
                //    //TakeDamage(50);
                //    itemDrop.GetComponent<ItemDrop>().Death();
                //}

    }
    void ModifyHealth(int healthChange)
    {
        if(currentHealth > 1)
        {
            currentHealth += healthChange;
            healthBar.SetHealth(currentHealth);
        }
    }
    
    void RegularSpeed()
    {

        moveSpeed = 4f;
        startTimeBtwShots = 0.9f;
    }
    void RegularWeapon()
    {

        attackDelay = 0.5f;
    }
}