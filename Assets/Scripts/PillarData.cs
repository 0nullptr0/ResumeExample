using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarData : MonoBehaviour
{
    [SerializeField] private Transform activator;
    [SerializeField] private Transform mainCamera;
    bool activated = false;

    void Update(){
        activated = activator.gameObject.GetComponent<ClusterParameters>().pillarActivated;
        if(mainCamera.gameObject.GetComponent<CameraRayCast>().clickedAway){
            activated = false;
            activator.gameObject.GetComponent<ClusterParameters>().clicked = false;
            activator.gameObject.GetComponent<ClusterParameters>().pillarActivated = false;
        }
        if(activated){
            gameObject.transform.position = Vector3.Lerp(
            gameObject.transform.position,
            new Vector3(gameObject.transform.position.x, -0.1f,
            gameObject.transform.position.z), 2f*Time.deltaTime);
        }else{
            gameObject.transform.position = Vector3.Lerp(
            gameObject.transform.position,
            new Vector3(gameObject.transform.position.x, -3.5f,
            gameObject.transform.position.z), 2f*Time.deltaTime);
        }
    }
}
