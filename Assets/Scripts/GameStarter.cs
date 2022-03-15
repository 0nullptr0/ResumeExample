using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public GameObject prefab_;
    void Start()
    {
        Instantiate(prefab_, new Vector3(MapVariables.x*3, 0, MapVariables.z*3), Quaternion.identity);
    }
}
