using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clos_BulletScript : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        DestroyAfterSeconds();
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
}
