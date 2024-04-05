using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject itemDrop;
    void Start()
    {
        Debug.Log("log start item");
    }
    public PlayerController MyPlayer;

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag.Equals("Player") == true)
        {
            Destroy(gameObject);
            //MyPlayer.moveSpeed = 6f;
        }
    }
    public void SpawmItemType()
    {
        float porcent = Random.Range(1, 10);
        //Instantiate(itemDrop, transform.position + new Vector3(0, -1, 0), Quaternion.identity);
    }
}
