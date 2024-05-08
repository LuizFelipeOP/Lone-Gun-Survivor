using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject pickupEffect;
    public GameObject itemDrop;
    Object[] objectsArray;
    public Rigidbody2D rb;

    public float percentDrop = 50f;

    void Awake()
    {
        objectsArray = Resources.LoadAll("Items", typeof(Sprite));
    }

    void Start()
    {
        gameObject.tag = "CoffeeShot";
        int item = Random.Range(0, objectsArray.Length);
        this.GetComponent<SpriteRenderer>().sprite = Instantiate(objectsArray[item]) as Sprite;

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("OnCollisionEnter2D");
        if (other.transform.tag == "Player")
        {
            Pickup(other);
        }
    }

    void Pickup(Collision2D player)
    {
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        Debug.Log("Picked Up");
        Destroy(gameObject);

    }

    public void Death()
    {

        float rand = Random.Range(0f, 2f);
        if (rand < percentDrop)
        {
            //Spawn PowerUp
            Instantiate(itemDrop, transform.position, Quaternion.identity);
        }

    }
}

