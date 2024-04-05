using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField]
	private GameObject swarmerPrefab;

	[SerializeField]
	private float swarmerInterval = 3.5f;

	private float numberOfEnemies = 0;
	public Rigidbody2D rb;

	void Start()
	{
		StartCoroutine(spawmEnemy(swarmerInterval, swarmerPrefab)); 
    
	}
	private IEnumerator spawmEnemy(float interval, GameObject enemy)
    {
		if (numberOfEnemies < 3)
		{
			yield return new WaitForSeconds(Random.Range(1, 5));
			Instantiate(enemy, rb.position, Quaternion.identity);
			numberOfEnemies++;
			StartCoroutine(spawmEnemy(interval, enemy));
		}
		

	}
}
