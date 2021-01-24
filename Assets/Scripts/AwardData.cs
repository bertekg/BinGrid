using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AwardData
{
    public bool[,,] awardCellsInfo;
    public AwardData(int numberOfAward, int numberRows, int numberColumn)
    {
        awardCellsInfo = new bool[numberOfAward, numberRows, numberColumn];
    }
}
