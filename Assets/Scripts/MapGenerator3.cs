using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator3 : MonoBehaviour
{
    public Transform roof;
    public Transform floor;
    public Transform border;
    public Transform wall;
    public Vector2 mapSize;

    [Range(0,1)]
    public float wallProbability;
    public bool fillMap;
    public bool fillFloor;
    public bool fillRoof;
    public bool fillBorder;

    List<Pos> planePosList;
    Queue<Pos> randomizedPosList;

    public int seed = 1;
    public int height = 1;
    Pos mapCentre;
    public bool[,] previousWallMap;
    public bool[,] wallMap;
    int previousLevel = 0;

    void Start(){
        generateMap();
    }

    //################# map generation method #################
    public void generateMap(){
        previousWallMap = new bool[(int)mapSize.x, (int)mapSize.y];
        int currentLevel = -1;
        for(int height_ = 0; height_<height; height_++){
            currentLevel++;
            planePosList = new List<Pos>();
            for(int i = 0; i<mapSize.x; i++){
                for(int j = 0; j<mapSize.y; j++){
                    planePosList.Add(new Pos(i,j));
                }
            }
            randomizedPosList = new Queue<Pos>(Classes.Randomize(
                planePosList.ToArray(), seed+height_));
            mapCentre = new Pos((int)(mapSize.x/2), (int)(mapSize.y/2));
            string holderName = "GeneratedFragment"+(height_+1);
            if(transform.Find(holderName)){
                DestroyImmediate(transform.Find(holderName).gameObject);
            }
            Transform mapHolder = new GameObject(holderName).transform;
            mapHolder.parent = transform;
            if(fillMap){
                wallMap = new bool[(int)mapSize.x, (int)mapSize.y];
                for(int i = 0; i<mapSize.x; i++){
                    for(int j = 0; j<mapSize.y; j++){
                        Vector3 planePos = posToPos(i,j);
                        planePos.y = height_*3;
                        Transform newPlane = Instantiate(wall, planePos, 
                        Quaternion.Euler(0f,0f,0f)) as Transform;
                        newPlane.parent = mapHolder;
                    }
                }
            }else{
                wallMap = new bool[(int)mapSize.x, (int)mapSize.y];
                int noWallBlocks = (int)(mapSize.x*mapSize.y*wallProbability);
                int wallCount = 0;
                for(int i = 0; i<noWallBlocks; i++){
                    Pos randomPos = getRandomPos();
                    wallMap[randomPos.x, randomPos.y] = true;
                    wallCount++;
                    if(randomPos != mapCentre && canBePassed(wallMap, wallCount)){
                        /*Vector3 wallPos = posToPos(randomPos.x, randomPos.y);
                        wallPos.y = height_*3;
                        Transform newWall = Instantiate(wall, wallPos, 
                        Quaternion.identity) as Transform;
                        newWall.parent = mapHolder;*/
                    }else{
                        wallMap[randomPos.x, randomPos.y] = false;
                        wallCount--;
                    }
                }
                if(fillFloor && height_ == 0){
                    for(int i = 0; i<mapSize.x; i++){
                        for(int j = 0; j<mapSize.y; j++){
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
                if(fillRoof && height_+1 == height){
                    for(int i = 0; i<mapSize.x; i++){
                        for(int j = 0; j<mapSize.y; j++){
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
                        for(int j = 0; j<mapSize.y; j++){
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
                        for(int j = 0; j<mapSize.y; j++){
                            if(i<mapSize.x-1)
                            if(!wallMap[i,j] && wallMap[i+1,j]){
                                Vector3 planePos = posToPos(i,j);
                                planePos.y = height_*3;
                                Transform newPlane = Instantiate(border, planePos, 
                                Quaternion.Euler(0f,180f,0f)) as Transform;
                                newPlane.parent = mapHolder;
                            }
                            if(j<mapSize.y-1)
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
                        j = (int)(mapSize.y-1);
                        if(!wallMap[i,j]){
                            Vector3 planePos = posToPos(i,j);
                            planePos.y = height_*3;
                            Transform newPlane = Instantiate(border, planePos, 
                            Quaternion.Euler(0f,90f,0f)) as Transform;
                            newPlane.parent = mapHolder;
                        }
                    }
                    for(int j = 0; j<mapSize.y; j++){
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
                for(int j = 0; j<mapSize.y; j++){
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
        mapFlags[mapCentre.x, mapCentre.y] = true;
        int passingPlaneCount = 1;
        while(queue.Count > 0){
            Pos _plane = queue.Dequeue();
            for(int i = -1; i<=1; i++){
                for(int j = -1; j<=1; j++){
                    int neighbourX = _plane.x+i;
                    int neighbourY = _plane.y+j;
                    if(i==0 || j==0){
                        if(neighbourX >= 0 && 
                        neighbourX < wallMap.GetLength(0) && 
                        neighbourY >= 0 && 
                        neighbourY < wallMap.GetLength(1)){
                            if(!mapFlags[neighbourX, neighbourY] && 
                            !wallMap[neighbourX, neighbourY]){
                                mapFlags[neighbourX, neighbourY] = true;
                                queue.Enqueue(new Pos(neighbourX, neighbourY));
                                passingPlaneCount++;
                            }
                        }
                    }
                }
            }
        }
        int targetPlaneCount = (int)(mapSize.x*mapSize.y-wallCount);
        return targetPlaneCount == passingPlaneCount;
    }

    //################# int pos to Vector3 pos #################
    Vector3 posToPos(int x, int y){
        return new Vector3(-mapSize.x+x*3, 0, -mapSize.y+y*3);
    }

    //################# generating random Pos struct #################
    public Pos getRandomPos(){
        Pos randomPos = randomizedPosList.Dequeue();
        randomizedPosList.Enqueue(randomPos);
        return randomPos;
    }

    public struct Pos{
        public int x;
        public int y;

        public Pos(int _x, int _y){
            x = _x;
            y = _y;
        }

        public static bool operator ==(Pos c1, Pos c2){
            return c1.x == c2.x && c1.y == c2.y;
        }
        public static bool operator !=(Pos c1, Pos c2){
            return !(c1 == c2);
        }
    };
}
