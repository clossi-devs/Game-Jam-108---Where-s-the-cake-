using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is to manage the main camera in relation
/// to the player object.
/// </summary>
public class Clos_PlayerCamera : MonoBehaviour
{
    private GameObject cam;
    private Vector3 offSet;

    [Header("Public Objects")]
    public GameObject lookAt;

    [Header("Offset Position Settings")]
    public float offSetX = 0.0f;
    public float offSetY = 1.0f;
    public float offSetZ = 0.0f;

    [Header("Rotation")]
    public float rotX = 0.0f;
    public float rotY = 0.0f;
    public float rotZ = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        cam = this.gameObject;
        MoveCamera();
    }

    // *********************************
    // ** Camera Position Management
    // *********************************
    
    /// <summary>
    /// Moves the camera to an offset position
    /// relative to the player gameobject's position.
    /// </summary>
    private void MoveCamera ()
    {
        SetOffSet();
        SetCameraPos();
        SetCameraRotation();
    }

    private void SetOffSet()
    {
        offSet = new Vector3(offSetX, offSetY, offSetZ);
    }

    private void SetCameraPos ()
    {
        cam.transform.localPosition = lookAt.transform.position + offSet;
    }

    private void SetCameraRotation ()
    {
        cam.transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
    }
}
