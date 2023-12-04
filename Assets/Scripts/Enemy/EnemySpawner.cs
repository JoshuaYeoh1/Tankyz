using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameObject player;
    public List<GameObject> enemyList = new List<GameObject>();
    public GameObject[] enemySpawners;

    public int maxEnemies=10;
    public GameObject enemyPrefab;
    public float spawnTimeMin=1, spawnTimeMax=10, spawnRangeMin=100;

    void OnEnable()
    {
        StartCoroutine(spawningEnemies());
    }

    void Update()
    {
        if(!player) player = GameObject.FindGameObjectWithTag("Player");
    }

    IEnumerator spawningEnemies()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(spawnTimeMin, spawnTimeMax));

            if(enemyList.Count<maxEnemies)
            {
                enemySpawners = GameObject.FindGameObjectsWithTag("EnemySpawner");

                if(enemySpawners.Length>0)
                {
                    GameObject chosenSpawner = enemySpawners[Random.Range(0, enemySpawners.Length)];

                    if(Vector3.Distance(chosenSpawner.transform.position, player.transform.position)>spawnRangeMin)
                    {
                        GameObject enemy = Instantiate(enemyPrefab, chosenSpawner.transform.position, Quaternion.identity);

                        Vector3 tempScale = enemy.transform.localScale;
                        enemy.transform.localScale=Vector3.zero;
                        LeanTween.scale(enemy, tempScale, .5f).setEaseInOutSine();

                        enemyList.Add(enemy);
                    }
                }
            }
        }
    }
}
