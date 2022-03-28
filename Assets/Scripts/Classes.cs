using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Classes{
    //Take array as an argument and randomize it.
    public static T[] Randomize<T>(T[] array, int seed){
        System.Random st = new System.Random(seed);
        for(int i = 0; i<array.Length-1; i++){
            int index = st.Next(i, array.Length);
            T temp = array[index];
            array[index] = array[i];
            array[i] = temp;
        }
        return array;
    }
}
