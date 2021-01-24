using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class AllLevelsData : MonoBehaviour
{
    public List<OneLevelData> listForAllLevels;
    private string createdLevelNameText1, createdLevelNameText2;
    public void OpenLeve(int indexOfLevel)
    {
        Dictionary<LanguageMenagerMainMenu.ForCreatedString, string> forCreated = GameObject.Find("LangMenMainMenu").GetComponent<LanguageMenagerMainMenu>().GetStiringForCreated();
        createdLevelNameText1 = forCreated[LanguageMenagerMainMenu.ForCreatedString.nameOfLevelText1];
        createdLevelNameText2 = forCreated[LanguageMenagerMainMenu.ForCreatedString.nameOfLevelText2];
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/level.data";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, listForAllLevels[indexOfLevel]);
        stream.Close();
        PlayerPrefs.SetInt("OpenedLevel", indexOfLevel);
        string levelName = createdLevelNameText1;
        int levelNumber = 0;
        switch(indexOfLevel)
        {
            case int n when (n >= 0 && n < 8):
                levelNumber = n + 1;
                levelName += "4" + createdLevelNameText2;
                if(levelNumber < 10)
                {
                    levelName += "0";
                }
                levelName += levelNumber.ToString();
                break;
            case int n when (n >= 8 && n < 24):
                levelNumber = n - 7;
                levelName = "6" + createdLevelNameText2;
                if (levelNumber < 10)
                {
                    levelName += "0";
                }
                levelName += levelNumber.ToString();
                break;
            case int n when (n >= 24 && n < 56):
                levelNumber = n - 23;
                levelName = "8" + createdLevelNameText2;
                if (levelNumber < 10)
                {
                    levelName += "0";
                }
                levelName += levelNumber.ToString();
                break;
            case int n when (n >= 56 && n < 120):
                levelNumber = n - 55;
                levelName = "10" + createdLevelNameText2;
                if (levelNumber < 10)
                {
                    levelName += "0";
                }
                levelName += (n - 55).ToString();
                break;
        }
        PlayerPrefs.SetString("LavelSelectedName", levelName);
        PlayerPrefs.SetInt("WhereToBack", 1);
        SceneManager.LoadScene(1);
    }
}
