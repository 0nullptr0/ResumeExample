using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public static void SaveWorldVariables(WorldVariables vars){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath+"/worldData.FreqDat";
        FileStream stream = new FileStream(path, FileMode.Create);
        DataForBackup data = new DataForBackup(vars);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static DataForBackup LoadWorldVariables(){
        string path = Application.persistentDataPath+"/worldData.FreqDat";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            DataForBackup data = formatter.Deserialize(stream) as DataForBackup;
            GameObject worldVars = GameObject.Find("EventHolder");
            worldVars.GetComponent<WorldVariables>().speed = data.speed;
            worldVars.GetComponent<WorldVariables>().volume = data.volume;
            worldVars.GetComponent<WorldVariables>().masterVolumeP = data.masterVolumeP;
            worldVars.GetComponent<WorldVariables>().musicVolumeP = data.musicVolumeP;
            worldVars.GetComponent<WorldVariables>().effectsVolumeP = data.effectsVolumeP;
            worldVars.GetComponent<WorldVariables>().graphicsLevel = data.graphicsLevel;
            stream.Close();
            return data;
        }else{
            Debug.LogError("Save file not found in "+path);
            return null;
        }
    }
}
