using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class MapGenerator3 : MonoBehaviour
{
    public Transform plane;
    public Transform wall;
    public Vector2 mapSize;

    [Range(0,1)]
    public float wallProbability;

    List<Pos> planePosList;
    Queue<Pos> randomizedPosList;

    public int seed = 10;
    Pos mapCentre;

    void Start(){
        generateMap();
    }

    //################# map generation method #################
    public void generateMap(){
        planePosList = new List<Pos>();
        for(int i = 0; i<mapSize.x; i++){
            for(int j = 0; j<mapSize.y; j++){
                planePosList.Add(new Pos(i,j));
            }
        }
        randomizedPosList = new Queue<Pos>(Classes.Randomize(
            planePosList.ToArray(), seed));
        mapCentre = new Pos((int)(mapSize.x/2), (int)(mapSize.y/2));
        string holderName = "GeneratedFragment";
        if(transform.Find(holderName)){
            DestroyImmediate(transform.Find(holderName).gameObject);
        }
        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;
        for(int i = 0; i<mapSize.x; i++){
            for(int j = 0; j<mapSize.y; j++){
                Vector3 planePos = posToPos(i,j);
                Transform newPlane = Instantiate(plane, planePos, 
                Quaternion.Euler(0f,0f,0f)) as Transform;
                newPlane.parent = mapHolder;
            }
        }
        bool[,] wallMap = new bool[(int)mapSize.x, (int)mapSize.y];
        int noWallBlocks = (int)(mapSize.x*mapSize.y*wallProbability);
        int wallCount = 0;
        for(int i = 0; i<noWallBlocks; i++){
            Pos randomPos = getRandomPos();
            wallMap[randomPos.x, randomPos.y] = true;
            wallCount++;
            if(randomPos != mapCentre && canBePassed(wallMap, wallCount)){
                Vector3 wallPos = posToPos(randomPos.x, randomPos.y);
                Transform newWall = Instantiate(wall, wallPos, 
                Quaternion.identity) as Transform;
                newWall.parent = mapHolder;
            }else{
                wallMap[randomPos.x, randomPos.y] = false;
                wallCount--;
            }
        }
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
