using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///	Attatch this script to a Game Object that you do not want
/// destroyed when a new scene is loaded.
/// </summar>

public class DDOL : MonoBehaviour
{
	// Called before Start.
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject); // Keeps this game object alive through scene loading.
    }
}