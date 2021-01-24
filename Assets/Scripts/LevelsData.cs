using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelsData
{
    public bool[] isLevelsFinished;
    public LevelsData(List<LevelInfo> levels)
    {
        isLevelsFinished = new bool[levels.Count];
        for (int i = 0; i < levels.Count; i++)
        {
            isLevelsFinished[i] = levels[i].isFinishe;
        }
    }
}
