using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    private Animator playerAnimator;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void SetWalking()
    {
        ResetFields();
        playerAnimator.SetBool("IsWalking", true);
    }

    public void SetRunning()
    {
        ResetFields();
        playerAnimator.SetBool("IsRunning", true);
    }

    public void SetIdle()
    {
        ResetFields();
        playerAnimator.SetBool("IsIdle", true);
    }

    public void SetGettingHit()
    {
        ResetFields();
        playerAnimator.SetBool("GettingHit", true);
    }

    private void ResetFields()
    {
        playerAnimator.SetBool("IsWalking", false);
        playerAnimator.SetBool("IsIdle", false);
        playerAnimator.SetBool("IsRunning", false);
        playerAnimator.SetBool("GettingHit", false);
    }
}
