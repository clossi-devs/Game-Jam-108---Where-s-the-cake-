using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script is a management script to manage
/// interactions between multiple scripts.
/// </summary>
public class Clos_PlayerManagerScript : MonoBehaviour
{
    [Header("Scripts Attatched")]
    public bool Clos_PlayerStats = false;

    [Header("Player Stats Settings")]
    public bool usingCustomStats = true;
    public int startingHP = 100;
    public int minHP = 0;
    public int maxHP = 100;
    public int bonusHP = 0;


    private PlayerStats ps;

    // *********************
    // ** Initializations
    // *********************
    void Start ()
    {
        InitializePlayerStats();
    }

    private void InitializePlayerStats ()
    {
        if(Clos_PlayerStats)
        {
            ps = new PlayerStats();
            if (usingCustomStats) { ps.SetValues(startingHP, minHP, maxHP, bonusHP); }
        }
    }

    // **************************
    // ** Manage Player Stats
    // **************************

    // ** Health Section
    public void DamagePlayer (int dmg)
    {
        if (Clos_PlayerStats) { ps.TakeHP(dmg); }
    }

    public void HealPlayer (int gain)
    {
        if (Clos_PlayerStats) { ps.GainHP(gain); }
    }

    public void MaxHealPlayer ()
    {
        if (Clos_PlayerStats) { ps.ResetHP(); }
    }

    public void SetPlayerMaxHP (int hp)
    {
        if (Clos_PlayerStats) { ps.maxHP = hp; }
    }

    public void SetPlayerMinHP(int hp)
    {
        if (Clos_PlayerStats) { ps.minHP = hp; }
    }

    public void SetPlayerBonusHP(int bhp)
    {
        if (Clos_PlayerStats) { ps.bonusHP = bhp; }
    }
}
