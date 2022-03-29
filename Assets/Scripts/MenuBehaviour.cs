using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject newGameCanvas;
    public GameObject settingsCanvas;

    void Start(){
        menuCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
        newGameCanvas.SetActive(false);
    }

    public void LoadExistingGame(string sceneName){
        //Take data from file and start from the scene
        SceneManager.LoadScene(sceneName);
    }

    public void StartNewGame(string sceneName){
        //Reset all data and start new game
        SceneManager.LoadScene(sceneName);
    }

    public void OpenMainMenuSettings(){
        //Camera animation zoom at settings
        GameObject cameraMain;
        GameObject canvas;
        if(GameObject.FindWithTag("MainCamera")){
            cameraMain = GameObject.FindWithTag("MainCamera");
            cameraMain.GetComponent<FreeCameraMovement>().centreNow = 
            new Vector3(cameraMain.transform.position.x+3f, 
            cameraMain.transform.position.y, 
            cameraMain.transform.position.z-3f);
        }
        menuCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    public void BackToMainMenu(){
        //Camera animation zoom at menu
        GameObject cameraMain;
        if(GameObject.FindWithTag("MainCamera")){
            cameraMain = GameObject.FindWithTag("MainCamera");
            cameraMain.GetComponent<FreeCameraMovement>().centreNow = 
            new Vector3(cameraMain.transform.position.x-3f, 
            cameraMain.transform.position.y, 
            cameraMain.transform.position.z+3f);
        }
        menuCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
    }

    public void NewGameClicked(bool a){
        if(a){
            menuCanvas.SetActive(false);
            newGameCanvas.SetActive(true);
        }else{
            menuCanvas.SetActive(true);
            newGameCanvas.SetActive(false);
        }
    }

    public void ExitTheGame(){
        //Exit the game
        Application.Quit();
    }
}
