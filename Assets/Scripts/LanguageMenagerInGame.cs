using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageMenagerInGame : MonoBehaviour
{
    string curLangSet;
    public TMP_Text textExitToManuButton, textInfoAfterFinishGoodLevel, textGoBackAfterCorrectButton;
    private void Awake()
    {
        curLangSet = PlayerPrefs.GetString("setLang", SystemLanguage.English.ToString());
        if (curLangSet == SystemLanguage.Polish.ToString())
        {
            SetLanguagePol();
        }
        else
        {
            SetLanguageEng();
        }        
    }
    public void SetLanguagePol()
    {
        textExitToManuButton.text = "Zamkończ";
        textInfoAfterFinishGoodLevel.text = "Ukończyłeś poziom poprawnie!";
        int whereToBack = PlayerPrefs.GetInt("WhereToBack", 0);
        if(whereToBack == 1)
        {
            textGoBackAfterCorrectButton.text = "Powrót do listy utworzonych poziomów";
        }
        else if(whereToBack == 2)
        {
            textGoBackAfterCorrectButton.text = "Powrót do tworzenia losowego poziomu";
        }
        curLangSet = SystemLanguage.Polish.ToString();
    }
    public void SetLanguageEng()
    {
        textExitToManuButton.text = "Exit";
        textInfoAfterFinishGoodLevel.text = "You finished level correct!";
        int whereToBack = PlayerPrefs.GetInt("WhereToBack", 0);
        if (whereToBack == 1)
        {
            textGoBackAfterCorrectButton.text = "Return to created levels list";
        }
        else if (whereToBack == 2)
        {
            textGoBackAfterCorrectButton.text = "Return to creating a random level";
        }
        curLangSet = SystemLanguage.English.ToString();
    }
}
