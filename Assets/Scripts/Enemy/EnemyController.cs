using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   

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
        if (target.gameObject.tag.Equals("Projectile") )
        {
                //zombie e instaciado na tela, ao ser atingido ele dropa uim item.
                //esse item chama o ItemDrop, controller, que gerencia qual item deve escolher, um prefab de item, fazer no update
            Instantiate(deadEnemyPrefab, rb.position, Quaternion.identity);

            float porcent = Random.Range(1, 10);

            Instantiate(itemDrop, transform.position + new Vector3(0, -1, 0), Quaternion.identity);


            Destroy(gameObject);
        }
    }
    
}
