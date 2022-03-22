using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator2 : MonoBehaviour
{
    public GameObject[] prefab_list;
    public float[] probability_list;

    void Start()
    {
        int new_start_x = 0;
        int new_start_z = 0;
        int new_end_x = 0;
        int new_end_z = 0;
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
                //
                //Generating new start and end positions based on rotation
                //
                if(MapVariables.global_direction == 0){
                    new_start_x = prefab_list[check_it].GetComponent<BlockData>().x_start;
                    new_start_z = prefab_list[check_it].GetComponent<BlockData>().z_start;
                    new_end_x = prefab_list[check_it].GetComponent<BlockData>().x_end;
                    new_end_z = prefab_list[check_it].GetComponent<BlockData>().z_end;
                }else if(MapVariables.global_direction == 1){
                    new_start_x = prefab_list[check_it].GetComponent<BlockData>().z_start;
                    new_start_z = -prefab_list[check_it].GetComponent<BlockData>().x_start;
                    new_end_x = prefab_list[check_it].GetComponent<BlockData>().z_end;
                    new_end_z = -prefab_list[check_it].GetComponent<BlockData>().x_end;
                }else if(MapVariables.global_direction == 2){
                    new_start_x = -prefab_list[check_it].GetComponent<BlockData>().x_start;
                    new_start_z = -prefab_list[check_it].GetComponent<BlockData>().z_start;
                    new_end_x = -prefab_list[check_it].GetComponent<BlockData>().x_end;
                    new_end_z = -prefab_list[check_it].GetComponent<BlockData>().z_end;
                }else if(MapVariables.global_direction == 3){
                    new_start_x = -prefab_list[check_it].GetComponent<BlockData>().z_start;
                    new_start_z = prefab_list[check_it].GetComponent<BlockData>().x_start;
                    new_end_x = -prefab_list[check_it].GetComponent<BlockData>().z_end;
                    new_end_z = prefab_list[check_it].GetComponent<BlockData>().x_end;
                }
                //
                //Check possible instances of prefabs that can fit criteria
                //
                int[] can_be_placed = new int[prefab_list.Length];
                int[] direction_can_be_placed = new int[prefab_list.Length*4];
                for(int i = 0; i<prefab_list.Length; i++){
                    for(int j = 0; j<4; j++){

                    }
                }
                //
                //If chosen, instatiate prefab and generate bklocked area with it
                //

                Instantiate(prefab_list[check_it], 
                new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                Quaternion.Euler(0f,0f,0f));

                Debug.Log(GetComponent<BlockData>().x_start);
                Debug.Log(GetComponent<BlockData>().z_start);
                Debug.Log(GetComponent<BlockData>().x_end);
                Debug.Log(GetComponent<BlockData>().z_end);
            }
        }
    }
}
