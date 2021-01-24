using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToManu : MonoBehaviour
{
    public void BackToMenu()
    {
        int whereToBack = PlayerPrefs.GetInt("WhereToBack", 0);
        PlayerPrefs.SetInt("BackMode", whereToBack);
        SceneManager.LoadScene(0);
    }
    public void LevelFinishedCorrect()
    {
        int whereToBack = PlayerPrefs.GetInt("WhereToBack", 0);
        PlayerPrefs.SetInt("BackMode", whereToBack);
        if(whereToBack == 1)
        {
            PlayerPrefs.SetInt("CorrectFinish", 1);
        }        
        SceneManager.LoadScene(0);
    }
}
