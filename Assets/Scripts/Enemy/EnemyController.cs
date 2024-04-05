using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField]
    private GameObject deadEnemyPrefab;
    public Rigidbody2D rb;
    [SerializeField]
    private GameObject itemDrop;

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag.Equals("Projectile") == true)
        {
            
            Instantiate(deadEnemyPrefab, rb.position, Quaternion.identity);

            float porcent = Random.Range(1, 10);
            
            //if (porcent == 5) {
                Instantiate(itemDrop, transform.position + new Vector3(0, -1, 0), Quaternion.identity);
                gameObject.GetComponent<ItemDrop>().SpawmItemType(); 
            //} 

            Destroy(gameObject);
        }
    }
    
}
