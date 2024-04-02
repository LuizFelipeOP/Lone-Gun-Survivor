using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField]
	private GameObject swarmerPrefab;

	[SerializeField]
	private float swarmerInterval = 3.5f;

	[SerializeField]
	private float numberOfEnemies = 0;

	void Start()
	{
		StartCoroutine(spawmEnemy(swarmerInterval, swarmerPrefab)); 
    
	}
	private IEnumerator spawmEnemy(float interval, GameObject enemy)
    {
		if (numberOfEnemies < 3)
		{
			yield return new WaitForSeconds(interval);
			GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
			numberOfEnemies++;
			StartCoroutine(spawmEnemy(interval, enemy));
		}
		

	}
}
