using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clos_EnemyManager : MonoBehaviour
{
    [Header("Settings")]
    public string playerTag = "Player";
    public bool destroyOnDmgPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        if (!this.GetComponent<Clos_CustomEnemies>()) { Debug.LogError("Missing dependant script: Clos_CustomEnemies"); }
        if (!this.GetComponent<Clos_EnemyStats>()) { Debug.LogError("Missing dependant script: clos_EnemyStats"); }
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == playerTag) { DamagePlayer(other.gameObject); }
    }

    private void DamagePlayer (GameObject player)
    {
        EnemyStats es = this.GetComponent<Clos_CustomEnemies>().GetEnemyStats();

        if (player.GetComponent<Clos_PlayerManagerScript>())
        {
            player.GetComponent<Clos_PlayerManagerScript>().DamagePlayer(es.GetDamage());
            if (destroyOnDmgPlayer) { this.GetComponent<Clos_CustomEnemies>().DestroyThisObject(); }
        }
        else { Debug.Log("Clos_PlayerManager Script not attatched to player. Insert custom functions to current script" +
            " Clos_EnemyManager on function DamagePlayer."); }
    }
}
