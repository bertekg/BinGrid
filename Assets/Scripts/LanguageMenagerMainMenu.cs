using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageMenagerMainMenu : MonoBehaviour
{
    string curLangSet;
    public TMP_Text textLanguageTitle, textClearAllData, textOptionTitleInOption, textBackInOption,
        textMessageForConfirmClear, textYesInClearData, textNoInClearData,
        textBackInTutorial, textTutorialTitleInTutorial, textInfoInTutorial, textPage1BasicInfo, textPage2GameMode, textPage3GatheringAward, textPage4AboutGame,
        textGameModeTutorial, textGatheringAwardTutorial , textCreditsInTutorial,
        textBackInAward, textAwardTitleInAward, textExitFullscreen,
        textBackInRandom, textRandomTitleInRandom, textRandomNumberOfBits, textRandomNumberOfWords, textRadnomCreateLevelButton,
        textBackInPlay, textPlayTitleInPlay,
        textPlayCreatedInMenu, textPlayRandomInMenu, textTutorialInMenu, textOptionInMenu, textAwardInMenu;
    public List<TMP_Text> textAwardPicAll;
    public List<TMP_Text> textPlayPageAll;
    public List<TMP_Text> textShowFullscreenAll;
    private void Awake()
    {
        curLangSet = PlayerPrefs.GetString("setLang", "none");        
        if(curLangSet == "none")
        {
            curLangSet = Application.systemLanguage.ToString();
        }
        if(curLangSet == SystemLanguage.Polish.ToString())
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
        textLanguageTitle.text = "Wybór język";
        textClearAllData.text = "Wyczyść wszystkie dane zapisu";
        textOptionTitleInOption.text = "Opcje";        
        textBackInOption.text = "Powrót";
        textMessageForConfirmClear.text = "Czy na pewno chcesz usunąć wszyskie dane?";
        textYesInClearData.text = "TAK";
        textNoInClearData.text = "NIE";
        textBackInTutorial.text = "Powrót";
        textTutorialTitleInTutorial.text = "Samouczek gry";
        textInfoInTutorial.text = "Należy załączyć przycisków tak aby binarnie utworzyły wartość która znajduje się po prawej. Ponad przyciskami znajdują się podpowiedzi (wartość dziesiętna konkretnego przycisku). Jeżeli kombinacja przycisków zostanie poprawnie ustawiona to liczba zmieni swój kolor z białego na zielony. Poziom zostanie ukończony gdy wszystkie kombinacje będą poprawne.";
        textPage1BasicInfo.text = "Podstawowe informacje";
        textPage2GameMode.text = "Tryby gry";
        textPage3GatheringAward.text = "Odbieranie nagród";
        textPage4AboutGame.text = "O grze";
        textGameModeTutorial.text = "Możliwe są dwa tryby gry: Utworzone poziomy oraz Losowe poziomy.\n\nW trybie utworzone poziomy zostało przygotowanych 120 poziomów. Poziomy mogą być typu 4, 6, 8 lub 10 bitów. W każdym poziomie możliwe jest kilka liczb do rozkodowania.\n\nW trybie losowego poziomu to gracz decyduje jakiego typu ma być słowo (od 4 do 10 bitów) oraz ile ma być słów (od 1 do 10 słów) w poziomie. Na postawie tych danych zostaje tworzony nowy poziom z losowo dobranymi liczbami.";
        textGatheringAwardTutorial.text = "Po ukończeniu każdego z utworzonych poziomów, otrzymuje się jeden punkt. Ten punkt można wykorzystać do odebrania nagrody w postaci odsłonięcia części zdjęcia. Każde zdjęcie jest przykryte kilkoma kafelkami, więc aby je odkryć całkowicie należy ukończyć odpowiednią ilość poziomów. Po odkrycia całego zdjęcia zostanie wyświetlona jego szczegółowy opis.";
        textCreditsInTutorial.text = "Gra stworzone przez\nBartłomiej Grywalski\n\nWykorzystane oprogramowanie:\nUnity\nVisual Studio\nInkscape\nLibreOffice\n\nŹródła grafiki:\nwww.flickr.com/photos/pawelbobowski (nagrody)\nmaterialdesignicons.com (ikony)\nwww.wikipedia.org (flagi)";
        textBackInAward.text = "Powrót";
        textAwardTitleInAward.text = "Nagrody";
        for (int i = 0; i < textAwardPicAll.Count; i++)
        {
            textAwardPicAll[i].text = "Zdjęcie " + (i + 1).ToString();
        }
        for (int i = 0; i < textShowFullscreenAll.Count; i++)
        {
            textShowFullscreenAll[i].text = "Zdjęcie na pełnym ekranie";
        }
        textExitFullscreen.text = "Wyjdź z pełngo ekranu";
        textBackInRandom.text = "Powrót";
        textRandomTitleInRandom.text = "Losowe poziomy";
        textRandomNumberOfBits.text = "Ilość bitów\nMinimalna = 4\nMaksymalna = 10";
        textRandomNumberOfWords.text = "Ilość słów\nMinimalna = 1\nMaksymalna = 10";
        textRadnomCreateLevelButton.text = "Stwórz poziom";
        textBackInPlay.text = "Powrót";
        textPlayTitleInPlay.text = "Utworzone poziomy";
        for (int i = 0; i < textPlayPageAll.Count; i++)
        {
            textPlayPageAll[i].text = "Strona " + (i + 1).ToString();
        }
        textPlayCreatedInMenu.text = "Graj w utworzone poziomy";
        textPlayRandomInMenu.text = "Graj w losowe poziomy";
        textTutorialInMenu.text = "Samouczek";
        textOptionInMenu.text = "Opcje";
        textAwardInMenu.text = "Nagrody";
        curLangSet = SystemLanguage.Polish.ToString();
        PlayerPrefs.SetString("setLang", curLangSet);
        RequestForOtherUpdate();
    }
    public void SetLanguageEng()
    {
        textLanguageTitle.text = "Select Language";
        textClearAllData.text = "Clear All Save Data";
        textOptionTitleInOption.text = "Option";
        textBackInOption.text = "Back";
        textMessageForConfirmClear.text = "Are you sure you want delate all save data?";        
        textYesInClearData.text = "YES";
        textNoInClearData.text = "NO";
        textBackInTutorial.text = "Back";
        textTutorialTitleInTutorial.text = "Game Tutorial";
        textInfoInTutorial.text = "You should turn on the buttons in correct order like binary representation of value on the right. Above the buttons there are hints (decimal value of a particular button). If the button combination is correctly set, font color will change from white to green. The level will be completed when all the combinations are correct.";
        textPage1BasicInfo.text = "Basic information";
        textPage2GameMode.text = "Game modes";
        textPage3GatheringAward.text = "Gathering award";
        textPage4AboutGame.text = "About game";
        textGameModeTutorial.text = "There are two game modes: Created Levels and Random Levels.\n\nIn the Created Levels, 120 levels have been prepared.. Levels can be 4, 6, 8 or 10 bit type. In each level can be several numbers to decode.\n\nIn the Random Level mode, the player decides what type of word should be (4 to 10 bits) and how many words (1 to 10 words) should be in the level. Based on this data, a new level is created with randomly selected numbers.";
        textGatheringAwardTutorial.text = "After completing each of the created levels, you get one point. This point can be used to uncover a part of a photo. Each photo is covered with several tiles, so you need to complete the appropriate number of levels to uncover completely picture. After uncover all photo will be shown detailed description.";
        textCreditsInTutorial.text = "Game created by\nBartłomiej Grywalski\n\nUsed software:\nUnity\nInkscape\nLibreOffice\n\nGraphic source:\nwww.flickr.com/photos/pawelbobowski (awards)\nmaterialdesignicons.com (icons)\nwww.wikipedia.org (flags)";
        textBackInAward.text = "Back";
        textAwardTitleInAward.text = "Awards";
        for (int i = 0; i < textAwardPicAll.Count; i++)
        {
            textAwardPicAll[i].text = "Picture " + (i + 1).ToString();
        }
        for (int i = 0; i < textShowFullscreenAll.Count; i++)
        {
            textShowFullscreenAll[i].text = "Picture on fullscreen";
        }
        textExitFullscreen.text = "Exit fullscreen";
        textBackInRandom.text = "Back";
        textRandomTitleInRandom.text = "Random Levels";
        textRandomNumberOfBits.text = "Number Of Bits\nMinimum = 4\nMaximum = 10";
        textRandomNumberOfWords.text = "Words In Rows\nMinimum = 1\nMaximum = 10";
        textRadnomCreateLevelButton.text = "Create Level";
        textBackInPlay.text = "Back";
        textPlayTitleInPlay.text = "Created Levels";
        for (int i = 0; i < textPlayPageAll.Count; i++)
        {
            textPlayPageAll[i].text = "Page " + (i + 1).ToString();
        }
        textPlayCreatedInMenu.text = "Play created levels";
        textPlayRandomInMenu.text = "Play random levels";
        textTutorialInMenu.text = "Tutorial";
        textOptionInMenu.text = "Option";
        textAwardInMenu.text = "Awards";
        curLangSet = SystemLanguage.English.ToString();
        PlayerPrefs.SetString("setLang", curLangSet);
        RequestForOtherUpdate();
    }
    private void RequestForOtherUpdate()
    {
        /*
        GameObject.Find("PanelWithImage1").GetComponent<TestRecognitionImage>().UpadateLanguageKnowed(curLangSet);
        GameObject.Find("PanelWithImage2").GetComponent<TestRecognitionImage>().UpadateLanguageKnowed(curLangSet);
        GameObject.Find("PanelWithImage3").GetComponent<TestRecognitionImage>().UpadateLanguageKnowed(curLangSet);
        GameObject.Find("PanelWithImage4").GetComponent<TestRecognitionImage>().UpadateLanguageKnowed(curLangSet);
        GameObject.Find("PanelWithImage5").GetComponent<TestRecognitionImage>().UpadateLanguageKnowed(curLangSet);
        GameObject.Find("PanelWithImage6").GetComponent<TestRecognitionImage>().UpadateLanguageKnowed(curLangSet);
        */
        GameObject.Find("LevelsData").GetComponent<ManageOfSave>().UpadateLanguageKnowed(GetStringsForAward());
    }
    public enum AwardString { text1, text2};
    public Dictionary<AwardString, string> GetStringsForAward()
    {
        Dictionary<AwardString, string> awardDictionary = new Dictionary<AwardString, string>();
        if (curLangSet == SystemLanguage.Polish.ToString())
        {
            awardDictionary.Add(AwardString.text1, "Możesz odkryć");
            awardDictionary.Add(AwardString.text2, "elementy");
        }
        else
        {
            awardDictionary.Add(AwardString.text1, "You can uncover");
            awardDictionary.Add(AwardString.text2, "parts");
        }
        return awardDictionary;
    }
    public string GetCurrLanguage()
    {
        return curLangSet;
    }
    public enum ForRandomString { numOfBitsNoExist, numOfWordsNoExist, numOfBitsTooSmall, numOfWordsTooSmall, numOfBitsTooBig, numOfWordsTooBig, nameOfLevelText1, nameOfLevelText2, nameOfLevelText3};
    public Dictionary<ForRandomString, string> GetStiringForRandom()
    {
        Dictionary<ForRandomString, string> RandomStringDictionary = new Dictionary<ForRandomString, string>();
        if (curLangSet == SystemLanguage.Polish.ToString())
        {
            RandomStringDictionary.Add(ForRandomString.numOfBitsNoExist, "Brak podanej ilości bitów.");
            RandomStringDictionary.Add(ForRandomString.numOfWordsNoExist, "\nBrak podanej ilości słów.");
            RandomStringDictionary.Add(ForRandomString.numOfBitsTooSmall, "Ilość bitów jest za mała.");
            RandomStringDictionary.Add(ForRandomString.numOfBitsTooBig, "Ilość bitów jest za duża.");
            RandomStringDictionary.Add(ForRandomString.numOfWordsTooSmall, "\nIlość słów jest za mała.");
            RandomStringDictionary.Add(ForRandomString.numOfWordsTooBig, "\nIlość słów jest za duża.");
            RandomStringDictionary.Add(ForRandomString.nameOfLevelText1, "Losowy ");
            RandomStringDictionary.Add(ForRandomString.nameOfLevelText2, " słów, typ ");
            RandomStringDictionary.Add(ForRandomString.nameOfLevelText3, "-bit");
        }
        else
        {
            RandomStringDictionary.Add(ForRandomString.numOfBitsNoExist, "No value for number of Bits.");
            RandomStringDictionary.Add(ForRandomString.numOfWordsNoExist, "\nNo value for number of Words.");
            RandomStringDictionary.Add(ForRandomString.numOfBitsTooSmall, "Too small number of Bits.");
            RandomStringDictionary.Add(ForRandomString.numOfBitsTooBig, "Too big number of Bits.");
            RandomStringDictionary.Add(ForRandomString.numOfWordsTooSmall, "\nToo small number of Words.");
            RandomStringDictionary.Add(ForRandomString.numOfWordsTooBig, "\nToo big number of Words.");
            RandomStringDictionary.Add(ForRandomString.nameOfLevelText1, "Random ");
            RandomStringDictionary.Add(ForRandomString.nameOfLevelText2, " words, type ");
            RandomStringDictionary.Add(ForRandomString.nameOfLevelText3, "-bit");
        }
        return RandomStringDictionary;
    }
    public enum ForCreatedString { nameOfLevelText1, nameOfLevelText2 };
    public Dictionary<ForCreatedString, string> GetStiringForCreated()
    {
        Dictionary<ForCreatedString, string> createdStringDictionary = new Dictionary<ForCreatedString, string>();
        if (curLangSet == SystemLanguage.Polish.ToString())
        {
            createdStringDictionary.Add(ForCreatedString.nameOfLevelText1, "Utworzony ");
            createdStringDictionary.Add(ForCreatedString.nameOfLevelText2, "-bit ");
        }
        else
        {
            createdStringDictionary.Add(ForCreatedString.nameOfLevelText1, "Created ");
            createdStringDictionary.Add(ForCreatedString.nameOfLevelText2, "-bit ");
        }
        return createdStringDictionary;
    }
}
