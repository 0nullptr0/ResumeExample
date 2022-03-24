using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator3 : MonoBehaviour
{
    public Transform roof;
    public Transform floor;
    public Transform border;
    public Vector3 mapSize;

    [Range(0,1)]
    public float wallProbability;
    public bool fillMap;
    public bool fillFloor;
    public bool fillRoof;
    public bool fillBorder;

    List<Pos> planePosList;
    Queue<Pos> randomizedPosList;

    public int seed = 1;
    Pos mapCentre;
    public bool[,] previousWallMap;
    public bool[,] wallMap;
    int previousLevel = 0;

    void Start(){
        generateMap();
    }

    //################# map generation method #################
    public void generateMap(){
        previousWallMap = new bool[(int)mapSize.x, (int)mapSize.z];
        int currentLevel = -1;
        for(int height_ = 0; height_<mapSize.y; height_++){
            currentLevel++;
            planePosList = new List<Pos>();
            for(int i = 0; i<mapSize.x; i++){
                for(int j = 0; j<mapSize.z; j++){
                    planePosList.Add(new Pos(i,j));
                }
            }
            randomizedPosList = new Queue<Pos>(Classes.Randomize(
                planePosList.ToArray(), seed+height_));
            mapCentre = new Pos((int)(mapSize.x/2), (int)(mapSize.z/2));
            string holderName = "GeneratedFragment"+(height_+1);
            if(transform.Find(holderName)){
                DestroyImmediate(transform.Find(holderName).gameObject);
            }
            Transform mapHolder = new GameObject(holderName).transform;
            mapHolder.parent = transform;
            if(fillMap){
                wallMap = new bool[(int)mapSize.x, (int)mapSize.z];
                for(int i = 0; i<mapSize.x; i++){
                    for(int j = 0; j<mapSize.z; j++){
                        Vector3 planePos = posToPos(i,j);
                        planePos.z = height_*3;
                        Transform newPlane = Instantiate(border, planePos, 
                        Quaternion.Euler(0f,0f,0f)) as Transform;
                        newPlane.parent = mapHolder;
                    }
                }
            }else{
                wallMap = new bool[(int)mapSize.x, (int)mapSize.z];
                int noWallBlocks = (int)(mapSize.x*mapSize.z*wallProbability);
                int wallCount = 0;
                for(int i = 0; i<noWallBlocks; i++){
                    Pos randomPos = getRandomPos();
                    wallMap[randomPos.x, randomPos.z] = true;
                    wallCount++;
                    if(!(randomPos != mapCentre && canBePassed(wallMap, wallCount))){
                        wallMap[randomPos.x, randomPos.z] = false;
                        wallCount--;
                    }
                }
                if(fillFloor && height_ == 0){
                    for(int i = 0; i<mapSize.x; i++){
                        for(int j = 0; j<mapSize.z; j++){
                            if(!wallMap[i,j]){
                                Vector3 planePos = posToPos(i,j);
                                planePos.y = height_*3;
                                Transform newPlane = Instantiate(floor, planePos, 
                                Quaternion.Euler(0f,0f,0f)) as Transform;
                                newPlane.parent = mapHolder;
                            }
                        }
                    }
                }
                if(fillRoof && height_+1 == mapSize.y){
                    for(int i = 0; i<mapSize.x; i++){
                        for(int j = 0; j<mapSize.z; j++){
                            if(!wallMap[i,j]){
                                Vector3 planePos = posToPos(i,j);
                                planePos.y = height_*3;
                                Transform newPlane = Instantiate(roof, planePos, 
                                Quaternion.Euler(0f,0f,0f)) as Transform;
                                newPlane.parent = mapHolder;
                            }
                        }
                    }
                }
                if(height_>0){
                    for(int i = 0; i<mapSize.x; i++){
                        for(int j = 0; j<mapSize.z; j++){
                            //floor
                            if(!wallMap[i,j] && previousWallMap[i,j]){
                                Vector3 planePos = posToPos(i,j);
                                planePos.y = height_*3;
                                Transform newPlane = Instantiate(floor, planePos, 
                                Quaternion.Euler(0f,180f,0f)) as Transform;
                                newPlane.parent = mapHolder;
                            }
                            //roof
                            if(wallMap[i,j] && !previousWallMap[i,j]){
                                Vector3 planePos = posToPos(i,j);
                                planePos.y = height_*3-3;
                                Transform newPlane = Instantiate(roof, planePos, 
                                Quaternion.Euler(0f,180f,0f)) as Transform;
                                newPlane.parent = mapHolder;
                            }
                        }
                    }
                }
                if(fillBorder){
                    for(int i = 0; i<mapSize.x; i++){
                        for(int j = 0; j<mapSize.z; j++){
                            if(i<mapSize.x-1)
                            if(!wallMap[i,j] && wallMap[i+1,j]){
                                Vector3 planePos = posToPos(i,j);
                                planePos.y = height_*3;
                                Transform newPlane = Instantiate(border, planePos, 
                                Quaternion.Euler(0f,180f,0f)) as Transform;
                                newPlane.parent = mapHolder;
                            }
                            if(j<mapSize.z-1)
                            if(!wallMap[i,j] && wallMap[i,j+1]){
                                Vector3 planePos = posToPos(i,j);
                                planePos.y = height_*3;
                                Transform newPlane = Instantiate(border, planePos, 
                                Quaternion.Euler(0f,90f,0f)) as Transform;
                                newPlane.parent = mapHolder;
                            }
                            if(i>0)
                            if(!wallMap[i,j] && wallMap[i-1,j]){
                                Vector3 planePos = posToPos(i,j);
                                planePos.y = height_*3;
                                Transform newPlane = Instantiate(border, planePos, 
                                Quaternion.Euler(0f,0f,0f)) as Transform;
                                newPlane.parent = mapHolder;
                            }
                            if(j>0)
                            if(!wallMap[i,j] && wallMap[i,j-1]){
                                Vector3 planePos = posToPos(i,j);
                                planePos.y = height_*3;
                                Transform newPlane = Instantiate(border, planePos, 
                                Quaternion.Euler(0f,270f,0f)) as Transform;
                                newPlane.parent = mapHolder;
                            }
                        }
                    }
                    for(int i = 0; i<mapSize.x; i++){
                        int j = 0;
                        if(!wallMap[i,j]){
                            Vector3 planePos = posToPos(i,j);
                            planePos.y = height_*3;
                            Transform newPlane = Instantiate(border, planePos, 
                            Quaternion.Euler(0f,270f,0f)) as Transform;
                            newPlane.parent = mapHolder;
                        }
                        j = (int)(mapSize.z-1);
                        if(!wallMap[i,j]){
                            Vector3 planePos = posToPos(i,j);
                            planePos.y = height_*3;
                            Transform newPlane = Instantiate(border, planePos, 
                            Quaternion.Euler(0f,90f,0f)) as Transform;
                            newPlane.parent = mapHolder;
                        }
                    }
                    for(int j = 0; j<mapSize.z; j++){
                        int i = 0;
                        if(!wallMap[i,j]){
                            Vector3 planePos = posToPos(i,j);
                            planePos.y = height_*3;
                            Transform newPlane = Instantiate(border, planePos, 
                            Quaternion.Euler(0f,0f,0f)) as Transform;
                            newPlane.parent = mapHolder;
                        }
                        i = (int)(mapSize.x-1);
                        if(!wallMap[i,j]){
                            Vector3 planePos = posToPos(i,j);
                            planePos.y = height_*3;
                            Transform newPlane = Instantiate(border, planePos, 
                            Quaternion.Euler(0f,180f,0f)) as Transform;
                            newPlane.parent = mapHolder;
                        }
                    }
                }
            }
            for(int i = 0; i<mapSize.x; i++){
                for(int j = 0; j<mapSize.z; j++){
                    previousWallMap[i,j] = wallMap[i,j];
                }                    
            }
        }
        if(previousLevel>currentLevel){
            for(int i = currentLevel+1; i<=previousLevel+1; i++){
                string holderName = "GeneratedFragment"+(i);
                if(transform.Find(holderName)){
                    DestroyImmediate(transform.Find(holderName).gameObject);
                }
            }
        }
        previousLevel = currentLevel;
    }

    //################# path passing method #################
    bool canBePassed(bool[,] wallMap, int wallCount){
        bool[,] mapFlags = new bool[wallMap.GetLength(0),
        wallMap.GetLength(1)];
        Queue<Pos> queue = new Queue<Pos>();
        queue.Enqueue(mapCentre);
        mapFlags[mapCentre.x, mapCentre.z] = true;
        int passingPlaneCount = 1;
        while(queue.Count > 0){
            Pos _plane = queue.Dequeue();
            for(int i = -1; i<=1; i++){
                for(int j = -1; j<=1; j++){
                    int neighbourX = _plane.x+i;
                    int neighbourZ = _plane.z+j;
                    if(i==0 || j==0){
                        if(neighbourX >= 0 && 
                        neighbourX < wallMap.GetLength(0) && 
                        neighbourZ >= 0 && 
                        neighbourZ < wallMap.GetLength(1)){
                            if(!mapFlags[neighbourX, neighbourZ] && 
                            !wallMap[neighbourX, neighbourZ]){
                                mapFlags[neighbourX, neighbourZ] = true;
                                queue.Enqueue(new Pos(neighbourX, neighbourZ));
                                passingPlaneCount++;
                            }
                        }
                    }
                }
            }
        }
        int targetPlaneCount = (int)(mapSize.x*mapSize.z-wallCount);
        return targetPlaneCount == passingPlaneCount;
    }

    //################# int pos to Vector3 pos #################
    Vector3 posToPos(int x, int z){
        return new Vector3(-mapSize.x+x*3, 0, -mapSize.z+z*3);
    }

    //################# generating random Pos struct #################
    public Pos getRandomPos(){
        Pos randomPos = randomizedPosList.Dequeue();
        randomizedPosList.Enqueue(randomPos);
        return randomPos;
    }

    public struct Pos{
        public int x;
        public int z;

        public Pos(int _x, int _z){
            x = _x;
            z = _z;
        }

        public static bool operator ==(Pos c1, Pos c2){
            return c1.x == c2.x && c1.z == c2.z;
        }
        public static bool operator !=(Pos c1, Pos c2){
            return !(c1 == c2);
        }
    };
}
