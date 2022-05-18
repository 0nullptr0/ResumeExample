using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCast : MonoBehaviour
{
    ClusterParameters param;
    public bool clickedAway;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.CompareTag("Cluster")){
                clickedAway = false;
                param = hit.transform.gameObject.GetComponent<ClusterParameters>();
                param.pointed = true;
                if(Input.GetMouseButtonDown(0)){
                    if(param.clicked){
                        param.clicked = false;
                    }else{
                        param.clicked = true;
                    }
                }
            }else{
                if(Input.GetMouseButtonDown(0)){
                    clickedAway = true;
                }
            }
            Debug.Log("Hit Something lol");
            Debug.Log("this: "+hit.transform.name);
        } 
        else 
        {
            if(Input.GetMouseButtonDown(0)){
                    clickedAway = true;
            }
            Debug.Log("Nothing hit");
        }
    }
}
