using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataForBackup
{
    public float speed = 1f;
    public float volume = 1f;

    public float masterVolumeP = 1f;
    public float musicVolumeP = 1f;
    public float effectsVolumeP = 1f;

    public int graphicsLevel = 0;

    public DataForBackup(WorldVariables vars){
        speed = vars.speed;
        volume = vars.volume;
        masterVolumeP = vars.masterVolumeP;
        musicVolumeP = vars.musicVolumeP;
        effectsVolumeP = vars.effectsVolumeP;
        graphicsLevel = vars.graphicsLevel;
    }
}
