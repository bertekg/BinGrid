using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class RandomLevelCreate : MonoBehaviour
{
    public TMP_InputField howManyBits, howManyWords;
    public TMP_Text errorInfo;
    private string error1NoBitsNumber, error2NoWordsNumber, error3BitsTooSmall, error4BitsTooBig, error5WordsTooSmall, error6WordsTooBig;
    private string levelRandNameText1, levelRandNameText2, levelRandNameText3;
    public void Start()
    {
        howManyBits.text = PlayerPrefs.GetInt("randomHowManyBits", 4).ToString();
        howManyWords.text = PlayerPrefs.GetInt("randomHowManyWords", 1).ToString();
        errorInfo.text = string.Empty;
        int isCorrrect = PlayerPrefs.GetInt("CorrectFinish");
        if (isCorrrect == 1)
        {
            PlayerPrefs.SetInt("CorrectFinish", 0);
        }
    }
    private void OnEnable()
    {
        UpadateLanguage();
    }
    public void CreateLevelTrigger()
    {
        int randomHowManyBits = 0, randomHowManyWords = 0;
        bool erroDetectInParse = false;
        string errorMesage = "";
        try
        {
            randomHowManyBits = int.Parse(howManyBits.text);
        }
        catch
        {
            errorMesage += error1NoBitsNumber;
            erroDetectInParse = true;
        }
        try
        {
            randomHowManyWords = int.Parse(howManyWords.text);
        }
        catch
        {
            errorMesage += error2NoWordsNumber;
            erroDetectInParse = true;
        }
        errorInfo.text = errorMesage;
        if (erroDetectInParse == false)
        {
            bool isGoodNumberOfBits = false, isGoodNumberOfWords = false;
            if (randomHowManyBits < 4)
            {
                errorMesage += error3BitsTooSmall;
            }
            else if (randomHowManyBits > 10)
            {
                errorMesage += error4BitsTooBig;
            }
            else
            {
                isGoodNumberOfBits = true;
            }
            if (randomHowManyWords < 1)
            {
                errorMesage += error5WordsTooSmall;
            }
            else if (randomHowManyWords > 10)
            {
                errorMesage += error6WordsTooBig;
            }
            else
            {
                isGoodNumberOfWords = true;
            }
            errorInfo.text = errorMesage;
            if (isGoodNumberOfBits && isGoodNumberOfWords)
            {
                PlayerPrefs.SetInt("randomHowManyBits", randomHowManyBits);
                PlayerPrefs.SetInt("randomHowManyWords", randomHowManyWords);
                PlayerPrefs.SetInt("WhereToBack", 2);
                string levelName = levelRandNameText1 + randomHowManyWords.ToString() + levelRandNameText2 + randomHowManyBits.ToString() + levelRandNameText3;
                PlayerPrefs.SetString("LavelSelectedName", levelName);

                List<int> listOfWords = new List<int>();
                int maxVal = System.Convert.ToInt16(Mathf.Pow(2, randomHowManyBits) - 1);
                int newRandomValue = 0;
                while(listOfWords.Count < randomHowManyWords)
                {
                    newRandomValue = Random.Range(1, maxVal);
                    if(!listOfWords.Contains(newRandomValue))
                    {
                        listOfWords.Add(newRandomValue);
                    }
                }
                OneLevelData randLevel = new OneLevelData(randomHowManyBits, listOfWords);
                BinaryFormatter formatter = new BinaryFormatter();
                string path = Application.persistentDataPath + "/level.data";
                FileStream stream = new FileStream(path, FileMode.Create);
                formatter.Serialize(stream, randLevel);
                stream.Close();

                SceneManager.LoadScene(1);
            }
        }
    }
    public void UpadateLanguage()
    {
        Dictionary<LanguageMenagerMainMenu.ForRandomString, string> forRandom = GameObject.Find("LangMenMainMenu").GetComponent<LanguageMenagerMainMenu>().GetStiringForRandom();
        UpadateLanguageKnowed(forRandom);
    }
    public void UpadateLanguageKnowed(Dictionary<LanguageMenagerMainMenu.ForRandomString, string> stringForRandom)
    {
        error1NoBitsNumber = stringForRandom[LanguageMenagerMainMenu.ForRandomString.numOfBitsNoExist];
        error2NoWordsNumber = stringForRandom[LanguageMenagerMainMenu.ForRandomString.numOfWordsNoExist];
        error3BitsTooSmall = stringForRandom[LanguageMenagerMainMenu.ForRandomString.numOfBitsTooSmall];
        error4BitsTooBig = stringForRandom[LanguageMenagerMainMenu.ForRandomString.numOfBitsTooBig];
        error5WordsTooSmall = stringForRandom[LanguageMenagerMainMenu.ForRandomString.numOfWordsTooSmall];
        error6WordsTooBig = stringForRandom[LanguageMenagerMainMenu.ForRandomString.numOfWordsTooBig];
        levelRandNameText1 = stringForRandom[LanguageMenagerMainMenu.ForRandomString.nameOfLevelText1];
        levelRandNameText2 = stringForRandom[LanguageMenagerMainMenu.ForRandomString.nameOfLevelText2];
        levelRandNameText3 = stringForRandom[LanguageMenagerMainMenu.ForRandomString.nameOfLevelText3];
        string errorMesage = "";
        bool erroDetectInParse = false;
        int randomHowManyBits = 0, randomHowManyWords = 0;
        try
        {
            randomHowManyBits = int.Parse(howManyBits.text);
        }
        catch
        {
            errorMesage += error1NoBitsNumber;
            erroDetectInParse = true;
        }
        try
        {
            randomHowManyWords = int.Parse(howManyWords.text);
        }
        catch
        {
            errorMesage += error2NoWordsNumber;
            erroDetectInParse = true;
        }        
        if (erroDetectInParse == false)
        {
            if (randomHowManyBits < 4)
            {
                errorMesage += error3BitsTooSmall;
            }
            else if (randomHowManyBits > 10)
            {
                errorMesage += error4BitsTooBig;
            }
            if (randomHowManyWords < 1)
            {
                errorMesage += error5WordsTooSmall;
            }
            else if (randomHowManyWords > 10)
            {
                errorMesage += error6WordsTooBig;
            }
            errorInfo.text = errorMesage;
        }
        else
        {
            errorInfo.text = errorMesage;
        }
    }
}
