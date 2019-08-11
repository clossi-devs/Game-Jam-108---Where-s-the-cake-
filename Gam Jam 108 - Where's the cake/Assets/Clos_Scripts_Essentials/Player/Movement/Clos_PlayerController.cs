using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A script made by Clossius to control
/// a player GameObject.
/// https://docs.unity3d.com/Manual/ConventionalGameInput.html
/// </summary>

public class Clos_PlayerController : MonoBehaviour
{

    // ****************
    // ** Settings
    // ****************

    private Rigidbody rb;

    // ** Movement
    private float forward = 0.0f;
    private float side = 0.0f;
    private float rotate = 0.0f;
    private Quaternion currentRotation;

    [Header("Movement Settings")]
    [Tooltip("Sets if this object can move forwards and backwards.")]
    public bool canMoveForward = true;
    [Tooltip("Sets if this object can move left and right")]
    public bool canMoveSideways = true;
    [Tooltip("Sets if this object can rotate left and right.")]
    public bool canRotate = true;
    [Tooltip("Sets if this object can have a speed multiplier.")]
    public bool canRun = true;

    [Header("Movement Keys (lower case)")]
    public string forwardKey = "w";
    public string backKey = "s";
    public string moveLeftKey = "a";
    public string moveRightKey = "d";
    public string runKey = "space";
    public string rotLeftKey = "left";
    public string rotRightKey = "right";

    [Header("Movement Speeds")]
    public float forwardWalkingSpeed = 6.0f;
    public float sideWalkingSpeed = 6.0f;
    public float rotateSpeed = 100.0f;
    [Tooltip("Multiplies the Forward Walking Speed by the set number.")]
    public float runningMultiplier = 2.0f;

    // ** Look Settings
    [Header("Look Settings")]
    [Tooltip("Using Look at will have this Game Object look at an object when spawned.")]
    public bool usingLookAt;
    [Tooltip("Set the GameObject for this object to look at when spawning.")]
    public GameObject lookAtName; // This can either be a string or GameObject

    private PlayerAnimatorManager playerAnimator;

    // ********************
    // ** Main Functions
    // ********************

    // Start is called before the first frame update
    void Start()
    {
        InitializePlayer();
        OnSpawnLookAt(lookAtName);
        SetRotation();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    // *************************
    // ** Play Spawn Section
    // *************************

    // Set the initial settings.
    private void InitializePlayer()
    {
        rb = this.GetComponent<Rigidbody>();
        playerAnimator = this.GetComponent<PlayerAnimatorManager>();
    }

    // Find an object for the player to look at
    // when spawning.
    public void OnSpawnLookAt(GameObject obj)
    {
        if (usingLookAt) { this.transform.LookAt(obj.transform.position); }
    }


    // ******************************
    // ** Scene management section
    // ******************************
    private void SceneChange(string scene)
    {
        SceneManager.LoadScene("GameOver");
    }


    // ******************************
    // ** Player Movement Section
    // ******************************

    private void Move()
    {
        ChangeSpeed();
        MovePlayerForward();
        MovePlayerSideways();
        RotatePlayer();
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (forward != 0)
            playerAnimator.SetRunning();
        else
            playerAnimator.SetIdle();
    }

    private void MovePlayerForward()
    {
        if (canMoveForward)
        {
            transform.Translate(Vector3.forward * forward * Time.deltaTime);
            playerAnimator.SetRunning();
        }
    }

    private void MovePlayerSideways()
    {
        if (canMoveSideways) { transform.Translate(Vector3.right * side * Time.deltaTime); }
    }

    private void RotatePlayer()
    {
        if (canRotate)
        {
            if (rotate != 0) { this.transform.Rotate(Vector3.up * rotate * Time.deltaTime); SetRotation(); }
            else { this.transform.rotation = currentRotation; }
        }
    }

    // ** Set Speeds

    private void SetRotation()
    {
        if (canRotate) { currentRotation = this.transform.rotation; }
    }

    private void ChangeSpeed()
    {
        ForwardSpeed();
        SideSpeed();
        RotateSpeed();
        RunningSpeed();
    }

    // Back speed is just negative forward speed.
    private void ForwardSpeed()
    {
        if (canMoveForward)
        {
            if (Input.GetKey(forwardKey)) { forward = forwardWalkingSpeed; }
            else if (Input.GetKey(backKey)) { forward = -forwardWalkingSpeed; }
            else { forward = 0.0f; }
        }
    }

    private void SideSpeed()
    {
        if (canMoveSideways)
        {
            if (Input.GetKey(moveLeftKey)) { side = -sideWalkingSpeed; }
            else if (Input.GetKey(moveRightKey)) { side = sideWalkingSpeed; }
            else { side = 0.0f; }
        }
    }

    private void RotateSpeed()
    {
        if (canRotate)
        {
            if (Input.GetKey(rotLeftKey)) { rotate = -rotateSpeed; }
            else if (Input.GetKey(rotRightKey)) { rotate = rotateSpeed; }
            else { rotate = 0.0f; }
        }
    }

    private void RunningSpeed()
    {
        if (canRun)
        {
            if (Input.GetKey(runKey))
            {
                forward = forward * runningMultiplier;
                side = side * runningMultiplier;
                rotate = rotate * runningMultiplier;
            }
        }
    }
}
