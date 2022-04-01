using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldVariables : MonoBehaviour
{
    public AudioMixer mainMixer;
    //Pillar variables
    //Speed at which musicPillars move and collapse
    public float speed = 1f;
    //Maximum average height of musicPillars in runtime
    public float volume = 1f;

    //Settings variables
    public float masterVolumeP = 1f;
    public float musicVolumeP = 1f;
    public float effectsVolumeP = 1f;

    public int graphicsLevel = 0;

    //Player variables (in the future)

    //At the beggining take data from binary file and set settings
    void Start(){
        SaveSystem.LoadWorldVariables();
        QualitySettings.SetQualityLevel(graphicsLevel);
        mainMixer.SetFloat("masterVolume", masterVolumeP);
        mainMixer.SetFloat("musicVolume", musicVolumeP);
        mainMixer.SetFloat("effectsVolume", effectsVolumeP);
        if(SceneManager.GetActiveScene().name == "Menu"){
            GameObject.Find("masterVolumeSlider").GetComponent<Slider>().value = masterVolumeP;
            GameObject.Find("musicVolumeSlider").GetComponent<Slider>().value = musicVolumeP;
            GameObject.Find("effectsVolumeSlider").GetComponent<Slider>().value = effectsVolumeP;
        }
    }

    //Backup data into binary file
    void OnDestroy(){
        SaveSystem.SaveWorldVariables(this);
    }
}
