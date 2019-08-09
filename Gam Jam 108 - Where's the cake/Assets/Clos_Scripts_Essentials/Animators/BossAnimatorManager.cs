using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimatorManager : MonoBehaviour
{
    private Animator bossAnimator;
    void Start()
    {
        bossAnimator = GetComponent<Animator>();
    }

    public void SetIdle()
    {
        bossAnimator.SetBool("CanSeePlayer", false);
    }

    public void SetAttacking()
    {
        bossAnimator.SetBool("CanSeePlayer", true);
    }

    public void SetAttackOnCooldown()
    {
        bossAnimator.SetBool("AttackOnCooldown", true);
    }

    public void SetCooldownComplete()
    {
        bossAnimator.SetBool("AttackOnCooldown", false);
    }
}
