using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class OneLevelData
{
    public int numberOfBits;
    public List<int> listOfWords;
    public OneLevelData(int size, List<int> words)
    {
        numberOfBits = size;
        listOfWords = words;
    }
}
