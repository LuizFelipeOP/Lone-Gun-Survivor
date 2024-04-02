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
    public float moveSpeed;
    public Rigidbody2D rb;

    private float timeBtwShots;
    public float startTimeBtwShots = 0.6f;

    public Animator animator;
    private string currentState;
    public GameObject projectilePrefab;

    private void Start()
    {
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
        if (shootDirection != Vector2.zero)
        {
            ChangeAnimationState("Shooting");

            moveSpeed = 1f;

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

            moveSpeed = 4f;

            animator.SetFloat("Horizontal", moveDirection.x);
            animator.SetFloat("Vertical", moveDirection.y);
            animator.SetFloat("Speed", moveDirection.sqrMagnitude);
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
}