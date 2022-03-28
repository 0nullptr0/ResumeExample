using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
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
        Debug.Log("Found you !");
        if(GameObject.FindWithTag("MainCamera").GetComponent<FreeCameraMovement>().menuLookAtSettings){
            GameObject.FindWithTag("MainCamera").GetComponent<FreeCameraMovement>().menuCameraMode = false;
            GameObject.FindWithTag("MainCamera").transform.position = Vector3.Lerp(transform.position, new Vector3(-2f,1f,3f), Time.deltaTime*1f);
            GameObject.FindWithTag("MainCamera").GetComponent<FreeCameraMovement>().menuCameraMode = false;
        }
    }

    public void ExitTheGame(){
        //Exit the game
        Application.Quit();
    }
}
