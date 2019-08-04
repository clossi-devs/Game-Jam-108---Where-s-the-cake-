using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Class to keep track of, and manage, enemy stats.
/// </summary>
public class EnemyStats
{
    // ***************
    // ** Settings
    // ***************

    // Misc
    public string name = "Enemy";

    // Default health values.
    public int hp = 100;
    public int maxHP = 100;
    public int minHP = 0;
    public int bonusHP = 0;

    // Default fight values
    public int atk = 10;
    public int bonusAtk = 0;

    /// <summary>
    /// Override default health values and set custom healt values.
    /// </summary>
    /// <param name="h">Health Point</param>
    /// <param name="mh">Min Health</param>
    /// <param name="mah">Max Health</param>
    /// <param name="bh">Bonus Health</param>
    public void SetCustomHPValues(int h, int mh, int mah, int bh)
    {
        hp = h;
        minHP = mh;
        maxHP = mah;
        bonusHP = bh;
    }

    /// <summary>
    /// Set custom attack values.
    /// </summary>
    /// <param name="dmg">Base attack damage.</param>
    /// <param name="bdmg">Bonus attack damage.</param>
    public void SetCustomAtkValues (int dmg, int bdmg)
    {
        int atk = dmg;
        int bonusAtk = bdmg;
    }


    // *******************************
    // ** Health Management Section
    // *******************************

    /// <summary>
    /// Takes the amount given from hp. Will set to minHP is lower than minHP.
    /// </summary>
    /// <param name="dmg">Amount to take from hp.</param>
    public void TakeHP(int dmg)
    {
        hp = hp - dmg;
        if (hp < 0) { hp = 0; }
    }

    /// <summary>
    /// Gains hp by the amount given. If exceeding maxHP+bonusHP, hp will ResetHP.
    /// </summary>
    /// <param name="gain">Amount to add to hp.</param>
    public void GainHP(int gain)
    {
        hp = hp + gain;
        if (hp > maxHP + bonusHP) { ResetHP(); }
    }

    /// <summary>
    /// Sets hp to maxHP + bonusHP.
    /// </summary>
    public void ResetHP()
    {
        hp = maxHP + bonusHP;
    }

    // *******************************
    // ** Attack Management Section
    // *******************************

    /// <summary>
    /// Get the damage from this enemy.
    /// </summary>
    /// <returns>Returns atk + bonusAtk</returns>
    public int GetDamage ()
    {
        return atk + bonusAtk;
    }
}

public class Clos_EnemyStats : MonoBehaviour
{
    [Header("Debug Script Loading")]
    public bool debugCheck = true;

    // Start is called before the first frame update
    void Start()
    {
        if (debugCheck) { Debug.Log("Clos_EnemyStats script loaded."); }
    }
}
