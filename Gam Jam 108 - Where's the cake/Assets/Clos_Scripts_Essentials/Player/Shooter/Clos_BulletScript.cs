using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script is to manage a custom bullet.
/// *****
/// !!!*****This script requires a collider and rigidbody component.*****!!!
/// *****
/// </summary>
public class Clos_BulletScript : MonoBehaviour
{
    [Header("Optional Dependants")]
    public bool usingClos_CustomEnemies = true;

    [Header("Lifespan Settings")]
    [Tooltip("Should this object be destroyed after given seconds.")]
    public bool destroyThis = true;
    [Tooltip("How many seconds until this object is destroyed.")]
    public float lifeSpan = 3.0f;

    // Movement
    [Header("Movement Settings")]
    public bool moveOnSpawn = true;
    public float speed = 6.0f;
    public float moveX = 0.0f;
    public float moveY = 0.0f;
    public float moveZ = 1.0f;

    // Stats
    [Header("Stats")]
    public bool usingDmg = true;
    public string tagToDmg = "Enemy";
    public int dmg = 10;

    // Start is called before the first frame update
    void Start()
    {
        if (usingDmg) { if (!this.GetComponent<Rigidbody>()) { Debug.LogWarning("Mising Rigidbody Component."); } }
        DestroyAfterSeconds();
        // - Audio
        AkSoundEngine.PostEvent("Gun_Shot", gameObject);
    }

    void FixedUpdate ()
    {
        Move();
    }

    private void DestroyAfterSeconds ()
    {
        if (destroyThis) { Destroy(this.gameObject, lifeSpan); }
    }

    private void Move ()
    {
        if (moveOnSpawn) { transform.Translate(new Vector3(moveX, moveY, moveZ) * speed * Time.deltaTime); }
    }

    // Called when colliding with a trigger.
    // This scipt requires a dependant script.
    // To call your own script, put your own function
    // calls in the marked spot.
    private void OnTriggerEnter (Collider other)
    {
        if (usingDmg)
        {
            if (other.tag == tagToDmg)
            {
                // Tag to Damage found.

                // ** (Optional) Insert custom functions here.

                // Requires dependant Clos_CustomEnemies
                if (usingClos_CustomEnemies) { other.GetComponent<Clos_CustomEnemies>().TakeEnemyHP(dmg); Destroy(this.gameObject); }
            }
        }
    }
}
