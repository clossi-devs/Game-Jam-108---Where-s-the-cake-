using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

	// ****************
	// ** Settings
	// ****************

	private Rigidbody rb;
    
	// ** Movement
	private float speed = 0.0f;
	private float rotate = 0.0f;
	private Quaternion currentRotation;
    
	// ** Public Movement
	[Header("Movement Settings")]
	public float forwardWalkingSpeed = 6.0f;
	public float rotateSpeed = 100.0f;
	[Tooltip("Multiplies the Forward Walking Speed by the set number.")]
	public float runningMultiplier = 2.0f;

	// ********************
	// ** Main Functions
	// ********************
	
    // Start is called before the first frame update
    void Start()
    {
        InitializePlayer();
        OnSpawnLookAt("LookAt");
        SetRotation();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckForBug(-10.0f);
    }

    // *************************
    // ** Play Spawn Section
    // *************************

    // Set the initial settings.
    private void InitializePlayer ()
    {
    	rb = this.GetComponent<Rigidbody>();
    }

    // Find an object for the player to look at
    // when spawning.
    public void OnSpawnLookAt (string obj)
    {
    	this.transform.LookAt(GameObject.Find(obj).transform.position);
    }

    // Overload if a game object is provided.
    public void OnSpawnLookAt (GameObject obj)
    {
    	this.transform.LookAt(obj.transform.position);
    }


    // ******************************
    // ** Scene management section
    // ******************************
    private void SceneChange (string scene)
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
    	RotatePlayer();	
    }

    // In a seperate function in case I want to work with
    // different types of movements.
    private void MovePlayerForward ()
    {
    	rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
    }

    private void RotatePlayer ()
    {
    	if(rotate != 0){this.transform.Rotate(Vector3.up * rotate * Time.deltaTime); SetRotation();}
    	else {this.transform.rotation = currentRotation;}
    }

    // ** Set Speeds

    private void SetRotation ()
    {
    	currentRotation = this.transform.rotation;
    }

    private void ChangeSpeed ()
    {
    	ForwardSpeed();
    	RotateSpeed();
    	RunningSpeed();
    }

    // Back speed is just negative forward speed.
    private void ForwardSpeed ()
    {
    	if(Input.GetKey(KeyCode.W)){speed = forwardWalkingSpeed;}
    	else if (Input.GetKey(KeyCode.S)){speed = -forwardWalkingSpeed;}
    	else {speed = 0.0f;}
    }

    private void RotateSpeed ()
    {
    	// Rotate
    	if(Input.GetKey(KeyCode.A)){rotate = -rotateSpeed;}
    	else if(Input.GetKey(KeyCode.D)){rotate = rotateSpeed;}
    	else {rotate = 0.0f;}
    }

    private void RunningSpeed ()
    {
    	// Run
    	if(Input.GetKey(KeyCode.Space)){speed = speed * runningMultiplier; rotate = rotate * runningMultiplier;}
    }


    // ********************
    // ** Misc Section
    // ********************

    private void OnTriggerEnter (Collider other)
    {
    	if(other.tag == "Drone"){SceneManager.LoadScene("GameOver");}	
    }

    private void CheckForBug (float belowStage)
    {
    	if(this.transform.position.y < belowStage){SceneChange("GameOver");}
    }
}
