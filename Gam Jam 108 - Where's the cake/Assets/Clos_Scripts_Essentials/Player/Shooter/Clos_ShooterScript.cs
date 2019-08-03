using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This shooter script is to manage how a player
/// shoots a bullet.
/// </summary>

public class Clos_ShooterScript : MonoBehaviour
{
    [Header("Shooter Settings")]
    public bool canFire = true;
    public string fireKey = "space";
    [Tooltip("Add a delay before the player can fire another bullet.")]
    public bool delayRefire = true;
    public float refireDelay = 0.25f;

    [Header("Objects")]
    public GameObject bullet;
    [Tooltip("The transform position that the bullet will spawn in.")]
    public GameObject bulletSpawn;


    private void Update ()
    {
        Fire();
    }

    public void SetCanFire (bool state)
    {
        canFire = state;
    }

    private void SpawnBullet ()
    {
        GameObject go = Instantiate(bullet, Vector3.zero, Quaternion.identity);
        go.transform.position = bulletSpawn.transform.position;
        go.transform.rotation = bulletSpawn.transform.rotation;
    }

    private void Fire ()
    {
        if (canFire)
        {
            if (Input.GetKeyDown(fireKey))
            {
                SpawnBullet();
                if (delayRefire) { canFire = false; StartCoroutine(WaitForRefire()); }
            }
        }
    }

    IEnumerator WaitForRefire ()
    {
        Debug.Log("Waiting");
        yield return new WaitForSeconds(refireDelay);
        canFire = true;
        Debug.Log("Wait Over");
    }
}
