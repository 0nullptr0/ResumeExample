using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFrequency : MonoBehaviour
{
    public AudioSource audioSource;

    int qSamples = 1024;
    float speed = 1f;
    float refValue = 0.1f;
    float rmsValue;
    float dbValue;
    float volume = 2;

    float previousVolume;
 
    private float[] samples;
    
    private void Start(){
        samples = new float[qSamples];
        string holderName = "MainCamera";
        string eventHolder = "EventHolder";
        if(audioSource==null){
            if(GameObject.Find(holderName)){
                audioSource = GameObject.Find(holderName).GetComponent<AudioSource>();
            }
        }
        if(GameObject.Find(eventHolder)){
            speed = GameObject.Find(eventHolder).GetComponent<ChangeWorldVariables>().speed;
            volume = GameObject.Find(eventHolder).GetComponent<ChangeWorldVariables>().volume;
        }
    }

    private void  Update () {
        GetVolume();
        if((volume*rmsValue+1)>transform.localScale.y){
            Vector3 newSize = new Vector3(4f,((volume*rmsValue)*Random.Range(1f,1.5f)*Random.Range(1f,1.5f)+1f),4f);
            transform.localScale = newSize;
        }else{
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(4f,1f,4f), Time.deltaTime*speed);
        }
    }

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
