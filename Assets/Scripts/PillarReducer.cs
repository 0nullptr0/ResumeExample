using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarReducer : MonoBehaviour
{
    public float size = 10f;
    Transform[] pillars;

    void Start(){
        GameObject[] pillarsObj = GameObject.FindGameObjectsWithTag("MusicPillar");
        pillars = new Transform[pillarsObj.Length];
        for(int i = 0; i<pillarsObj.Length; i++){
            pillars[i] = pillarsObj[i].transform;
        }
    }

    void Update(){
        Inspect();
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, size);
    }

    public void Inspect(){
        foreach (Transform pillar in pillars){
            if(Vector3.Distance(transform.position, pillar.position) < size && pillar.transform.localScale.y > 1.3f){
                pillar.transform.localScale = Vector3.Lerp(pillar.transform.localScale, new Vector3(4f,Random.Range(1f, 1.2f),4f), Time.deltaTime*5f);
            }
        }
    }
}
