using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyAnimationManager : MonoBehaviour
{
    private Animator basicEnemyAnimator;
    void Start()
    {
        basicEnemyAnimator = GetComponent<Animator>();
    }

    public void SetIdle()
    {
        basicEnemyAnimator.SetBool("CanSeePlayer", false);
    }

    public void SetAttacking()
    {
        basicEnemyAnimator.SetBool("CanSeePlayer", true);
    }
}
