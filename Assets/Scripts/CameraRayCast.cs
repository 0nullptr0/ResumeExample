using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraRayCast : MonoBehaviour
{
    ClusterParameters param;
    public bool clickedAway;
    public bool panelActive;
    public bool webGlVersion = false;

    [SerializeField] private GameObject canvas;
    public Text textForData1;
    public Text textForData2;
    public Text textForData3;
    public Text textForDataTitle;
    public RawImage imageData1;
    public RawImage imageData2;

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
                        if(param.dataActivation){
                            imageData1.texture = param.imageData1;
                            imageData2.texture = param.imageData2;
                            textForData1.text = param.textForData1;
                            textForData2.text = param.textForData2;
                            textForData3.text = param.textForData3;
                            textForDataTitle.text = param.textForDataTitle;
                            panelActive = true;
                        }
                    }
                }
            }else{
                if(Input.GetMouseButtonDown(0) && !panelActive){
                    clickedAway = true;
                }
            }
        } 
        else 
        {
            if(Input.GetMouseButtonDown(0) && !panelActive){
                    clickedAway = true;
            }
        }
        if(panelActive){
            canvas.SetActive(true);
        }else{
            canvas.SetActive(false);
        }
    }

    public void setPanelInactive(){
        panelActive = false;
    }
}
