using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
    public GameObject[] pillars;

    [SerializeField]
    private List<MeshFilter> sourceMeshFilters;
    private MeshFilter targetMeshFilter;

    [ContextMenu(itemName:"Combine Meshes")]
    private void CombineMeshes(){
        var combine = new CombineInstance[pillars.Length];
        for(int i = 0; i<pillars.Length; i++){
            combine[i].mesh = sourceMeshFilters[i].sharedMesh;
            combine[i].transform = sourceMeshFilters[i].transform.localToWorldMatrix;
        }
        var mesh = new Mesh();
        mesh.CombineMeshes(combine);
        targetMeshFilter.mesh = mesh;
    }

    void Start(){
        pillars = GameObject.FindGameObjectsWithTag("MusicPillar");
        GameObject bruh;
        bruh = GameObject.FindWithTag("MusicPillar");
        if(bruh == null){
            Debug.Log("bruh");
        }else{
            Debug.Log("jednak nie bruh");
        }
    }
}
