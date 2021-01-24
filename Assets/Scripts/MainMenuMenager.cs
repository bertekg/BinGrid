using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuMenager : MonoBehaviour
{
    public void Start()
    {
        int BackMode = PlayerPrefs.GetInt("BackMode", 0);
        switch(BackMode)
        {
            case 0:
                Show0MainMenu();
                break;
            case 1:
                Show1PlayCreatedLevels();
                break;
            case 2:
                Show2PlayRandomLevels();
                break;
        }
        PlayerPrefs.SetInt("BackMode", 0);
    }
    public GameObject goMainManu, goPlayCreated, goPlayRandom, goTutorial, goOption, goAward;
    public void Show0MainMenu()
    {
        goMainManu.SetActive(true);
        goPlayCreated.SetActive(false);
        goPlayRandom.SetActive(false);
        goTutorial.SetActive(false);
        goOption.SetActive(false);
        goAward.SetActive(false);
    }
    public void Show1PlayCreatedLevels()
    {
        goMainManu.SetActive(false);        
        goPlayCreated.SetActive(true);
        goPlayRandom.SetActive(false);
        goTutorial.SetActive(false);
        goOption.SetActive(false);
        goAward.SetActive(false);
    }
    public void Show2PlayRandomLevels()
    {
        goMainManu.SetActive(false);
        goPlayCreated.SetActive(false);
        goPlayRandom.SetActive(true);
        goTutorial.SetActive(false);
        goOption.SetActive(false);
        goAward.SetActive(false);
    }
    public void Show3Tutorial()
    {
        goMainManu.SetActive(false);
        goPlayCreated.SetActive(false);
        goPlayRandom.SetActive(false);
        goTutorial.SetActive(true);
        goOption.SetActive(false);
        goAward.SetActive(false);
    }
    public void Show4Option()
    {
        goMainManu.SetActive(false);
        goPlayCreated.SetActive(false);
        goPlayRandom.SetActive(false);
        goTutorial.SetActive(false);
        goOption.SetActive(true);
        goAward.SetActive(false);
    }
    public void Show5Award()
    {
        goMainManu.SetActive(false);
        goPlayCreated.SetActive(false);
        goPlayRandom.SetActive(false);
        goTutorial.SetActive(false);
        goOption.SetActive(false);
        goAward.SetActive(true);
    }
}
