using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraMovement : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float fastMovementSpeed = 100f;
    public float freeLookSensitivity = 3f;
    public float zoomSensitivity = 10f;
    public float fastZoomSensitivity = 50f;
    //Camera circullar movement if true, otherwise normal movement mode
    public bool menuCameraMode = true;
    //While true makes camera look at settings, while false makes camera look at the menu
    public bool menuLookAtSettings = false;
    private bool fastMode = false;
    public Vector3 centreNow;
    public Vector3 centreAtStart;
    //timeCounter to make smooth movement based on realTime
    private float timeCounter = 0f;

    void Start(){
        //Save camera start position to get the anchor point for circullar movement
        if(menuCameraMode){
            centreAtStart = transform.position;
            centreNow = transform.position;
        }
    }

    void Update(){
        if(menuCameraMode){
            //Generate circullar movement of the MainCamera
            //Debug.Log("X:"+transform.position.x+" Z:"+transform.position.z);
            timeCounter += Time.deltaTime;
            float x = Mathf.Cos(timeCounter)/600f;
            float z = Mathf.Sin(timeCounter)/600f;
            float y = Mathf.Sin(timeCounter)/1000f;
            transform.position += new Vector3(x*4, y*2, z*2);
            //Change centre position for menu
            transform.position = Vector3.Lerp(transform.position, centreNow, 3f*Time.deltaTime);
        }else{
            //MainCamera movement and control system
            if(Input.GetKey(KeyCode.Alpha1)){
                fastMode = false;
            }
            if(Input.GetKey(KeyCode.Alpha2)){
                fastMode = true;
            }
            var movementSpeed = fastMode ? this.fastMovementSpeed : this.movementSpeed;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
                transform.position = transform.position + (-transform.right * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
                transform.position = transform.position + (transform.right * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
                transform.position = transform.position + (transform.forward * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
                transform.position = transform.position + (-transform.forward * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Q)){
                transform.position = transform.position + (transform.up * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.E)){
                transform.position = transform.position + (-transform.up * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.PageUp) || Input.GetKey(KeyCode.Space)){
                transform.position = transform.position + (Vector3.up * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.PageDown) || Input.GetKey(KeyCode.LeftShift)){
                transform.position = transform.position + (-Vector3.up * movementSpeed * Time.deltaTime);
            }
                float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSensitivity;
                float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * freeLookSensitivity;
                if(newRotationY > 86f && newRotationY < 90f){
                    newRotationY = 86f;
                }
                if(newRotationY < 274f && newRotationY > 270f){
                    newRotationY = 274f;
                }
                transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
            float axis = Input.GetAxis("Mouse ScrollWheel");
            if (axis != 0){
                var zoomSensitivity = fastMode ? this.fastZoomSensitivity : this.zoomSensitivity;
                transform.position = transform.position + transform.forward * axis * zoomSensitivity;
            }
            CursorLock();
        }
    }

    public void CursorLock()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
