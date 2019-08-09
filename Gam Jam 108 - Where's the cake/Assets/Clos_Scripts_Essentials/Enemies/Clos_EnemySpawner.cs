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

    void Start ()
    {
        spawning = spawnOnStart;
        if (spawning) { SpawnEnemy(); StartCoroutine(WaitToSpawn()); }
    }

    IEnumerator WaitToSpawn ()
    {
        yield return new WaitForSeconds(secondsToWait);
        if (spawning) { SpawnEnemy(); StartCoroutine(WaitToSpawn()); }
    }

    private void SpawnEnemy ()
    {
        Instantiate(enemy, this.transform.position, Quaternion.identity);
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
