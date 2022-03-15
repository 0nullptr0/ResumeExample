using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public GameObject prefab_;
    public GameObject camera_prefab;
    void Start()
    {
        Instantiate(prefab_, new Vector3(MapVariables.x*3, 0, MapVariables.z*3), Quaternion.identity);
        Instantiate(camera_prefab, new Vector3(MapVariables.x*3, 1, MapVariables.z*3), Quaternion.identity);
    }
}
