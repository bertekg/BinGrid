using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;

public class ManageOfSave : MonoBehaviour
{
    public TMP_Text dispalOfPossibleUncover;
    private string text1YouCanUncover, text2Parts;
    public void Start()
    {
        LoadLevels();
        int isCorrrect = PlayerPrefs.GetInt("CorrectFinish");
        if(isCorrrect == 1)
        {
            PlayerPrefs.SetInt("CorrectFinish", 0);
            int levelFinished = PlayerPrefs.GetInt("OpenedLevel");
            listOfLevels[levelFinished].isFinishe = true;
            listOfLevels[levelFinished].UpdateBool();
            SaveLevels();
        }
        LoadAward();
        CalcPossibleCells();        
    }
    public List<LevelInfo> listOfLevels;
    public AwardData allLevelsAward;
    private int countTotalFinishedLevel;
    private int countShowedAwardCells;
    private int possibleToUncover;
    private void CalcPossibleCells()
    {
        countTotalFinishedLevel = 0;
        for (int i = 0; i < listOfLevels.Count; i++)
        {
            if(listOfLevels[i].isFinishe)
            {
                countTotalFinishedLevel++;
            }
        }
        countShowedAwardCells = 0;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    if(allLevelsAward.awardCellsInfo[i, j, k])
                    {
                        countShowedAwardCells++;
                    }
                }
            }
        }
        possibleToUncover = countTotalFinishedLevel - countShowedAwardCells;
        UpdateText();
    }
    public void UpdateText()
    {
        dispalOfPossibleUncover.text = text1YouCanUncover + " " + possibleToUncover.ToString() + " " + text2Parts;
    }
    public int GetPossibleToUncover()
    {
        CalcPossibleCells();
        return possibleToUncover;
    }
    public bool RequestForCells(int picture, int column, int row)
    {
        bool retBool = false;
        if(allLevelsAward.awardCellsInfo[picture, column, row] == false)
        {
            if(possibleToUncover > 0)
            {
                allLevelsAward.awardCellsInfo[picture, column, row] = true;
                SaveAward();
                retBool = true;
                CalcPossibleCells();
            }
        }
        return retBool;
    }
    public bool CheckAllPictureUncovered(int indexOfPicture)
    {
        bool isUncoverde = true;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if(allLevelsAward.awardCellsInfo[indexOfPicture, i, j] == false)
                {
                    isUncoverde = false;
                }
            }
        }
        return isUncoverde;
    }
    public AwardData GetAllAwardData()
    {
        return allLevelsAward;
    }
    public void SaveLevels()
    {
        LevelsData ld = new LevelsData(listOfLevels);
        SaveSystem.SaveLevels(ld);
    }
    public void LoadLevels()
    {
        LevelsData ld = SaveSystem.LoadLevels();
        if(ld != null)
        {
            for (int i = 0; i < ld.isLevelsFinished.Length; i++)
            {
                listOfLevels[i].isFinishe = ld.isLevelsFinished[i];
                listOfLevels[i].UpdateBool();
            }
        }
        else
        {
            SaveLevels();
        }
    }
    public void SaveAward()
    {
        SaveSystem.SaveAwardInfo(allLevelsAward);
    }
    public void LoadAward()
    {
        AwardData ad = SaveSystem.LoadAwardInfo();
        allLevelsAward = new AwardData(6, 5, 4);
        if (ad != null)
        {            
            allLevelsAward.awardCellsInfo = ad.awardCellsInfo;
        }
    }
    public void ClearLevels()
    {
        bool isCleraed = SaveSystem.ClearData();
        if (isCleraed)
        {
            for (int i = 0; i < listOfLevels.Count; i++)
            {
                listOfLevels[i].isFinishe = false;
                listOfLevels[i].UpdateBool();
            }
        }        
    }
    public void ClearAward()
    {
        bool isCleraed = SaveSystem.ClearAwardData();
        if (isCleraed)
        {
            allLevelsAward = new AwardData(6, 5, 4);
        }
    }
    public void UpadateLanguage()
    {
        Dictionary<LanguageMenagerMainMenu.AwardString, string> awardInfo = GameObject.Find("LangMenMainMenu").GetComponent<LanguageMenagerMainMenu>().GetStringsForAward();
        UpadateLanguageKnowed(awardInfo);
    }
    public void UpadateLanguageKnowed(Dictionary<LanguageMenagerMainMenu.AwardString, string> dataToSend)
    {
        text1YouCanUncover = dataToSend[LanguageMenagerMainMenu.AwardString.text1];
        text2Parts = dataToSend[LanguageMenagerMainMenu.AwardString.text2];
        UpdateText();
    }
}
