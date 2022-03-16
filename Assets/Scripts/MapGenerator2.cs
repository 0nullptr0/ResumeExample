using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator2 : MonoBehaviour
{
    public GameObject[] prefab_list;
    public float[] probability_list;

    void Start()
    {
        //Debug.Log("X: "+(gameObject.transform.position.x)/3+", Z: "+(gameObject.transform.position.z)/3);
        int check_it;
        float[] probability_list = new float[prefab_list.Length];
        for(int i = 0; i<prefab_list.Length; i++){
            probability_list[i] = 100f;
        }
        //Debug.Log("First List member: "+probability_list[0]);
        //Debug.Log("Last List member: "+probability_list[prefab_list.Length-1]);
        bool[] passed = new bool[prefab_list.Length];
        for(int i = 0; i<prefab_list.Length; i++){
            if(probability_list[i]>Random.Range(0, 100)) passed[i] = true;
            else passed[i] = false;
        }
        check_it = Random.Range(0,prefab_list.Length);
        if(passed[check_it]){
            if(MapVariables.length_of_the_map>0){
                MapVariables.length_of_the_map--;
                //Rotate prefab till the end of the first and start of the second match
                

                Debug.Log(GetComponent<BlockData>().x_start);
                Debug.Log(GetComponent<BlockData>().z_start);
                Debug.Log(GetComponent<BlockData>().x_end);
                Debug.Log(GetComponent<BlockData>().z_end);
            }
        }
    }
}
