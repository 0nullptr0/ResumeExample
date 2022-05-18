using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFrequency : MonoBehaviour
{
    public AudioSource audioSource;
    public bool webGlVersion = false;

    int qSamples = 1024;
    //Speed at which musicPillars move and collapse
    float speed = 1f;
    //Stepping at which the clip samples are being taken
    float refValue = 0.1f;
    float rmsValue;
    float dbValue;
    //Maximum average height of musicPillars in runtime
    float volume = 2;

    float previousVolume;
 
    private float[] samples;
    
    //Take song clip from MainCamera object listener and take worldVariables from eventHolder object if it exists
    private void Start(){
        samples = new float[qSamples];
        string holderName = "MainCamera";
        string eventHolder = "EventHolder";
        if(audioSource==null){
            if(GameObject.Find(holderName)){
                audioSource = GameObject.Find(holderName).GetComponent<AudioSource>();
                webGlVersion = GameObject.Find(holderName).GetComponent<CameraRayCast>().webGlVersion;
            }
        }
        if(GameObject.Find(eventHolder)){
            speed = GameObject.Find(eventHolder).GetComponent<WorldVariables>().speed;
            volume = GameObject.Find(eventHolder).GetComponent<WorldVariables>().volume;
        }
    }

    //Generate the height variable for the musicPillar based on clip volume and rmsValue
    private void  Update () {
        GetVolume();
        if(webGlVersion){
            rmsValue = Random.Range(0.2f,0.8f);
        }
        if((volume*rmsValue+1)>transform.localScale.y){
            Vector3 newSize = new Vector3(4f,((volume*rmsValue)*Random.Range(1f,1.5f)*Random.Range(1f,1.5f)+1f),4f);
            transform.localScale = newSize;
        }else{
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(4f,1f,4f), Time.deltaTime*speed);
        }
    }

    //Get volume data from the clip
    private void GetVolume(){
        audioSource.GetOutputData(samples, 0);
        int i;
        float sum= 0;
        for (i=0; i < qSamples; i++){
            sum += samples[i]*samples[i];
        }
        rmsValue = Mathf.Sqrt(sum/qSamples);
        dbValue = 20*Mathf.Log10(rmsValue/refValue);
        if (dbValue < -160){
            dbValue = -160;
        }
    }
}
