using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A basic class for managing Player stats.
/// </summary>
public class PlayerStats
{
    // Default values.
    public int hp = 100;
    public int minHP = 0;
    public int maxHP = 100;
    public int bonusHP = 0;

    /// <summary>
    /// Override default values and set custom values.
    /// </summary>
    /// <param name="h">Health Point</param>
    /// <param name="mh">Min Health</param>
    /// <param name="mah">Max Health</param>
    /// <param name="bh">Bonus Health</param>
    public void SetValues (int h, int mh, int mah, int bh)
    {
        hp = h;
        minHP = mh;
        maxHP = mah;
        bonusHP = bh;
    }

    /// <summary>
    /// Takes the amount given from hp. Will set to minHP is lower than minHP.
    /// </summary>
    /// <param name="dmg">Amount to take from hp.</param>
    public void TakeHP (int dmg)
    {
        hp = hp - dmg;
        if (hp < 0) { hp = 0; }
    }

    /// <summary>
    /// Gains hp by the amount given. If exceeding maxHP+bonusHP, hp will ResetHP.
    /// </summary>
    /// <param name="gain">Amount to add to hp.</param>
    public void GainHP (int gain)
    {
        hp = hp + gain;
        if (hp > maxHP + bonusHP) { ResetHP(); }
    }

    /// <summary>
    /// Sets hp to maxHP + bonusHP.
    /// </summary>
    public void ResetHP ()
    {
        hp = maxHP + bonusHP;
    }
}

public class Clos_PlayerStats : MonoBehaviour
{
    [Header("Debug Check")]
    public bool debugCheck = true;

    void Start ()
    {
        if (debugCheck) { Debug.Log("Clos_PlayerStats Loaded."); }
    }
}
