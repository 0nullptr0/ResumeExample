using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] prefab_list;
    public float[] probability_list;

    void Start()
    {   
        Debug.Log("X: "+(gameObject.transform.position.x-75)/3+", Z: "+(gameObject.transform.position.z-75)/3);
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
        //Debug.Log("First List member: "+passed[0]);
        //Debug.Log("Last List member: "+passed[prefab_list.Length-1]);
        //while(true){
            check_it = Random.Range(0, 2);
            if(passed[check_it]){
                if(MapVariables.length_of_the_map>0){
                    MapVariables.length_of_the_map--;
                    //while(true){
                        //direction_ = Random.Range(0,3);
                        //Instantiate (prefab, transform.position, transform.rotation * Quaternion.Euler (0f, 180f, 0f));
                        if(gameObject.tag == "Forward"){
                            if(MapVariables.global_rotation>-1 && MapVariables.global_rotation<1 || 
                            MapVariables.global_rotation>179 && MapVariables.global_rotation<181){
                                /*
                                # ^ #   &   #   #
                                #   #   &   #   #
                                #   #   &   # V #
                                */
                                /*MapVariables.MaObLib[MapVariables.x,MapVariables.z-1] = true;
                                MapVariables.MaObLib[MapVariables.x,MapVariables.z+1] = true;*/
                                if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z]){
                                    if(prefab_list[check_it].tag == "Left"){
                                        if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z+1] && 
                                        !MapVariables.MaObLib[MapVariables.x+1,MapVariables.z-1]){
                                            if(Random.Range(0,2)==0){
                                                MapVariables.global_rotation = 270f;
                                            }else{
                                                MapVariables.global_rotation = 180f;
                                            }
                                        }else if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z+1]){
                                            MapVariables.global_rotation = 270f;
                                        }else if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z-1]){
                                            MapVariables.global_rotation = 180f;
                                        }else{
                                            MapVariables.global_rotation = 0f;
                                            check_it = 0;
                                        }
                                    }
                                    if(prefab_list[check_it].tag == "Forward"){
                                            MapVariables.global_rotation = 0f;
                                    }
                                    MapVariables.x++;
                                    MapVariables.MaObLi[MapVariables.x,MapVariables.z] = Instantiate(prefab_list[check_it], 
                                    new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                                    Quaternion.Euler(0f,MapVariables.global_rotation,0f));
                                    //Debug.Log("Instantiated "+(check_it+1)+" object on the list");
                                    MapVariables.MaObLib[MapVariables.x,MapVariables.z] = true;
                                    //break;
                                }else if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z]){
                                    if(prefab_list[check_it].tag == "Left"){
                                        if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z+1] && 
                                        !MapVariables.MaObLib[MapVariables.x-1,MapVariables.z-1]){
                                            if(Random.Range(0,2)==0){
                                                MapVariables.global_rotation = 0f;
                                            }else{
                                                MapVariables.global_rotation = 90f;
                                            }
                                        }else if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z+1]){
                                            MapVariables.global_rotation = 0f;
                                        }else if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z-1]){
                                            MapVariables.global_rotation = 90f;
                                        }else{
                                            MapVariables.global_rotation = 180f;
                                            check_it = 0;
                                        }
                                    }
                                    if(prefab_list[check_it].tag == "Forward"){
                                            MapVariables.global_rotation = 180f;
                                    }
                                    MapVariables.x--;
                                    MapVariables.MaObLi[MapVariables.x,MapVariables.z] = Instantiate(prefab_list[check_it], 
                                    new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                                    Quaternion.Euler(0f,MapVariables.global_rotation,0f));
                                    //Debug.Log("Instantiated "+(check_it+1)+" object on the list");
                                    MapVariables.MaObLib[MapVariables.x,MapVariables.z] = true;
                                    //break;
                                }else{
                                    //break;
                                }
                            }
                            if(MapVariables.global_rotation>89 && MapVariables.global_rotation<91 || 
                            MapVariables.global_rotation>269 && MapVariables.global_rotation<271){
                                /*
                                # # #   &   # # #
                                    >   &   <
                                # # #   &   # # #
                                */
                                /*MapVariables.MaObLib[MapVariables.x+1,MapVariables.z] = true;
                                MapVariables.MaObLib[MapVariables.x-1,MapVariables.z] = true;*/
                                if(!MapVariables.MaObLib[MapVariables.x,MapVariables.z+1]){
                                    if(prefab_list[check_it].tag == "Left"){
                                        if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z+1] && 
                                        !MapVariables.MaObLib[MapVariables.x-1,MapVariables.z+1]){
                                            if(Random.Range(0,2)==0){
                                                MapVariables.global_rotation = 90f;
                                            }else{
                                                MapVariables.global_rotation = 180f;
                                            }
                                        }else if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z+1]){
                                            MapVariables.global_rotation = 90f;
                                        }else if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z+1]){
                                            MapVariables.global_rotation = 180f;
                                        }else{
                                            MapVariables.global_rotation = 90f;
                                            check_it = 0;
                                        }
                                    }
                                    if(prefab_list[check_it].tag == "Forward"){
                                            MapVariables.global_rotation = 90f;
                                    }
                                    MapVariables.z++;
                                    MapVariables.MaObLi[MapVariables.x,MapVariables.z] = Instantiate(prefab_list[check_it], 
                                    new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                                    Quaternion.Euler(0f,MapVariables.global_rotation,0f));
                                    //Debug.Log("Instantiated "+(check_it+1)+" object on the list");
                                    MapVariables.MaObLib[MapVariables.x,MapVariables.z] = true;
                                    //break;
                                }else if(!MapVariables.MaObLib[MapVariables.x,MapVariables.z-1]){
                                    if(prefab_list[check_it].tag == "Left"){
                                        if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z-1] && 
                                        !MapVariables.MaObLib[MapVariables.x-1,MapVariables.z-1]){
                                            if(Random.Range(0,2)==0){
                                                MapVariables.global_rotation = 0f;
                                            }else{
                                                MapVariables.global_rotation = 270f;
                                            }
                                        }else if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z-1]){
                                            MapVariables.global_rotation = 0f;
                                        }else if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z-1]){
                                            MapVariables.global_rotation = 270f;
                                        }else{
                                            MapVariables.global_rotation = 270f;
                                            check_it = 0;
                                        }
                                    }
                                    if(prefab_list[check_it].tag == "Forward"){
                                            MapVariables.global_rotation = 270f;
                                    }
                                    MapVariables.z--;
                                    MapVariables.MaObLi[MapVariables.x,MapVariables.z] = Instantiate(prefab_list[check_it], 
                                    new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                                    Quaternion.Euler(0f,MapVariables.global_rotation,0f));
                                    //Debug.Log("Instantiated "+(check_it+1)+" object on the list");
                                    MapVariables.MaObLib[MapVariables.x,MapVariables.z] = true;
                                    //break;
                                }else{
                                    //break;
                                }
                            }
                        }
                        if(gameObject.tag == "Left"){
                            if(MapVariables.global_rotation>-1 && MapVariables.global_rotation<1){
                                /*
                                # ^ #
                                    #
                                # # #
                                */
                                /*MapVariables.MaObLib[MapVariables.x+1,MapVariables.z+1] = true;
                                MapVariables.MaObLib[MapVariables.x+1,MapVariables.z-1] = true;
                                MapVariables.MaObLib[MapVariables.x,MapVariables.z-1] = true;
                                MapVariables.MaObLib[MapVariables.x-1,MapVariables.z-1] = true;
                                MapVariables.MaObLib[MapVariables.x-1,MapVariables.z] = true;
                                MapVariables.MaObLib[MapVariables.x-1,MapVariables.z+1] = true;*/
                                if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z]){
                                    if(prefab_list[check_it].tag == "Left"){
                                        if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z+1] && 
                                        !MapVariables.MaObLib[MapVariables.x+1,MapVariables.z-1]){
                                            if(Random.Range(0,2)==0){
                                                MapVariables.global_rotation = 270f;
                                            }else{
                                                MapVariables.global_rotation = 180f;
                                            }
                                        }else if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z+1]){
                                            MapVariables.global_rotation = 270f;
                                        }else if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z-1]){
                                            MapVariables.global_rotation = 180f;
                                        }else{
                                            MapVariables.global_rotation = 0f;
                                            check_it = 0;
                                        }
                                    }
                                    if(prefab_list[check_it].tag == "Forward"){
                                            MapVariables.global_rotation = 0f;
                                    }
                                    MapVariables.x++;
                                    MapVariables.MaObLi[MapVariables.x,MapVariables.z] = Instantiate(prefab_list[check_it], 
                                    new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                                    Quaternion.Euler(0f,MapVariables.global_rotation,0f));
                                    //Debug.Log("Instantiated "+(check_it+1)+" object on the list");
                                    MapVariables.MaObLib[MapVariables.x,MapVariables.z] = true;
                                    //break;
                                }else if(!MapVariables.MaObLib[MapVariables.x,MapVariables.z+1]){
                                    if(prefab_list[check_it].tag == "Left"){
                                        if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z+1] && 
                                        !MapVariables.MaObLib[MapVariables.x-1,MapVariables.z+1]){
                                            if(Random.Range(0,2)==0){
                                                MapVariables.global_rotation = 90f;
                                            }else{
                                                MapVariables.global_rotation = 180f;
                                            }
                                        }else if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z+1]){
                                            MapVariables.global_rotation = 90f;
                                        }else if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z+1]){
                                            MapVariables.global_rotation = 180f;
                                        }else{
                                            MapVariables.global_rotation = 270f;
                                            check_it = 0;
                                        }
                                    }
                                    if(prefab_list[check_it].tag == "Forward"){
                                            MapVariables.global_rotation = 270f;
                                    }
                                    MapVariables.z++;
                                    MapVariables.MaObLi[MapVariables.x,MapVariables.z] = Instantiate(prefab_list[check_it], 
                                    new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                                    Quaternion.Euler(0f,MapVariables.global_rotation,0f));
                                    //Debug.Log("Instantiated "+(check_it+1)+" object on the list");
                                    MapVariables.MaObLib[MapVariables.x,MapVariables.z] = true;
                                    //break;
                                }else{
                                    //break;
                                }
                            }
                            if(MapVariables.global_rotation>89 && MapVariables.global_rotation<91){
                                /*
                                #   #
                                #   >
                                # # #
                                */
                                /*MapVariables.MaObLib[MapVariables.x+1,MapVariables.z+1] = true;
                                MapVariables.MaObLib[MapVariables.x+1,MapVariables.z-1] = true;
                                MapVariables.MaObLib[MapVariables.x,MapVariables.z+1] = true;
                                MapVariables.MaObLib[MapVariables.x-1,MapVariables.z-1] = true;
                                MapVariables.MaObLib[MapVariables.x-1,MapVariables.z] = true;
                                MapVariables.MaObLib[MapVariables.x-1,MapVariables.z+1] = true;*/
                                if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z]){
                                    if(prefab_list[check_it].tag == "Left"){
                                        if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z+1] && 
                                        !MapVariables.MaObLib[MapVariables.x+1,MapVariables.z-1]){
                                            if(Random.Range(0,2)==0){
                                                MapVariables.global_rotation = 270f;
                                            }else{
                                                MapVariables.global_rotation = 180f;
                                            }
                                        }else if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z+1]){
                                            MapVariables.global_rotation = 270f;
                                        }else if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z-1]){
                                            MapVariables.global_rotation = 180f;
                                        }else{
                                            MapVariables.global_rotation = 0f;
                                            check_it = 0;
                                        }
                                    }
                                    if(prefab_list[check_it].tag == "Forward"){
                                            MapVariables.global_rotation = 0f;
                                    }
                                    MapVariables.x++;
                                    MapVariables.MaObLi[MapVariables.x,MapVariables.z] = Instantiate(prefab_list[check_it], 
                                    new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                                    Quaternion.Euler(0f,MapVariables.global_rotation,0f));
                                    //Debug.Log("Instantiated "+(check_it+1)+" object on the list");
                                    MapVariables.MaObLib[MapVariables.x,MapVariables.z] = true;
                                    //break;
                                }else if(!MapVariables.MaObLib[MapVariables.x,MapVariables.z-1]){
                                    if(prefab_list[check_it].tag == "Left"){
                                        if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z-1] && 
                                        !MapVariables.MaObLib[MapVariables.x-1,MapVariables.z-1]){
                                            if(Random.Range(0,2)==0){
                                                MapVariables.global_rotation = 0f;
                                            }else{
                                                MapVariables.global_rotation = 270f;
                                            }
                                        }else if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z-1]){
                                            MapVariables.global_rotation = 0f;
                                        }else if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z-1]){
                                            MapVariables.global_rotation = 270f;
                                        }else{
                                            MapVariables.global_rotation = 90f;
                                            check_it = 0;
                                        }
                                    }
                                    if(prefab_list[check_it].tag == "Forward"){
                                            MapVariables.global_rotation = 90f;
                                    }
                                    MapVariables.z--;
                                    MapVariables.MaObLi[MapVariables.x,MapVariables.z] = Instantiate(prefab_list[check_it], 
                                    new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                                    Quaternion.Euler(0f,MapVariables.global_rotation,0f));
                                    //Debug.Log("Instantiated "+(check_it+1)+" object on the list");
                                    MapVariables.MaObLib[MapVariables.x,MapVariables.z] = true;
                                    //break;
                                }else{
                                    //break;
                                }
                            }
                            if(MapVariables.global_rotation>179 && MapVariables.global_rotation<181){
                                /*
                                # # #
                                #   
                                # V #
                                */
                                /*MapVariables.MaObLib[MapVariables.x+1,MapVariables.z+1] = true;
                                MapVariables.MaObLib[MapVariables.x+1,MapVariables.z-1] = true;
                                MapVariables.MaObLib[MapVariables.x,MapVariables.z+1] = true;
                                MapVariables.MaObLib[MapVariables.x-1,MapVariables.z-1] = true;
                                MapVariables.MaObLib[MapVariables.x+1,MapVariables.z] = true;
                                MapVariables.MaObLib[MapVariables.x-1,MapVariables.z+1] = true;*/
                                if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z]){
                                    if(prefab_list[check_it].tag == "Left"){
                                        if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z+1] && 
                                        !MapVariables.MaObLib[MapVariables.x-1,MapVariables.z-1]){
                                            if(Random.Range(0,2)==0){
                                                MapVariables.global_rotation = 0f;
                                            }else{
                                                MapVariables.global_rotation = 90f;
                                            }
                                        }else if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z+1]){
                                            MapVariables.global_rotation = 0f;
                                        }else if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z-1]){
                                            MapVariables.global_rotation = 90f;
                                        }else{
                                            MapVariables.global_rotation = 180f;
                                            check_it = 0;
                                        }
                                    }
                                    if(prefab_list[check_it].tag == "Forward"){
                                            MapVariables.global_rotation = 180f;
                                    }
                                    MapVariables.x--;
                                    MapVariables.MaObLi[MapVariables.x,MapVariables.z] = Instantiate(prefab_list[check_it], 
                                    new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                                    Quaternion.Euler(0f,MapVariables.global_rotation,0f));
                                    //Debug.Log("Instantiated "+(check_it+1)+" object on the list");
                                    MapVariables.MaObLib[MapVariables.x,MapVariables.z] = true;
                                    //break;
                                }else if(!MapVariables.MaObLib[MapVariables.x,MapVariables.z-1]){
                                    if(prefab_list[check_it].tag == "Left"){
                                        if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z-1] && 
                                        !MapVariables.MaObLib[MapVariables.x-1,MapVariables.z-1]){
                                            if(Random.Range(0,2)==0){
                                                MapVariables.global_rotation = 0f;
                                            }else{
                                                MapVariables.global_rotation = 270f;
                                            }
                                        }else if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z-1]){
                                            MapVariables.global_rotation = 0f;
                                        }else if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z-1]){
                                            MapVariables.global_rotation = 270f;
                                        }else{
                                            MapVariables.global_rotation = 90f;
                                            check_it = 0;
                                        }
                                    }
                                    if(prefab_list[check_it].tag == "Forward"){
                                            MapVariables.global_rotation = 90f;
                                    }
                                    MapVariables.z--;
                                    MapVariables.MaObLi[MapVariables.x,MapVariables.z] = Instantiate(prefab_list[check_it], 
                                    new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                                    Quaternion.Euler(0f,MapVariables.global_rotation,0f));
                                    //Debug.Log("Instantiated "+(check_it+1)+" object on the list");
                                    MapVariables.MaObLib[MapVariables.x,MapVariables.z] = true;
                                    //break;
                                }else{
                                    //break;
                                }
                            }
                            if(MapVariables.global_rotation>269 && MapVariables.global_rotation<271){
                                /*
                                # # #
                                <   #
                                #   #
                                */
                                /*MapVariables.MaObLib[MapVariables.x+1,MapVariables.z+1] = true;
                                MapVariables.MaObLib[MapVariables.x+1,MapVariables.z-1] = true;
                                MapVariables.MaObLib[MapVariables.x,MapVariables.z-1] = true;
                                MapVariables.MaObLib[MapVariables.x-1,MapVariables.z-1] = true;
                                MapVariables.MaObLib[MapVariables.x+1,MapVariables.z] = true;
                                MapVariables.MaObLib[MapVariables.x-1,MapVariables.z+1] = true;*/
                                if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z]){
                                    if(prefab_list[check_it].tag == "Left"){
                                        if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z+1] && 
                                        !MapVariables.MaObLib[MapVariables.x-1,MapVariables.z-1]){
                                            if(Random.Range(0,2)==0){
                                                MapVariables.global_rotation = 0f;
                                            }else{
                                                MapVariables.global_rotation = 90f;
                                            }
                                        }else if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z+1]){
                                            MapVariables.global_rotation = 0f;
                                        }else if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z-1]){
                                            MapVariables.global_rotation = 90f;
                                        }else{
                                            MapVariables.global_rotation = 180f;
                                            check_it = 0;
                                        }
                                    }
                                    if(prefab_list[check_it].tag == "Forward"){
                                            MapVariables.global_rotation = 180f;
                                    }
                                    MapVariables.x--;
                                    MapVariables.MaObLi[MapVariables.x,MapVariables.z] = Instantiate(prefab_list[check_it], 
                                    new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                                    Quaternion.Euler(0f,MapVariables.global_rotation,0f));
                                    //Debug.Log("Instantiated "+(check_it+1)+" object on the list");
                                    MapVariables.MaObLib[MapVariables.x,MapVariables.z] = true;
                                    //break;
                                }else if(!MapVariables.MaObLib[MapVariables.x,MapVariables.z+1]){
                                    if(prefab_list[check_it].tag == "Left"){
                                        if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z+1] && 
                                        !MapVariables.MaObLib[MapVariables.x-1,MapVariables.z+1]){
                                            if(Random.Range(0,2)==0){
                                                MapVariables.global_rotation = 90f;
                                            }else{
                                                MapVariables.global_rotation = 180f;
                                            }
                                        }else if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z+1]){
                                            MapVariables.global_rotation = 90f;
                                        }else if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z+1]){
                                            MapVariables.global_rotation = 180f;
                                        }else{
                                            MapVariables.global_rotation = 270f;
                                            check_it = 0;
                                        }
                                    }
                                    if(prefab_list[check_it].tag == "Forward"){
                                            MapVariables.global_rotation = 270f;
                                    }
                                    MapVariables.z++;
                                    MapVariables.MaObLi[MapVariables.x,MapVariables.z] = Instantiate(prefab_list[check_it], 
                                    new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                                    Quaternion.Euler(0f,MapVariables.global_rotation,0f));
                                    //Debug.Log("Instantiated "+(check_it+1)+" object on the list");
                                    MapVariables.MaObLib[MapVariables.x,MapVariables.z] = true;
                                    //break;
                                }else{
                                    //break;
                                }
                            }
                        }
                        if(gameObject.tag == "AnyDirection"){
                                if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z]){
                                    if(prefab_list[check_it].tag == "Left"){
                                        if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z+1] && 
                                        !MapVariables.MaObLib[MapVariables.x+1,MapVariables.z-1]){
                                            if(Random.Range(0,2)==0){
                                                MapVariables.global_rotation = 270f;
                                            }else{
                                                MapVariables.global_rotation = 180f;
                                            }
                                        }else if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z+1]){
                                            MapVariables.global_rotation = 270f;
                                        }else if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z-1]){
                                            MapVariables.global_rotation = 180f;
                                        }
                                    }
                                    MapVariables.x++;
                                    MapVariables.MaObLi[MapVariables.x,MapVariables.z] = Instantiate(prefab_list[check_it], 
                                    new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                                    Quaternion.Euler(0f,MapVariables.global_rotation,0f));
                                    //Debug.Log("Instantiated "+(check_it+1)+" object on the list");
                                    MapVariables.MaObLib[MapVariables.x,MapVariables.z] = true;
                                    //break;
                                }else if(!MapVariables.MaObLib[MapVariables.x,MapVariables.z+1]){
                                    if(prefab_list[check_it].tag == "Left"){
                                        if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z+1] && 
                                        !MapVariables.MaObLib[MapVariables.x-1,MapVariables.z+1]){
                                            if(Random.Range(0,2)==0){
                                                MapVariables.global_rotation = 90f;
                                            }else{
                                                MapVariables.global_rotation = 180f;
                                            }
                                        }else if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z+1]){
                                            MapVariables.global_rotation = 90f;
                                        }else if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z+1]){
                                            MapVariables.global_rotation = 180f;
                                        }
                                    }
                                    MapVariables.z++;
                                    MapVariables.MaObLi[MapVariables.x,MapVariables.z] = Instantiate(prefab_list[check_it], 
                                    new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                                    Quaternion.Euler(0f,MapVariables.global_rotation,0f));
                                    //Debug.Log("Instantiated "+(check_it+1)+" object on the list");
                                    MapVariables.MaObLib[MapVariables.x,MapVariables.z] = true;
                                    //break;
                                }else if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z]){
                                    if(prefab_list[check_it].tag == "Left"){
                                        if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z+1] && 
                                        !MapVariables.MaObLib[MapVariables.x-1,MapVariables.z-1]){
                                            if(Random.Range(0,2)==0){
                                                MapVariables.global_rotation = 0f;
                                            }else{
                                                MapVariables.global_rotation = 90f;
                                            }
                                        }else if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z+1]){
                                            MapVariables.global_rotation = 0f;
                                        }else if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z-1]){
                                            MapVariables.global_rotation = 90f;
                                        }
                                    }
                                    MapVariables.x--;
                                    MapVariables.MaObLi[MapVariables.x,MapVariables.z] = Instantiate(prefab_list[check_it], 
                                    new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                                    Quaternion.Euler(0f,MapVariables.global_rotation,0f));
                                    //Debug.Log("Instantiated "+(check_it+1)+" object on the list");
                                    MapVariables.MaObLib[MapVariables.x,MapVariables.z] = true;
                                    //break;
                                }else if(!MapVariables.MaObLib[MapVariables.x,MapVariables.z-1]){
                                    if(prefab_list[check_it].tag == "Left"){
                                        if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z-1] && 
                                        !MapVariables.MaObLib[MapVariables.x-1,MapVariables.z-1]){
                                            if(Random.Range(0,2)==0){
                                                MapVariables.global_rotation = 0f;
                                            }else{
                                                MapVariables.global_rotation = 270f;
                                            }
                                        }else if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z-1]){
                                            MapVariables.global_rotation = 0f;
                                        }else if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z-1]){
                                            MapVariables.global_rotation = 270f;
                                        }
                                    }
                                    MapVariables.z--;
                                    MapVariables.MaObLi[MapVariables.x,MapVariables.z] = Instantiate(prefab_list[check_it], 
                                    new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                                    Quaternion.Euler(0f,MapVariables.global_rotation,0f));
                                    //Debug.Log("Instantiated "+(check_it+1)+" object on the list");
                                    MapVariables.MaObLib[MapVariables.x,MapVariables.z] = true;
                                    //break;
                                }else{
                                    //break;
                                }
                        }
                        /*if(direction_==0){
                            if(!MapVariables.MaObLib[MapVariables.x+1,MapVariables.z]){
                                MapVariables.x++;
                                MapVariables.MaObLi[MapVariables.x,MapVariables.z] = Instantiate(prefab_list[check_it], 
                                new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                                Quaternion.Euler(0f,MapVariables.global_rotation,0f));
                                //Debug.Log("Instantiated "+(check_it+1)+" object on the list");
                                MapVariables.MaObLib[MapVariables.x,MapVariables.z] = true;
                                //break;
                            }
                        }else if(direction_==1){
                                if(!MapVariables.MaObLib[MapVariables.x-1,MapVariables.z]){
                                MapVariables.x--;
                                MapVariables.MaObLi[MapVariables.x,MapVariables.z] = Instantiate(prefab_list[check_it], 
                                new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                                Quaternion.Euler(0f,MapVariables.global_rotation,0f));
                                //Debug.Log("Instantiated "+(check_it+1)+" object on the list");
                                MapVariables.MaObLib[MapVariables.x,MapVariables.z] = true;
                                //break;
                                }
                        }else if(direction_==2){
                                if(!MapVariables.MaObLib[MapVariables.x,MapVariables.z+1]){
                                MapVariables.z++;
                                MapVariables.MaObLi[MapVariables.x,MapVariables.z] = Instantiate(prefab_list[check_it], 
                                new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                                Quaternion.Euler(0f,MapVariables.global_rotation,0f));
                                //Debug.Log("Instantiated "+(check_it+1)+" object on the list");
                                MapVariables.MaObLib[MapVariables.x,MapVariables.z] = true;
                                //break;
                                }
                        }else if(direction_==3){
                                if(!MapVariables.MaObLib[MapVariables.x,MapVariables.z-1]){
                                MapVariables.z--;
                                MapVariables.MaObLi[MapVariables.x,MapVariables.z] = Instantiate(prefab_list[check_it], 
                                new Vector3(MapVariables.x*3, MapVariables.y*3, MapVariables.z*3), 
                                Quaternion.Euler(0f,MapVariables.global_rotation,0f));
                                //Debug.Log("Instantiated "+(check_it+1)+" object on the list");
                                MapVariables.MaObLib[MapVariables.x,MapVariables.z] = true;
                                //break;
                                }
                        }else{
                            //break;
                        }*/
                    //}
                }
                //break;
            }
        //}
    }
}

