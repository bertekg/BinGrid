using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelInfo:MonoBehaviour
{
    public bool isFinishe = false;
    public Button buttonIsFinshed;
    public void Start()
    {
        UpdateBool();
    }
    public void InvertFinishState()
    {
        isFinishe = !isFinishe;
        UpdateBool();
    }
    public void UpdateBool()
    {
        if(isFinishe)
        {
            buttonIsFinshed.image.color = Color.green;
        }
        else
        {
            buttonIsFinshed.image.color = Color.white;
        }
    }
}
