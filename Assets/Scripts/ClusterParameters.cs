using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClusterParameters : MonoBehaviour
{
    public bool pointed = false;
    public bool clicked = false;
    public bool activatable = true;
    public bool corrupted = false;
    public bool pillarActivation = false;
    public bool dataActivation = false;
    public bool pillarActivated = false;

    [SerializeField] public string textForData1;
    [SerializeField] public string textForData2;
    [SerializeField] public string textForData3;
    [SerializeField] public string textForDataTitle;
    [SerializeField] public Texture imageData1;
    [SerializeField] public Texture imageData2;
    
    [SerializeField] private string bubbleText;
    [SerializeField] private string pillarInfo;
    [SerializeField] private Transform selectionSprite;
    [SerializeField] private Transform anchorForBubble;
    [SerializeField] private Transform anchorForPillarBubble;
    [SerializeField] private TextMesh textMesh;
    [SerializeField] private TextMesh pillarTextMesh;
    GameObject mainCamera;

    void Start(){
        textMesh.text = bubbleText;
        pillarTextMesh.text = pillarInfo;
        mainCamera = GameObject.FindWithTag("MainCamera");
        if(corrupted){
                Renderer clusterRend = gameObject.GetComponent<Renderer>();
                clusterRend.material.SetColor("_Color", new Color(0.5f,0.5f,0.5f,1f));
            }
    }

    void Update(){
        if(pointed){
            whenPointed();
            if(pillarActivation && clicked && !corrupted){
                pillarActivated = true;
                Renderer clusterRend = gameObject.GetComponent<Renderer>();
                clusterRend.material.SetColor("_Color", Color.red);
            }
            if(activatable && !pillarActivation && !corrupted){
                showDataBubble();
            }
            if(pillarActivation || corrupted){
                showPillarData();
            }
        }else{
            whenDePointed();
            if(activatable && !pillarActivation && !corrupted){
                hideDataBubble();
            }
            if(pillarActivation || corrupted){
                hidePillarData();
            }
        }
        if(!corrupted){
            if(clicked && activatable && !pillarActivation){
                showData();
            }else{
                hideData();
            }
            if(!mainCamera.GetComponent<CameraRayCast>().panelActive){
                hideData();
            }
        }
        pointed = false;
    }

    void whenPointed(){
        selectionSprite.GetComponent<Renderer>().enabled = true;
    }

    void whenDePointed(){
        selectionSprite.GetComponent<Renderer>().enabled = false;
    }

    void showDataBubble(){
        gameObject.transform.localPosition = Vector3.Lerp(
            gameObject.transform.localPosition,
            new Vector3(0f,gameObject.transform.localPosition.y,
            -0.5f), 2f*Time.deltaTime);
        anchorForBubble.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
        textMesh.GetComponent<Renderer>().enabled = true;
        anchorForBubble.transform.localScale = Vector3.Lerp(
            anchorForBubble.transform.localScale,
            new Vector3(1f,2f,1f), 3f*Time.deltaTime);
    }

    void hideDataBubble(){
        gameObject.transform.localPosition = Vector3.Lerp(
            gameObject.transform.localPosition,
            new Vector3(0f,gameObject.transform.localPosition.y,
            0f), 2f*Time.deltaTime);
        anchorForBubble.transform.localScale = Vector3.Lerp(
            anchorForBubble.transform.localScale,
            new Vector3(0f,2f,1f), 3f*Time.deltaTime);
        textMesh.GetComponent<Renderer>().enabled = false;
        anchorForBubble.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
    }

    void showPillarData(){
        anchorForPillarBubble.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
        pillarTextMesh.GetComponent<Renderer>().enabled = true;
        anchorForPillarBubble.transform.localScale = Vector3.Lerp(
            anchorForPillarBubble.transform.localScale,
            new Vector3(1f,1f,1f), 3f*Time.deltaTime);
    }

    void hidePillarData(){
        anchorForPillarBubble.transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
        pillarTextMesh.GetComponent<Renderer>().enabled = false;
        anchorForPillarBubble.transform.localScale = Vector3.Lerp(
            anchorForPillarBubble.transform.localScale,
            new Vector3(1f,0f,1f), 3f*Time.deltaTime);
    }

    void showData(){
        Renderer clusterRend = gameObject.GetComponent<Renderer>();
        clusterRend.material.SetColor("_Color", Color.red);
        clicked = true;
    }

    void hideData(){
        Renderer clusterRend = gameObject.GetComponent<Renderer>();
        clusterRend.material.SetColor("_Color", Color.white);
        clicked = false;
    }
}