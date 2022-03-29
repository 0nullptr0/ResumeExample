using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLight : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public Vector3 temporary;

    private float timeCounter = 0f;

    void OnAwake(){
        temporary = endPoint.position;
    }

    void Update()
    {
        timeCounter += Time.deltaTime;
        float x = Mathf.Cos(timeCounter)/4;
        float z = Mathf.Sin(timeCounter)/4;
        //float y = Mathf.Sin(timeCounter);
        transform.position += new Vector3(x, 0f, z);
        //Change centre position for menu
        transform.position = Vector3.Lerp(transform.position, temporary, 3f*Time.deltaTime); 
    }
}
