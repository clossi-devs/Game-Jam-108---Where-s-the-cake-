using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is dependent on Clos_EnemyStats script.
/// </summary>
public class Clos_CustomEnemies : MonoBehaviour
{
    // Dependant scripts
    private bool clos_EnemyStatsAttatched = false;

    [Header("Enemy Stats Settings")]
    public string name = "Default Enemy";
    public int hp = 100;
    public int maxHP = 100;
    public int minHP = 0;
    public int bonusHP = 0;
    public int atk = 10;
    public int bonusAtk = 0;

    [Header("Enemy Behavior Settings")]
    [Tooltip("Should this object be destroyed after reaching minHP?")]
    public bool detroyOnMinHP = true;

    private EnemyStats es;

    public GameObject WinningCanvas;

    // Start is called before the first frame update
    void Start()
    {
        CheckForDependentScripts();
        InitializeEnemyStats();
        WinningCanvas = GameObject.FindGameObjectWithTag("WinningCanvas");
    }

    private void CheckForDependentScripts()
    {
        if (!this.GetComponent<Clos_EnemyStats>()) { Debug.LogWarning("Missing Dependant Script Clos_EnemyStats"); }
    }

    private void InitializeEnemyStats()
    {
        es = new EnemyStats();
        es.name = name;
        es.SetCustomHPValues(hp, minHP, maxHP, bonusHP);
        es.SetCustomAtkValues(atk, bonusAtk);
    }

    public EnemyStats GetEnemyStats()
    {
        return es;
    }

    public void TakeEnemyHP(int dmg)
    {
        es.TakeHP(dmg);
        if (detroyOnMinHP) { if (es.hp <= es.minHP) { DestroyThisObject(); } }
    }

    public void DestroyThisObject()
    {
        Destroy(this.gameObject);
        if (name == "boss")
            WinningCanvas.GetComponent<WinLoseMenu>().IsGameWon = true;
    }
}
