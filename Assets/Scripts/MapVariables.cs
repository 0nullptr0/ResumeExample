using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapVariables : MonoBehaviour
{
    public static int dimension_x = 50;
    public static int dimension_z = 50;
    public static int length_of_the_map = 50;
    public static int x = dimension_x/2;
    public static int y = 0;
    public static int z = dimension_z/2;
    public static GameObject[,] MaObLi;
    public static bool[,] MaObLib;
    public static float global_rotation = 0f;
    void Start()
    {
        MaObLi = new GameObject[dimension_x,dimension_z];
        MaObLib = new bool[dimension_x,dimension_z];
        for(int i=0; i<dimension_x; i++){
            for(int j=0; j<dimension_z; j++){
                MaObLib[i,j] = false;
            }
        }
        for(int i=0; i<dimension_x; i++){
            MaObLib[i,0] = true;
            MaObLib[i,dimension_z-1] = true;
            MaObLib[0,i] = true;
            MaObLib[dimension_x-1,i] = true;
        }
        MaObLi[dimension_x/2,dimension_z/2] = GetComponent<GameStarter>().prefab_;
        MaObLib[dimension_x/2,dimension_z/2] = true;
    }
}
