using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clos_EnemySpawner : MonoBehaviour
{
    public bool spawnOnStart = false;
    bool spawning = false;
    public GameObject enemy;
    public float secondsToWait = 1.0f;
    public string targetTag = "Player";
    public int maxEnemies = 10;

    private List<GameObject> enemies;

    void Start ()
    {
        spawning = spawnOnStart;
        enemies = new List<GameObject>();
        if (spawning) { SpawnEnemy(); StartCoroutine(WaitToSpawn()); }
    }

    IEnumerator WaitToSpawn ()
    {
        yield return new WaitForSeconds(secondsToWait);
        if (spawning) { SpawnEnemy(); StartCoroutine(WaitToSpawn()); }
    }

    private void SpawnEnemy ()
    {
        CleanEnemyList();

        if (enemies.Count < maxEnemies)
        {
            enemies.Add(Instantiate(enemy, this.transform.position, Quaternion.identity));
        }
    }

    private void CleanEnemyList ()
    {
        for (int i=enemies.Count-1; i>0; i--) { if (enemies[i] == null) { enemies.RemoveAt(i); } }
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == targetTag) { spawning = true; SpawnEnemy(); StartCoroutine(WaitToSpawn()); }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.tag == targetTag) { spawning = false; }
        
    }
}
