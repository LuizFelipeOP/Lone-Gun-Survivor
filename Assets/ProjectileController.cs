using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public Rigidbody2D rb;

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //}
    public void Launch(Vector2 direction, float force)
    {
        rb.AddForce(direction * force);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        //we also add a debug log to know what the projectile touch
        Debug.Log("Projectile Collision with " + other.gameObject);
        Destroy(gameObject);
    }
    void Update()
    {
        
    }
}
